using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Basic_Authentication
{
    internal class ViewMenu
    {
        private bool MenuLogin = false;

        private DokUser dokuser = new DokUser();
        public List<User> Users = new List<User>();

        static string HideCharacterInput()
        {
            string input = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    input += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input = input.Substring(0, input.Length - 1);
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Console.Write(" ");
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                }
            } while (key.Key != ConsoleKey.Enter);

            return input;
        }

        public void App()
        {
            //Console.Clear();
            /*foreach (var item in Users)
            {
                Console.WriteLine(item.UserName);
                Console.WriteLine(item.IsAdmin);
            }*/
            Console.WriteLine("=== \tUSER AUTHENTICATION\t===");
            Console.WriteLine("1. Login");
            /* if (MenuLogin)
             {
                 Console.WriteLine("2. Show User");
                 Console.WriteLine("3. Search User");
             }*/
            //Console.WriteLine("2. Create User");
            Console.WriteLine("2. Exit");
            Console.Write("Please choose a menu : ");
            int inputlogin = Convert.ToInt32(Console.ReadLine());
            try
            {
                switch (inputlogin)
                {
                    case 1:
                        this.Login(this.Users);
                        break;
                    case 2:
                        Environment.Exit(1);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : Input Not Valid");
                Console.ReadKey();
                this.App();
            }
        }

        public void Login(List<User> listUser)
        {
            AuthenticationManager auth = new AuthenticationManager();
            Console.Clear();
            Console.WriteLine("==LOGIN==");
            Console.Write("Username : ");
            string str1 = Console.ReadLine() ?? "";
            Console.Write("Password : ");
            string str2 = Console.ReadLine() ?? "";
            List<User> listUser1 = listUser;
            string namaUser = str1;
            string kataSandi = str2;

            if (auth.Authentication(listUser1, namaUser, kataSandi))
            {
                //this.MenuLogin = true;
                User user;
                Console.WriteLine("=== \tLogin Success!\t ===");
                Console.WriteLine("Press enter to continue...");
                Console.ReadKey();
                foreach (var item in listUser)
                {
                    Console.WriteLine(item.UserName);
                    Console.WriteLine(item.IsAdmin);
                    if (item.UserName ==  namaUser)
                    {
                        user = item;
                        if (user.IsAdmin == true)
                        {
                            this.UserManagementView(listUser);
                            break;
                        }
                        else
                        {
                            CheckGanjilGenap();
                            break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Username or Password Not Valid!!");
                Console.ReadKey();
                this.App();
            }
        }

        public void UserManagementView(List<User> listUserAdmin)
        {
            Console.Clear();
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Show User");
            Console.WriteLine("3. Search User");
            Console.WriteLine("4. Logout");
            Console.WriteLine("Please choose a menu : ");
            int IsAdmin = Convert.ToInt32(Console.ReadLine());
            try
            {
                switch (IsAdmin)
                {
                    case 1:
                        this.Create(this.Users);
                        break;
                    case 2:
                        this.ShowUser(this.Users);
                        break;
                    case 3:
                        this.Search(this.Users);
                        break;
                    case 4:
                        this.Logout("logout");
                        break;
                }
            }
            catch (Exception ex)
            { 
                Console.WriteLine("ERROR : Input Not Valid");
                Console.ReadKey();
                this.UserManagementView(Users);
            }
        }

        public static void CheckGanjilGenap()
        {
            Console.Clear();
            Console.WriteLine("=======================================================");
            Console.WriteLine("Menu Ganjil Genap");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("1. Cek angka ganjil atau genap");
            Console.WriteLine("2. Print angka ganjil atau genap (dengan batas limit)");
            Console.WriteLine("3. Exit");
            Console.WriteLine("4. Logout");
            Console.WriteLine("-------------------------------------------------------");
            Console.Write("Masukkan pilihan Anda (1-3) : ");
            int Input = Convert.ToInt32(Console.ReadLine());
            try
            {
                switch (Input)
                {
                    case 1:
                        Console.Write("Masukkan angka yang ingin di cek : ");
                        int number = int.Parse(Console.ReadLine());
                        string result = MenuGanjilGenap.EvenOddCheck(number);
                        Console.WriteLine(result);
                        break;
                    case 2:
                        Console.Write("Masukkan limit : ");
                        int limit = int.Parse(Console.ReadLine());
                        Console.Write("Pilih (ganjil/genap): ");
                        string choice = Console.ReadLine().ToLower();
                        if (choice == "ganjil")
                            MenuGanjilGenap.PrintEvenOdd(limit, "ganjil");
                        else if (choice == "genap")
                            MenuGanjilGenap.PrintEvenOdd(limit, "genap");
                        else
                            Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
                        break;
                    case 3:
                        Console.WriteLine("Program Telah Berakhir...");
                        break;
                    case 4:
                        ViewMenu logout = new ViewMenu();
                        logout.Logout("logout");
                        //this.Logout("logout");
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : Input Not Valid");
                Console.ReadKey();
            }
        }

        public void Create(List<User> listUser)
        {
                AuthenticationManager auth = new AuthenticationManager();
                Console.Clear();
                Console.Write("First Name: ");
                string firstName = auth.NameAuth(Console.ReadLine());
                Console.Write("Last Name: ");
                string lastName = auth.NameAuth(Console.ReadLine());
                Console.Write("Are You Admin (yes/no) ?");
                string IsAdmin = Console.ReadLine();
                Console.Write("Password: ");
                string password = HideCharacterInput();
                //string password = auth.PasswordAuth(Console.ReadLine());
                User user = new User(firstName, lastName, password, IsAdmin);
                Console.WriteLine(this.dokuser.Create(listUser, user));
                Console.ReadKey();
                this.UserManagementView(listUser);
        }

        private void ShowUser(List<User> users)
        {
            User user = new User();
            Console.Clear();
            Console.WriteLine("==SHOW USER==");
            this.dokuser.View(users);
            Console.WriteLine("\nMenu");
            Console.WriteLine("1. Edit User");
            Console.WriteLine("2. Delete User");
            Console.WriteLine("3. Back");
            Console.Write("Please select a menu : ");
            Console.WriteLine("Press enter to continue...");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    this.EditUser(users, user);
                    break;
                case 2:
                    this.DeleteUser(users);
                    break;
                case 3:
                    this.App();
                    break;
                default:
                    Console.WriteLine("ERROR : Input Not Valid");
                    Console.ReadKey();
                    this.ShowUser(users);
                    break;
            }
        }

        private void EditUser(List<User> users, User user)
        {
            if (this.MenuLogin)
            {
                bool flag;
                do
                {
                    Console.Write("Id Yang Ingin Diubah : ");
                    int int32 = Convert.ToInt32(Console.ReadLine());
                    if (int32 <= users.Count)
                    {
                        Console.Write("First Name : ");
                        user.FirstName = Console.ReadLine();
                        Console.Write("Last Name : ");
                        user.LastName = Console.ReadLine();
                        Console.Write("Password : ");
                        user.Password = Console.ReadLine();
                        Console.WriteLine(this.dokuser.Edit(users, user, int32));
                        flag = false;
                    }
                    else
                    {
                        Console.WriteLine("User Tidak Ditemukan!!!");
                        flag = true;
                    }
                }
                while (flag);
                Console.ReadKey();
                this.ShowUser(users);
            }
            else
            {
                Console.WriteLine("Can't create user, login required!");
                Console.WriteLine("Press enter to continue...");
                Console.ReadKey();
                this.App();
            }
        }

        private void DeleteUser(List<User> users)
        {
            Console.Write("Id Yang Ingin Dihapus : ");
            int int32 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(this.dokuser.Delete(users, int32));
            Console.ReadKey();
            this.ShowUser(users);
        }

        private void Search(List<User> Users)
        {
            List<User> userList = new List<User>();
            Console.Clear();
            Console.WriteLine("==Cari Akun==");
            Console.Write("Masukan Nama : ");
            string name = Console.ReadLine();
            this.dokuser.View(Users.Where<User>((Func<User, bool>)(i => i.FirstName.ToLower().Contains(name.ToLower()) || i.LastName.ToLower().Contains(name.ToLower()))).Select<User, User>((Func<User, User>)(g => new User()
            {
                FirstName = g.FirstName,
                LastName = g.LastName,
                UserName = g.UserName,
                Password = g.Password
            })).ToList<User>());
            Console.ReadKey();
            this.App();
        }

        public void Logout()
        {
            Console.WriteLine("Thank You!!");
            Environment.Exit(1);
        }

        public void Logout(string logout)
        {
            Console.WriteLine("== \tThank You for Using App\t ==");
            Console.ReadKey();
            this.App();
        }

    }
}