namespace OrderIntegration.API
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public List<string> Warnings { get; set; } = new();
    }
}
