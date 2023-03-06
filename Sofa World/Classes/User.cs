using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_World.Classes
{
    public class User
    {
        public int UserID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public User(int userID, string surname, string name, string patronymic, string login, string password, string role)
        {
            this.UserID = userID;
            this.Surname = surname;
            this.Name = name;
            this.Patronymic = patronymic;
            this.Login = login;
            this.Password = password;
            this.Role = role;
        }
    }
}
