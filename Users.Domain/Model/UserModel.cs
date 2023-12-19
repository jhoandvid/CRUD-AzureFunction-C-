namespace Users.Domain.Model
{
    public class UserModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Document { get; set; }
    }
}
