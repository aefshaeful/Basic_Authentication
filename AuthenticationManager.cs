using System;
using System.Collections.Generic;
using System.Linq;


namespace Basic_Authentication
{
    internal class AuthenticationManager
    {
        public bool Authentication(List<User> listUser, string namaUser, string kataSandi)
        {
            bool flag = false;
            for (int index = 0; index < listUser.Count; ++index)
            {
                if (namaUser == listUser[index].UserName && kataSandi == listUser[index].Password)
                {
                    flag = true;
                    break;
                }
            }
            Console.Write("MESSAGE : ");
            return flag;
        }

        public string NameAuth(string nama)
        {
            bool flag = true;
            if (nama.Length < 2)
            {
                Console.WriteLine("\nName has to be at least consisting 2 characters or more.");
                Console.Write("Input : ");
                nama = Console.ReadLine() ?? "";
                flag = false;
                return nama;
            }
            flag = true;
            return nama;
        }

        public string PasswordAuth(string kataSandi)
        {
            bool flag;
            do
            {
                if (kataSandi.Length > 7 && kataSandi.Any<char>(new Func<char, bool>(char.IsUpper)) && kataSandi.Any<char>(new Func<char, bool>(char.IsLower)) && kataSandi.Any<char>(new Func<char, bool>(char.IsNumber)))
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("\nPassword must have at least 8 characters\n with at least one Capital letter, at least one lower case letter and at least one number.");
                    Console.Write("Password: ");
                    kataSandi = Console.ReadLine();
                    flag = true;
                }
            }
            while (flag);
            return kataSandi;
        }

        public bool UserAuth(List<User> users, string userName)
        {
            for (int index = 0; index < users.Count; ++index)
            {
                if (users[index].UserName == userName)
                    return true;
            }
            return false;
        }
    }
}