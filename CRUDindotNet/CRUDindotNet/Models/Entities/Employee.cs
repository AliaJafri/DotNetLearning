namespace CRUDindotNet.Models.Entities
{
    public class Employee
    {
        public int ID { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }  //? for nullable fields 

        public string? Salary { get; set; }
    }
}
