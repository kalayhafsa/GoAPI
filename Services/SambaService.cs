using System.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public class SambaService
{
    private readonly IRepository<Categories> _categoriesRepository;
    private readonly IRepository<MasterUsers> _masterUsersRepository;
    private readonly IRepository<Products> _productsRepository;
    public SambaService(IRepository<Categories> categoriesRepository,
     IRepository<MasterUsers> masterUsersRepository, IRepository<Products> productsRepository)
    {
        _categoriesRepository = categoriesRepository;
        _masterUsersRepository = masterUsersRepository;
        _productsRepository = productsRepository;
    }

    public IServiceResponse<dynamic> SendData(string userName, string type, IFormFile file)
    {
        var response = new ServiceResponse<dynamic>();
        var categoryService = new CategoriesService(_categoriesRepository);
        var productService = new ProductsService(_productsRepository);
        try
        {
            var user = _masterUsersRepository.Table.Select(s => new { id = s.id, email = s.email }).FirstOrDefault(s => s.email == userName);
            if (user == null)
                throw new Exception("No registered user found with this email");
            string fileContent = null;
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                fileContent = reader.ReadToEnd();
            }
            if (type == "Menu")
            {
                var result = JsonConvert.DeserializeObject<SambaMenuResponse>(fileContent);
                var categories = result.Categories.Select(p => new BaseModel
                {
                    sambaId = p.Id,
                    sambaName = p.Name,
                    displayName = p.Header,
                    sortOrder = p.SortOrder
                });
                var categoriesResult = categoryService.AddOrUpdate(user.id, categories);
                if (!categoriesResult.Success)
                    throw new Exception(categoriesResult.Message);
                var sambaproducts = result.Categories.SelectMany(p => p.ScreenMenuItems);
                var products = new List<ProductBaseModel>();
                foreach (var item in sambaproducts)
                {
                    var dbCategory = categoriesResult.List.Where(s => s.sambaId == item.ScreenMenuCategoryId).FirstOrDefault();
                    var prod = new ProductBaseModel();
                    prod.sambaId = item.Id;
                    prod.sambaName = item.Name;
                    prod.displayName = item.Header;
                    prod.sortOrder = item.SortOrder;
                    prod.categoryId = dbCategory.id;
                    products.Add(prod);
                }
                var productResult = productService.AddOrUpdate(user.id, products);
                if (!productResult.Success)
                    throw new Exception(productResult.Message);
                var res = Newtonsoft.Json.JsonConvert.SerializeObject(productResult.List);
                response.List = JsonConvert.DeserializeObject<IEnumerable<ExpandoObject>>(res, new ExpandoObjectConverter());
                response.Success = true;
            }
            else if (type == "OrderTags")
            {
                response.Success = true;
            }
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }
        return response;
    }



}