using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Authentication
{
    public class Countries
    {
        // Membuat Tabel Countries
        public string Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }

        //GETALL 
        public static List<Countries> GetAllCountries()
        {
            List<Countries> countries = new List<Countries>();
            try
            {
                //Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = Connection.connection;
                command.CommandText = "SELECT * from tb_m_countries";

                //Membuat koneksi    
                Connection.connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var countr = new Countries();
                        countr.Id = reader.GetString(0);
                        countr.Name = reader.GetString(1);
                        countr.RegionId = reader.GetInt32(2);

                        countries.Add(countr);
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
            Connection.connection.Close();
            return countries;
        }
    }
}
