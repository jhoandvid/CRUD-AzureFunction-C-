namespace Users.Domain.Dto
{
    public class UserUpdateDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Document { get; set; }
    }
}
