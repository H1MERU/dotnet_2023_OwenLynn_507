using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using Dapper;
using System.Windows.Forms;

namespace dotnet_06
{
    internal class SQLHelper
    {

        public static string connectionString = "DataSource=dotnet6.db;Version=3;FailIfMissing=True;";

        public void ConnectionClose() { }   

        public static string QueryGenerate() {
            return "SELECT * FROM Students";
        }
        
        public static string QuerySelectByIDGenerate(string id) {
            return $"SELECT * FROM Students WHERE StudentID = {id}";
        }        
        
        public static string QuerySelectByNameGenerate(string name) {
            return $"SELECT * FROM Students WHERE StudentName LIKE '%{name}%'";
            
        }       
        
        public static string QuerySelectByCIDGenerate(string cid) {
            return $"SELECT * FROM Students WHERE ClassID = {cid}";
        }    

        public static string QueryDeleteGenerate(string id) {
            return $"DELETE FROM Students WHERE StudentID = {id};";
        }

        public static string QueryInsertStudentGenerate(int id, string name, int cid)
        {
            return $"INSERT INTO Students (StudentID, StudentName, ClassID) VALUES  ({id}, '{name}', {cid})";
        }

        public static string QueryAlterGenerate(int id, string name, int cid)
        {
            return $"UPDATE Students SET StudentName = '{name}', ClassID = {cid} WHERE StudentID = {id}";
        }

        //需要返回对象
        public static  List<Students> SelectQuery(string q)
        {
            connectionString = "DataSource=" + AppContext.BaseDirectory + "dotnet6.db;Version=3;FailIfMissing=True;";
            Console.WriteLine(connectionString);
            List<Students> resultArray = new List<Students>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    IEnumerable<Students> results = connection.Query<Students>(q);

                    resultArray = results.ToList();

                    foreach (var item in resultArray)
                    {
                        // 在这里处理查询结果
                        Console.WriteLine($"Column1: {item.StudentID}");
                    }

                }catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            return resultArray;
        }

        //插入
        public static void InsertQuery(string q)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (SQLiteCommand cmd = new SQLiteCommand(q, connection, transaction))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        // 提交事务
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // 处理异常或回滚事务
                        transaction.Rollback();
                    }
                }
            }
        }

        //删除，需要处理无法删除的情况
        //应该不会有
        public static void DeleteQuery(string q)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (SQLiteCommand cmd = new SQLiteCommand(q, connection, transaction))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        // 提交事务
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // 处理异常或回滚事务
                        transaction.Rollback();
                    }
                }
            }
        }

        //修改
        public static void AlterQuery(string q)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (SQLiteCommand cmd = new SQLiteCommand(q, connection, transaction))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        // 提交事务
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // 处理异常或回滚事务
                        transaction.Rollback();
                    }
                }
            }
        }
    }
}
