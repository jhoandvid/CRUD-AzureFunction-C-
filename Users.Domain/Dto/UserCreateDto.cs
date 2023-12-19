namespace Users.Domain.Dto
{
    public class UserCreateDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Document { get; set; }
    }
}
