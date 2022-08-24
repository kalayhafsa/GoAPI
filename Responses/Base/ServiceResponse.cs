[Serializable]
public class ServiceResponse<T> : IServiceResponse<T>
{
    public IEnumerable<T> List { get; set; }
    public T Entity { get; set; }
    public int Count { get; set; }
    public string Message { get; set; }
    public bool Success { get; set; }
}