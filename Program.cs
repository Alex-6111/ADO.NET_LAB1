using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_LAB1
{
    internal class Program
    {
        static string connectionString = @"Data Source=WIN-KT8KRQ87C7Q\SQLEXPRESS;Initial Catalog=Rewards;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static void Main(string[] args)
        {

        }

        public static void Problem2()
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                try
                {
                    connect.Open();
                    Console.WriteLine($"Server Name: {connect.DataSource}");
                    Console.WriteLine($"DataBase Name: {connect.Database}");
                    Console.WriteLine($"ServerVersion: {connect.ServerVersion}");
                    Console.WriteLine($"Connection State: {connect.State}");
                    Console.WriteLine("\nConnected!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    connect?.Close();
                }
            }
            Console.WriteLine("\n\n\n");
        }

        public static void Problem3()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
               

                    cmd.CommandText = "SELECT * FROM Rewards";  
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    Console.WriteLine($"{sqlDataReader.GetName(0)}\t{sqlDataReader.GetName(1),30}\t{sqlDataReader.GetName(2),30}\t{sqlDataReader.GetName(3),30}\t{sqlDataReader.GetName(4),30}\t{sqlDataReader.GetName(5),30}");
                    while (sqlDataReader.Read())
                    {
                        Console.WriteLine($"{sqlDataReader.GetValue(0)}\t{sqlDataReader.GetValue(1),30}\t{sqlDataReader.GetValue(2),30}\t{sqlDataReader.GetValue(3),30}\t{sqlDataReader.GetValue(4),30}\t{sqlDataReader.GetValue(5),30}");
                    }
                    Console.WriteLine("\n");
                    sqlDataReader.Close();


                    cmd.CommandText = "SELECT FullName AS FIO FROM Rewards";  
                    sqlDataReader = cmd.ExecuteReader();
                    Console.WriteLine($"{sqlDataReader.GetName(0)}");
                    while (sqlDataReader.Read())
                    {
                        Console.WriteLine($"{sqlDataReader.GetValue(0)}");
                    }
                    Console.WriteLine("\n");
                    sqlDataReader.Close();

                    cmd.CommandText = "SELECT AverageGradesForYears AS 'Average' FROM Rewards";  
                    sqlDataReader = cmd.ExecuteReader();
                    Console.WriteLine($"{sqlDataReader.GetName(0)}");
                    while (sqlDataReader.Read())
                    {
                        Console.WriteLine($"{sqlDataReader.GetValue(0)}");
                    }
                    Console.WriteLine("\n");
                    sqlDataReader.Close();

                    cmd.CommandText = "SELECT AverageGradesForYears AS 'Average', FullName AS FIO FROM Rewards" +
                        "WHERE AverageGradesForYears > 9"; 
                    sqlDataReader = cmd.ExecuteReader();
                    Console.WriteLine($"{sqlDataReader.GetName(0)}{sqlDataReader.GetName(1),30}");
                    while (sqlDataReader.Read())
                    {
                        Console.WriteLine($"{sqlDataReader.GetValue(0)}{sqlDataReader.GetValue(1),30}");
                    }
                    Console.WriteLine("\n");
                    sqlDataReader.Close();
         
                    cmd.CommandText = "SELECT DISTINCT NameOfMinAVGGradesSubject FROM Rewards";
                    sqlDataReader = cmd.ExecuteReader();
                    Console.WriteLine($"{sqlDataReader.GetName(0)}");
                    while (sqlDataReader.Read())
                    {
                        Console.WriteLine($"{sqlDataReader.GetValue(0)}");
                    }
                    Console.WriteLine("\n");
                    sqlDataReader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    conn?.Close();
                }
            }
            Console.WriteLine("\n\n\n");
        }

        public static void Problem4()
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    cmd.CommandText = "SELECT MIN(AverageGradesForYears) FROM Rewards";  
                    object minGrades = cmd.ExecuteScalar();
                    Console.WriteLine($"Min average reward: {minGrades}");
                    Console.WriteLine("\n");

                    cmd.CommandText = "SELECT MAX(AverageGradesForYears) FROM Rewards";  
                    object maxGrades = cmd.ExecuteScalar();
                    Console.WriteLine($"Max average reward: {maxGrades}");
                    Console.WriteLine("\n");
                   
                    cmd.CommandText = "SELECT COUNT(Rewards.Id) FROM Rewards WHERE Rewards.NameOfMinAVGGradesSubject = 'Math'";
                    object mathematicsLowStudents = cmd.ExecuteScalar();
                    Console.WriteLine($"Number of students with the lowest average grade in math: {mathematicsLowStudents}");
                    Console.WriteLine("\n");
                    
                    cmd.CommandText = "SELECT COUNT(Rewards.Id) FROM Rewards WHERE Rewards.NameOfMaxAVGGradesSubject = 'Math'";
                    object mathematicsHightStudents = cmd.ExecuteScalar();
                    Console.WriteLine($"Number of students with the highest average grade in math: {mathematicsHightStudents}");
                    Console.WriteLine("\n");

                    cmd.CommandText = "SELECT COUNT(Rewards.Id) FROM Rewards WHERE Rewards.GroupName = 'Группа 5'";
                    object gr5studentsCount = cmd.ExecuteScalar();
                    cmd.CommandText = "SELECT COUNT(Rewards.Id) FROM Rewards WHERE Rewards.GroupName = 'Группа 7'";
                    object gr7studentsCount = cmd.ExecuteScalar();
                    cmd.CommandText = "SELECT COUNT(Rewards.Id) FROM Rewards WHERE Rewards.GroupName = 'Группа 3'";
                    object gr3studentsCount = cmd.ExecuteScalar();
                    Console.WriteLine($"Group M11 - {gr5studentsCount} peoples, Group M12 - {gr7studentsCount} peoples, Group A11 - {gr3studentsCount} peoples");
                    Console.WriteLine("\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    conn?.Close();
                }
            }
            Console.WriteLine("\n\n\n");
        
        }

    }
}
