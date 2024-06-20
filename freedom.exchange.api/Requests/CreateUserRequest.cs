namespace freedom.exchange.api.Dto
{
    public class CreateUserRequest
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
