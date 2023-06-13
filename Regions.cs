using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Basic_Authentication
{
    public class Regions
    {
        // Membuat Kelas Tabel Region
        public int Id { get; set; }
        public string? Name { get; set; }
        

        //GETALL (Memanggil Tabel)
        public static List<Regions> GetAllRegion()
        {
            //var region = new List<Regions>();
            List<Regions> region = new List<Regions>();
            try
            {

                //Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = Connection.connection;
                command.CommandText = "SELECT * from tb_m_regions";

                //Membuat koneksi    
                Connection.connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var reg = new Regions();
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
            Connection.connection.Close();
            return region;
        }

        // Menambahkan Data Pada Tabel
        public static int insertRegion(string name)
        {
            int result = 0;
            Connection.connection.Open();

            SqlTransaction transaction = Connection.connection.BeginTransaction();
            try
            {
                // membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = Connection.connection;
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
            Connection.connection.Close();
            return result;
        }
    }
}
