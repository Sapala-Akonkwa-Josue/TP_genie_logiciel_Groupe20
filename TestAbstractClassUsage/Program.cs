using AbstractClassUsage;
using SingletonLibrary;
using System;
using System.Data;

namespace TestAbstractClassUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Person e1 = new Employee();
                e1.Id = 1;
                e1.FirstName = "Sapala";
                e1.LastName = "Sadock";
                ((Employee)e1).Cnss = "fsdfsdf9";

                // insert Employee 1 into the database
                e1.Add(e1);
                Console.WriteLine("Employee  enregistrer avec succes!!");

                Person e2 = new Employee();
                e2.Id = 2;
                e2.FirstName = "sapala";
                e2.LastName = "josue";
                ((Employee)e2).Cnss = "9dfgsTTrE";

                // Insert Employee 2 into the Database
                e2.Add(e2);
                Console.WriteLine("Employe enregistre avec succes!!!");

                // Students Insertion
                Person s1 = new Student(3, "saidi", "masudi", "54546MTCFE514");
                s1.Add(s1);
                Console.WriteLine("Etudiant enregistre avec succes!!!");

                Person s2 = new Student(4, "Shekinah", "Shati", "83843765TSREGF");
                s2.Add(s2);

                Console.WriteLine("Etudiant  enregistre  avec succes!!!");
                // Show inserted values for Employee
                //			e1.ShowIdentity();
                e1.ShowDynamicIdentity(e1.Id);
                Console.WriteLine("-----------------------------------------");
                //			e2.ShowIdentity();
                e2.ShowDynamicIdentity(e2.Id);
                Console.WriteLine("-----------------------------------------");

                // Show inserted values for Student
                s1.ShowDynamicIdentity(s1.Id);
                Console.WriteLine("------------------------------------------");
                s2.ShowDynamicIdentity(s2.Id);
                Console.WriteLine("-----------------------------------------");

               
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Console.WriteLine("Failed to insert records to the Database, " + ex.Message);
            }
            //catch (MySql.Data.MySqlClient.MySqlException ex)
            //{
            //    Console.WriteLine("Failed to insert records to the Database, " + ex.Message);
            //}
            catch (Exception ex)
            {
                Console.WriteLine("Failed to insert records to the Database, " + ex.Message);
            }
            finally
            {
                if (ConnectionFactory.getConnection(ConnectionType.MYSQL_CONNECTION) != null)
                {
                    if (ConnectionFactory.getConnection(ConnectionType.MYSQL_CONNECTION).State == ConnectionState.Open)
                        ConnectionFactory.getConnection(ConnectionType.MYSQL_CONNECTION).Close();
                }

                if (ConnectionFactory.getConnection(ConnectionType.SQL_SERVER_CONNECTION) != null)
                {
                    if (ConnectionFactory.getConnection(ConnectionType.SQL_SERVER_CONNECTION).State == ConnectionState.Open)
                        ConnectionFactory.getConnection(ConnectionType.SQL_SERVER_CONNECTION).Close();
                }
            }
            Console.ReadLine();
        }
    }
}
