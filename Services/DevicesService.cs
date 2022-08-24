public class DevicesService
{
    private readonly IRepository<Devices> _devicesRepository;

    public DevicesService(IRepository<Devices> devicesRepository)
    {
        _devicesRepository = devicesRepository;
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

}