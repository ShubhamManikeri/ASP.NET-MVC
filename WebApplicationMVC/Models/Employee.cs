using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Security.Cryptography;

namespace WebApplicationMVC.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "Employee Number is required")]
        [Display(Name = "Employee Number")]
        public int EmpNo { get; set; }

        [Required(ErrorMessage = "Employee Name is required")]
        [StringLength(10,ErrorMessage = "Name cannot be longer than 10 characters")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Basics is required")]
        [Range(1000, 10000000, ErrorMessage = "Basic must be between 1000 and 10000000")]
        public double Basic { get; set; }


        [Required(ErrorMessage = "Department Number is required")]
        [AllowedValues("10,20,30", ErrorMessage = "Department Number must be 10, 20, or 30")]
        public int DeptNo { get; set; }


      

            public static Employee GetEmpById(int EmpNo)
            {
                SqlConnection conn = new SqlConnection();

                conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;";

                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "GetEmployeeWithEmpNo";
                    cmd.Parameters.AddWithValue("@EmpNo", EmpNo);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows && dr.Read())
                    {
                        return new Employee
                        {
                            EmpNo = Convert.ToInt32(dr["EmpNo"]),
                            Name = dr["Name"].ToString(),
                            Basic = Convert.ToDouble(dr["Basic"]),
                            DeptNo = Convert.ToInt32(dr["DeptNo"])
                        };
                    Console.WriteLine("Employee Number      : " + dr["EmpNo"]);
                        Console.WriteLine("Employee Name        : " + dr["Name"]);
                        Console.WriteLine("Employee Basic       : " + dr["Basic"]);
                        Console.WriteLine("Employee Department  : " + dr["DeptNo"]);
                    }
                    else
                    {
                        Console.WriteLine("No Employee Found With Employee Number : " + EmpNo);
                        return null;
                }
                    //Console.WriteLine("Jai Shree Ram");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                return null;
            }
                finally
                {
                    conn.Close();
                }
            }

            static void DeleteWithEmpNo(int EmpNo)
            {
                SqlConnection conn = new SqlConnection();

                conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;";

                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "DeleteEmployeeWithEmpNo";
                    cmd.Parameters.AddWithValue("@EmpNo", EmpNo);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Employee Deleted With Employee Number : " + EmpNo);
                    }
                    else
                    {
                        Console.WriteLine("No Employee Found With Employee Number : " + EmpNo);
                    }
                    //Console.WriteLine("Jai Shree Ram");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            
            public static List<Employee> GetAllEmployee()
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;";
                List<Employee> empList = new List<Employee>();
            try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "select * from Employees";

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        empList.Add(new Employee
                        {
                            EmpNo = Convert.ToInt32(dr["EmpNo"]),
                            Name = dr["Name"].ToString(),
                            Basic = Convert.ToDouble(dr["Basic"]),
                            DeptNo = Convert.ToInt32(dr["DeptNo"])
                        });
                    }

                    dr.Close();
                return empList;

            }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                return empList;
            }
                finally
                {
                    conn.Close();
                
            }
            }
        public static void Insert(Employee emp)
        {
            Console.WriteLine("dwdwd");
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;";
            List<Employee> empList = new List<Employee>();
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "InsertEmployee";
                cmd.Parameters.AddWithValue("@EmpNo", emp.EmpNo);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Basic", emp.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", emp.DeptNo);

                cmd.ExecuteNonQuery();

                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();

            }
        }


            

            
       
    
}
}
