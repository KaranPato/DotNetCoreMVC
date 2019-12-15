namespace DotNetCoreMVC.API.ViewModels
{
    public class ResponseVM
    {
        public bool IsSuccess { get; set; }
        public object Content { get; set; }
        public string Message { get; set; }
        public long TotalCount { get; set; }
        public int StatusCode { get; set; }
    }
}