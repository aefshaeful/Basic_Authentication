using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace Basic_Authentication
{
    internal class DokUser
    {
        public string Create(List<User> users, User user)
        {
            if (new AuthenticationManager().UserAuth(users, user.UserName))
                return this.Success(nameof(Create), "Username");
            users.Add(user);
            return this.Success("Created");
        }

        public string Edit(List<User> users, User user, int id)
        {
            users[id - 1].FirstName = user.FirstName;
            users[id - 1].LastName = user.LastName;
            users[id - 1].UserName = user.FirstName.Substring(0, 2) + user.LastName.Substring(0, 2);
            users[id - 1].Password = user.Password;
            return this.Success("Edited");
        }

        public string Delete(List<User> users, int id)
        {
            if (id > users.Count)
                return this.NotFound();
            users.RemoveAt(id - 1);
            return this.Success("Deleted");
        }

        public void View(List<User> Users)
        {
            int num = 0;
            foreach (User user in Users)
            {
                ++num;
                Console.WriteLine("========================");
                DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(5, 1);
                interpolatedStringHandler.AppendLiteral("ID\t: ");
                interpolatedStringHandler.AppendFormatted<int>(num);
                Console.WriteLine(interpolatedStringHandler.ToStringAndClear());
                Console.WriteLine("========================");
                Console.WriteLine("Name\t: " + user.FirstName + " " + user.LastName);
                Console.WriteLine("Username: " + user.UserName);
                Console.WriteLine("Password: " + user.Password);
                Console.WriteLine("========================");
            }
        }

        private string NotFound() => "User Not Found!!!";

        private string Success(string value) => "\n User Success to " + value + "!!! \n Press Enter to Continue";

        private string Success(string value, string error) => value + " failure," + error + " already exists!!!";
    }
}