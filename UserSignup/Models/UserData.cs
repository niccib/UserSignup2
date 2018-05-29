using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserSignup.Models
{
    public class UserData
    {
        public static List<User> users { get; set; } = new List<User>();

        private UserData()
        {
            User one = new User()
            {
                Username = "gHopper",
                Password = "bugs",
                Email = "ghopper@gmail.com",
                FavColor = "navy blue"
            };
            User two = new User()
            {
                Username = "hLamar",
                Password = "bluetooth",
                Email = "hLamar@gmail.com",
                FavColor = "scarlett"
            };

            User three = new User()
            {
                Username = "aLovelace",
                Password = "program",
                Email = "aLovelace@gmail.com",
                FavColor = "royal blue"
            };
            users.Add(one);
            users.Add(two);
            users.Add(three);
        }

        private static UserData instance;

        public static UserData GetInstance()
        {
            if (instance == null)
            {
                instance = new UserData();
            }

            return instance;
        }

        public static void Add(User u)
        {
            users.Add(u);
        }

        public static List<User> GetAll()
        {
            return users;
        }

        public static User GetById(int id)
        {
            //lambda
            User user = users.Find(u => u.UserId == id);

            //what is going on
            //foreach(User user in users)
            //{
            //    if(user.UserId == id)
            //    {
            //        return user;
            //    }
            //}


            return user;
        }
    }
}
