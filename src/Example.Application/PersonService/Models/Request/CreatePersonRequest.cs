namespace Example.Application.PersonService.Models.Request
{
    public class CreatePersonRequest
    {
        public string Name { get; set; }
        public string DocumentNumber { get; set; }
        public int Age { get; set; }
        public int IdCity { get; set; }
    }
}
