public class MasterUsersService
{
    private readonly IRepository<MasterUsers> _masterUsersRepository;
    private readonly IRepository<Devices> _devicesRepository;

    public MasterUsersService(IRepository<MasterUsers> masterUsersRepository, IRepository<Devices> devicesRepository)
    {
        _masterUsersRepository = masterUsersRepository;
        _devicesRepository = devicesRepository;
    }
    public IServiceResponse<MasterUsers> Login(LoginRequest model)
    {
        var response = new ServiceResponse<MasterUsers>();
        var cpService = new CPService();
        var deviceService = new DevicesService(_devicesRepository);
        try
        {
            var customerCheck = cpService.CPLogin(model.email, model.password);
            if (!customerCheck.Success)
                throw new Exception(customerCheck.Message);
            var customerId = customerCheck.Entity.customer;
            var user = _masterUsersRepository.Table.FirstOrDefault(s => s.email == model.email);
            if (user == null)
            {
                var masterUser = new MasterUsers();
                masterUser.email = model.email;
                masterUser.customerId = customerId;
                masterUser.createdAt = DateTime.UtcNow;
                masterUser.updatedAt = DateTime.UtcNow;
                var rs = _masterUsersRepository.Insert(masterUser);

                response.Entity = rs;
            }
            else
                response.Entity = user;
            var deviceResult = deviceService.GetAllLicense(customerId, model.email);
            if (!deviceResult.Success)
                throw new Exception(deviceResult.Message);
            response.Success = true;
            response.Count = 1;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }
        return response;
    }

}