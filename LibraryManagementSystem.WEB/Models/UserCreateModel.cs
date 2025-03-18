namespace LibraryManagementSystem.WEB.Models
{
    public class UserCreateModel
    {
        public UserCreateModel(string name, string email, DateTime birthDate)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; set; }

    }
}
