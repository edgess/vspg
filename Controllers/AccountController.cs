using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        private AccountContext db = new AccountContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            ViewBag.LoginState = "before";

            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            string nnn = fc["inputName"];
            string ppp = fc["inputPassword"];

            string ccc = "server=192.168.10.117;database=edge;uid=edge;pwd=1234";
            //新建一个数据库连接  
            using (SqlConnection conn = new SqlConnection(ccc))
            {
                conn.Open();//打开数据库  
                //Console.WriteLine("数据库打开成功!");
                //创建数据库命令  
                SqlCommand cmd = conn.CreateCommand();
                //创建查询语句  
                cmd.CommandText = "select * from JUser WHERE name = '" + nnn + "' and passwd = '" + ppp + "'";
                //从数据库中读取数据流存入reader中  
                SqlDataReader reader = cmd.ExecuteReader();
                
                if (reader.HasRows)
                {
                    ViewBag.LoginState = nnn + "yes" ;
                }
                else
                {
                    ViewBag.LoginState = nnn + "no" ;
                }
                reader.Close();

                SqlCommand cmd2 = conn.CreateCommand();
                cmd2.CommandText = "select * from JUser";
                SqlDataReader reader2 = cmd2.ExecuteReader();
  
                //从reader中读取下一行数据,如果没有数据,reader.Read()返回flase  
                while (reader2.Read())
                {
                    ViewData["data"] += "<tr><td>" + reader2["name"] + "</td><td>" + reader2["passwd"] + "</td></tr>";
                    //reader.GetOrdinal("id")是得到ID所在列的index,  
                    //reader.GetInt32(int n)这是将第n列的数据以Int32的格式返回  
                    //reader.GetString(int n)这是将第n列的数据以string 格式返回  
                    //int id = reader.GetInt32(reader.GetOrdinal("id"));
                    //string name = reader.GetString(reader.GetOrdinal("Name"));
                    //string pwd = reader.GetString(reader.GetOrdinal("Passwd"));
                    //格式输出数据  
                    //Console.Write(name + pwd);
                }
                reader2.Close();
            }
                      
            return View();
        }

    }
}