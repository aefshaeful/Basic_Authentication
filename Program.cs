using Basic_Authentication;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace Basic_Authentication
{
    public class Program
    {
        private static void Main(string[] args)
        {
            /*//Check Connection
            SqlConnection connection;
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


            ////////////////////////GETALL TABLE///////////////////////////


            //GETALL : REGION (Select Tabel Regions)
            /*List<Regions> regions = Regions.GetAllRegion();
            foreach (Regions region in regions)
            {
                Console.WriteLine($"id: {region.Id} Name: {region.Name}");
            }*/


            //GETALL : COUNTRIES
            /*List<Countries> count = Countries.GetAllCountries();
            foreach (Countries countries in count)
            {
                Console.WriteLine($"Id: {countries.Id} Name: {countries.Name} RegionId: {countries.RegionId}");
            }*/


            //GETALL : LOCATIONS
            /*List<Locations> loc = Locations.GetAllLocations();
            foreach (Locations locations in loc)
            {
                Console.WriteLine($"Id: {locations.Id} StreetAddress: {locations.StreetAddress} PostalCode: {locations.PostalCode} City: {locations.City} StateProvince: {locations.StateProvince} CountryId: {locations.CountryId}");
            }*/


            //GETALL : DEPARTMENTS
            /* List<Departments> dp = Departments.GetAllDepartments();
             foreach (Departments departments in dp)
             {
                 Console.WriteLine($"Id: {departments.Id} Name: {departments.Name} Location_Id: {departments.Location_Id} Manager_Id: {departments.Manager_Id}");
             }*/


            //GETALL : EMPLOYEES
            /* List<Employees> employ = Employees.GetAllEmployees();
             foreach (Employees employees in employ)
             {
                 Console.WriteLine($"Id: {employees.Id} Firsh_Name: {employees.Firsh_Name} Last_Name: {employees.Last_Name} Email: {employees.Email} Phone_Number: {employees.Phone_Number} Hire_Date: {employees.Hire_Date} Salary: {employees.Salary} Commision_Pct: {employees.Commision_Pct} Manager_Id: {employees.Manager_Id} Job_Id: {employees.Job_Id} Department_Id: {employees.Department_Id}");
             }*/


            //GETALL : HISTORIES
            /* List<Histories> hist = Histories.GetAllHistories();
             foreach (Histories histories in hist)
             {
                 Console.WriteLine($"Start_Date: {histories.Start_Date} Employee_Id: {histories.Employee_Id} End_Date: {histories.End_Date} Department_Id: {histories.Department_Id} Job_Id; {histories.Job_Id}");
             }*/


            //GETALL : JOBS
            /* List<Jobs> jobb = Jobs.GetAllJobs();
             foreach (Jobs jobs in jobb)
             {
                 Console.WriteLine($"Id: {jobs.Id}, Title: {jobs.Title}, Min_Salary: {jobs.Min_Salary}, Max_Salary: {jobs.Max_Salary}");
             }*/



            ////////////////////////INSERT TABLE///////////////////////////



            // INSERT REGIONS (Insert Tabel Regions)
            /* Console.WriteLine("== \tInsert To Table\t  ==");
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
             }*/


            // INSERT COUNTRIES (Insert Tabel Regions)
            /*Console.WriteLine("== \tInsert To Table\t  ==");
            Console.Write("Masukkan id countries : ");
            string id = Console.ReadLine();
            Console.Write("Masukkan nama countries :");
            string name = Console.ReadLine();
            Console.Write("Masukkan id region : ");
            int region_id = int.Parse(Console.ReadLine());
            int isInsertSuccessful = Countries.insertCountries(id, name, region_id);
            if (isInsertSuccessful > 0)
            {
                Console.WriteLine("Add Data Success");
            }
            else
            {
                Console.WriteLine("Add Data Invalid");
            }*/



            ////////////////////////GETBY ID TABLE///////////////////////////



            //GetRegionById
            /*Console.WriteLine("== \tGet Region by ID\t ==");
            Console.Write("Masukkan id region: ");
            int id = int.Parse(Console.ReadLine());
            List<Regions> regions = Regions.GetRegionsById(id);
            foreach (Regions region in regions)
            {
                Console.WriteLine($"Id: {region.Id} Name: {region.Name}");
            }*/


            //GetCountiesById
            /* Console.WriteLine("== \tGet Countries by ID\t ==");
             Console.Write("Masukkan id countries: ");
             string id = Console.ReadLine();
             List<Countries> count = Countries.GetCountriesById(id);
             foreach (Countries countries in count)
             {
                 Console.WriteLine($"Id: {countries.Id}, Name: {countries.Name}, RegionId: {countries.RegionId}");
             }*/



            ////////////////////////UPDATE TABLE///////////////////////////



            //UPDATE TABLE REGIONS
            /*Console.WriteLine("== \tUpdate Table Regions\t ==");
            Console.Write("Masukkan id region : ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Masukkan nama region yang di update : ");
            string newname = Console.ReadLine();
            int isUpdateSuccessful = Regions.UpdateRegionsName(id, newname);
            if (isUpdateSuccessful > 0)
            {
                Console.WriteLine("Update Successful!");
            }
            else
            {
                Console.WriteLine("Update Failed");
            }*/


            //UPDATE TABLE COUNTRIES
            /*Console.WriteLine("== \tUpdate Table Countries\t ==");
            Console.Write("Masukkan id countries : ");
            string id = Console.ReadLine();
            Console.Write("Masukkan nama countries yang di update : ");
            string newname = Console.ReadLine();
            Console.Write("Masukkan id region : ");
            int region_id = int.Parse(Console.ReadLine());
            int isUpdateSuccessful = Countries.UpdateCountriesName(id, newname, region_id);
            if (isUpdateSuccessful > 0)
            {
                Console.WriteLine("Update Successful!");
            }
            else
            {
                Console.WriteLine("Update Failed");
            }*/


            ////////////////////////DELETE TABLE///////////////////////////


            // DELETE TABLE REGIONS
            /*Console.WriteLine("== \tDelete Table Regions\t ==");
            Console.Write("Masukkan id region yang di delete : ");
            int id = int.Parse(Console.ReadLine());
            int isDeleteSuccessful = Regions.DeleteRegionsName(id);
            if (isDeleteSuccessful > 0)
            {
                Console.WriteLine("Delete Successful!");
            }
            else
            {
                Console.WriteLine("Delete Failed");
            }*/

            // DELETE TABLE COUNTRIES
           /* Console.WriteLine("== \tDelete Table Countries\t ==");
            Console.Write("Masukkan id countries yang di delete : ");
            string id = Console.ReadLine();
            int isDeleteSuccessful = Countries.DeleteCountriesName(id);
            if (isDeleteSuccessful > 0)
            {
                Console.WriteLine("Delete Successful!");
            }
            else
            {
                Console.WriteLine("Delete Failed");
            }*/
        }
    }
}