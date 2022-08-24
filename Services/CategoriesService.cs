public class CategoriesService
{
    private readonly IRepository<Categories> _categoriesRepository;

    public CategoriesService(IRepository<Categories> categoriesRepository)
    {
        _categoriesRepository = categoriesRepository;
    }

    public IServiceResponse<Categories> AddOrUpdate(int masterUserId, IEnumerable<BaseModel> categories)
    {
        var response = new ServiceResponse<Categories>();
        var date = DateTime.UtcNow;
        try
        {
            var sambaIds = categories.Select(p => p.sambaId);
            var updateCategory = _categoriesRepository.Table.Where(s => s.masterUserId == masterUserId && sambaIds.Contains(s.sambaId));
            foreach (var item in updateCategory)
            {
                var dummy = categories.Where(s => s.sambaId == item.sambaId).FirstOrDefault();
                item.sambaName = dummy.sambaName;
                item.updatedAt = date;
            }
            var insertCategory = categories.Where(s => !updateCategory.Select(p => p.sambaId).Contains(s.sambaId))
            .Select(p => new Categories()
            {
                sambaName = p.sambaName,
                displayName = p.displayName,
                sambaId = p.sambaId,
                sortOrder = p.sortOrder,
                isActive = true,
                createdAt = date,
                updatedAt = date,
                masterUserId = masterUserId
            });
            var updateResult = _categoriesRepository.Update(updateCategory);
            var insertResult = _categoriesRepository.Insert(insertCategory);
            var list = new List<Categories>();
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