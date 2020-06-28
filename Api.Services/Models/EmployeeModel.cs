namespace Api.Services.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public AddressModel Address { get; set; }
    }
}
