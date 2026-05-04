namespace server.Models
{
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public int UserId { get; set; }
    }
}
