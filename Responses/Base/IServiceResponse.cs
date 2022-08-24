public interface IServiceResponse<T>
{
    IEnumerable<T> List { get; set; }
    T Entity { get; set; }
    int Count { get; set; }
    bool Success { get; set; }
    string Message { get; set; }
}