public class DevicesService
{
    private readonly IRepository<Devices> _devicesRepository;
    private readonly IRepository<MasterUsers> _masterUsersRepository;
    public DevicesService(IRepository<Devices> devicesRepository, IRepository<MasterUsers> masterUsersRepository)
    {
        _devicesRepository = devicesRepository;
        _masterUsersRepository = masterUsersRepository;
    }

    public IServiceResponse<string> GetAllLicense(int customerId, string email)
    {
        var response = new ServiceResponse<string>();
        var cpService = new CPService();
        var date = DateTime.Now;
        try
        {
            var tabletLicensesResult = cpService.CPLicense(email, "GoTablet");
            if (!tabletLicensesResult.Success)
                throw new Exception(tabletLicensesResult.Message);
            var kioksLicencesResult = cpService.CPLicense(email, "GoKiosk");
            if (!kioksLicencesResult.Success)
                throw new Exception(kioksLicencesResult.Message);
            var licenses = new List<LicenseResult>();
            licenses.AddRange(tabletLicensesResult.List);
            licenses.AddRange(kioksLicencesResult.List);
            var dbDevices = _devicesRepository.Table.Where(s => s.customerId == customerId).ToList();
            var insertItems = licenses.Where(s => !dbDevices.Select(p => p.licenseId).Contains(s.id));
            var updateItems = licenses.Where(s => dbDevices.Select(p => p.licenseId).Contains(s.id));
            if (insertItems.Count() > 0)
            {
                var items = insertItems.Select(p => new Devices
                {
                    customerId = p.customer,
                    licenseType = p.product.license_name == "GoKiosk" ? "kiosk" : "tablet",
                    startDate = DateTime.SpecifyKind(p.start_time, DateTimeKind.Utc),
                    endDate = DateTime.SpecifyKind(p.end_time, DateTimeKind.Utc),
                    isActive = false,
                    createdAt = DateTime.SpecifyKind(date, DateTimeKind.Utc),
                    updatedAt = DateTime.SpecifyKind(date, DateTimeKind.Utc),
                    licenseId = p.id
                });
                _devicesRepository.Insert(items);
            }
            if (updateItems.Count() > 0)
            {
                var items = dbDevices.Where(s => updateItems.Select(p => p.id).Contains(s.licenseId));
                foreach (var item in items)
                {
                    var dummy = updateItems.Where(p => p.id == item.licenseId).FirstOrDefault();
                    item.startDate = DateTime.SpecifyKind(dummy.start_time, DateTimeKind.Utc);
                    item.endDate = DateTime.SpecifyKind(dummy.end_time, DateTimeKind.Utc);
                    item.updatedAt = DateTime.SpecifyKind(date, DateTimeKind.Utc);
                }
                _devicesRepository.Update(items);
            }

            response.Success = true;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }
        return response;
    }

    public IServiceResponse<DeviceInfoResponse> GetInfo(string email)
    {
        var response = new ServiceResponse<DeviceInfoResponse>();
        try
        {
            var user = _masterUsersRepository.Table.FirstOrDefault(s => s.email == email);
            if (user == null)
                throw new Exception("No registered user found with this email");
            var devicesCount = _devicesRepository.Table.Where(s => s.customerId == user.customerId).Count();
            if (devicesCount > 0)
            {
                var tabletDevices = _devicesRepository.Table.Where(s => s.licenseType == "tablet" && s.customerId == user.customerId);
                var result = new DeviceInfoResponse();
                result.licence = devicesCount;
                result.inUse = tabletDevices.Where(s => s.isActive == true).Count();
                result.devices = tabletDevices.ToList();
                response.Entity = result;
                response.Count = 1;
            }
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }
        return response;
    }



}