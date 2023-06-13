using Basic_Authentication;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace Basic_Authentication
{
    public class Program
    {
        private static void Main(string[] args)
        {
            /* //GETALL : REGION (Select Tabel Regions)
             List<Regions> regions = Regions.GetAllRegion();
             foreach (Regions region in regions)
             {
                 Console.WriteLine($"id: {region.Id} Name: {region.Name}");
             }*/

            /* //GETALL : COUNTRIES
             List<Countries> count = Countries.GetAllCountries();
             foreach (Countries countries in count)
             {
                 Console.WriteLine($"Id: {countries.Id} Name: {countries.Name} RegionId: {countries.RegionId}");
             }*/

            //GETALL : LOCATIONS
            /*  List<Locations> loc = Locations.GetAllLocations();
              foreach (Locations locations in loc)
              {
                  Console.WriteLine($"Id: {locations.Id} StreetAddress: {locations.StreetAddress} PostalCode: {locations.PostalCode} City: {locations.City} StateProvince: {locations.StateProvince} CountryId: {locations.CountryId}");
              }*/

            //InsertRegion (Insert Tabel Regions)
            Console.WriteLine("== \tInsert To Table\t  ==");
            Console.Write("Masukkan nama region :");
            string name = Console.ReadLine();
            int isInsertSuccessful = Regions.insertRegion(name);
            if (isInsertSuccessful > 0)
            {
                Console.WriteLine("Add Data Success");
            }
            else
            {
                Console.WriteLine("Add Data Invalid");
            }

            //Check Connection
/*            SqlConnection connection;
            connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                Console.WriteLine("Connected!");
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection Vailed!");
            }*/
        }
    }
}

        //GETALL (Memanggil Tabel)
 /*       static List<Region> GetAllRegion()
        {
            *//*string connectionString;
            connectionString = "Data Source=LAPTOP-8IGJNOSS;Database=db_hr;Integrated Security=True;Connect Timeout=30;";*//*

            var region = new List<Region>();
            try
            {

                //Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * from tb_m_regions";

                //Membuat koneksi    
                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var reg = new Region();
                        reg.Id = reader.GetInt32(0);
                        reg.Name = reader.GetString(1);

                        region.Add(reg);
                    }
                }
                else
                {
                    Console.WriteLine("Data Not Found!!");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            return region;
        }*/

        // Menambahkan Data Pada Tabel
/*        public static int insertRegion(string name)
        {
            int result = 0;
            connection = new SqlConnection(connectionString);

            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                // membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Insert Into tb_m_regions (name) VALUES (@region_name)";
                command.Transaction = transaction;

                //Membuat parameter
                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@region_name";
                pName.Value = name;
                pName.SqlDbType = SqlDbType.VarChar;

                // Menambahakan Parameter in Command
                command.Parameters.Add(pName);

                // Menjalankan Command
                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }
            connection.Close();
            return result;
        }
    }
*/              

            /*User user1 = new User("Aef", "Rohman", "Jakbar2023!", "yes");
            User user2 = new User("Maul", "Lana", "Jakbar2024!", "no");
            ViewMenu viewMenu = new ViewMenu();
            viewMenu.Users.Add(user1);
            viewMenu.Users.Add(user2);
            viewMenu.App();*/

//Getby ID
//Update
//Delete : Region : Countries

// Sisanya GettAll