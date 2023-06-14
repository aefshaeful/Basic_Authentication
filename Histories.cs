using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Authentication
{
    internal class Histories
    {
        // MEMBUAT TABLE Employees
        public DateTime Start_Date { get; set; }
        public int Employee_Id { get; set; }
        public DateTime End_Date { get; set; }
        public int Department_Id { get; set; }
        public string Job_Id { get; set; }


        // GETALL (SELECT)
        public static List<Histories> GetAllHistories()
        {
            var histories = new List<Histories>();
            //List<Regions> region = new List<Regions>();
            try
            {
                // MEMBUAT INSTANCE UNTUK COMMAND 
                SqlCommand command = new SqlCommand();
                command.Connection = Connection.connection;
                command.CommandText = "SELECT * from tb_tr_histories";

                // MEMBUAT KONEKSI    
                Connection.connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var his = new Histories();
                        his.Start_Date = reader.GetDateTime(0);
                        his.Employee_Id= reader.GetInt32(1);
                        his.End_Date = reader.GetDateTime(2);
                        his.Department_Id = reader.GetInt32(3);
                        his.Job_Id = reader.GetString(4);

                        histories.Add(his);
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
            return histories;
        }
    }
}
