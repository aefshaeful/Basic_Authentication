using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
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


        // INSERT TABLE
        public static int insertCountries(string id, string name, int region_id)
        {
            int result = 0;
            Connection.connection.Open();

            SqlTransaction transaction = Connection.connection.BeginTransaction();
            try
            {
                // MEMBUAT INSTANCE UNTUK COMMAND 
                SqlCommand command = new SqlCommand();
                command.Connection = Connection.connection;
                command.CommandText = "Insert Into tb_m_countries (id, name, region_id) VALUES (@id, @name, @region_id)";
                command.Transaction = transaction;

                // MEMBUAT PARAMETER
                SqlParameter cId = new SqlParameter();
                cId.ParameterName = "@id";
                cId.Value = id;
                cId.SqlDbType = SqlDbType.VarChar;

                SqlParameter cName = new SqlParameter();
                cName.ParameterName = "@name";
                cName.Value = name;
                cName.SqlDbType = SqlDbType.VarChar;

                SqlParameter cRegionId = new SqlParameter();
                cRegionId.ParameterName = "@region_id";
                cRegionId.Value = region_id;
                cRegionId.SqlDbType = SqlDbType.Int;

                // MENAMBAHKAN PARAMETER DI COMMAND
                command.Parameters.Add(cId);
                command.Parameters.Add(cName);
                command.Parameters.Add(cRegionId);

                // MENJALANKAN COMMAND
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


        // GETBY ID
        public static List<Countries> GetCountriesById(string id)
        {
            var countries = new List<Countries>();
            try
            {
                // MEMBUAT KONEKSI      
                Connection.connection.Open();

                // MEMBUAT INSTANCE UNTUK COMMAND 
                SqlCommand command = new SqlCommand();
                command.Connection = Connection.connection;
                command.CommandText = "SELECT * from tb_m_countries WHERE id = @id";

                // MEMBUAT PARAMETER
                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                paramId.SqlDbType = SqlDbType.VarChar;

                // MENAMBAHKAN PARAMETER DI COMMAND
                command.Parameters.Add(paramId);

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var country = new Countries();
                        country.Id = reader.GetString(0);
                        country.Name = reader.GetString(1);
                        country.RegionId = reader.GetInt32(2);

                        countries.Add(country);
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


        // UPDATE TABLE
        public static int UpdateCountriesName(string id, string newname, int region_id)
        {
            int result = 0;
            Connection.connection.Open();

            SqlTransaction transaction = Connection.connection.BeginTransaction();
            try
            {
                // MEMBUAT INSTANCE UNTUK COMMAND 
                SqlCommand command = new SqlCommand();
                command.Connection = Connection.connection;
                command.CommandText = "UPDATE tb_m_countries SET id = @id, name = @newname, region_id = @region_id WHERE id = @id";
                command.Transaction = transaction;

                // MEMBUAT PARAMETER
                SqlParameter idparameter = new SqlParameter();
                idparameter.ParameterName = "@id";
                idparameter.Value = id;
                idparameter.SqlDbType = SqlDbType.VarChar;

                SqlParameter newName = new SqlParameter();
                newName.ParameterName = "@newname";
                newName.Value = newname;
                newName.SqlDbType = SqlDbType.VarChar;

                SqlParameter p_regionId = new SqlParameter();
                p_regionId.ParameterName = "@newname";
                p_regionId.Value = newname;
                p_regionId.SqlDbType = SqlDbType.Int;

                // MENAMBAHKAN PARAMETER DI COMMAND
                command.Parameters.Add(idparameter);
                command.Parameters.Add(newName);
                command.Parameters.Add(p_regionId);

                // MENJALANKAN COMMAND
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


        // DELETE TABLE
        public static int DeleteCountriesName(string id)
        {
            int result = 0;
            Connection.connection.Open();

            SqlTransaction transaction = Connection.connection.BeginTransaction();
            try
            {
                // MEMBUAT INSTANCE UNTUK COMMAND 
                SqlCommand command = new SqlCommand();
                command.Connection = Connection.connection;
                command.CommandText = "DELETE tb_m_countries WHERE id = @id";
                command.Transaction = transaction;

                // MEMBUAT PARAMETER
                SqlParameter counId = new SqlParameter();
                counId.ParameterName = "@id";
                counId.Value = id;
                counId.SqlDbType = SqlDbType.VarChar;

                // MENAMBAHKAN PARAMETER DI COMMAND
                command.Parameters.Add(counId);

                // MENJALANKAN COMMAND
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
