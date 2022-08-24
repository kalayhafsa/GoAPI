public class ProductsService
{
    private readonly IRepository<Products> _productsRepository;

    public ProductsService(IRepository<Products> productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public IServiceResponse<Products> AddOrUpdate(int masterUserId, IEnumerable<ProductBaseModel> products)
    {
        var response = new ServiceResponse<Products>();
        var date = DateTime.UtcNow;
        try
        {
            var sambaIds = products.Select(p => p.sambaId);
            var updateProducts = _productsRepository.Table.Where(s => s.masterUserId == masterUserId && sambaIds.Contains(s.sambaId));
            foreach (var item in updateProducts)
            {
                var dummy = products.Where(s => s.sambaId == item.sambaId).FirstOrDefault();
                item.sambaName = dummy.sambaName;
                item.updatedAt = date;
            }
            var insertProducts = products.Where(s => !updateProducts.Select(p => p.sambaId).Contains(s.sambaId))
            .Select(p => new Products()
            {
                sambaName = p.sambaName,
                displayName = p.displayName,
                sambaId = p.sambaId,
                sortOrder = p.sortOrder,
                isActive = true,
                createdAt = date,
                updatedAt = date,
                categoryId = p.categoryId,
                masterUserId = masterUserId
            });
            var updateResult = _productsRepository.Update(updateProducts);
            var insertResult = _productsRepository.Insert(insertProducts);
            var list = new List<Products>();
            list.AddRange(insertResult);
            list.AddRange(updateResult);
            response.Success = true;
            response.List = list;
            response.Count = list.Count;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }
        return response;
    }


}