using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;


namespace WebApplication1.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            string ccc = "server=192.168.10.30;user id=log;password=1234;database=bak_log";

            using (MySqlConnection myconn = new MySqlConnection(ccc))
            {
                myconn.Open();
                MySqlCommand mycmd = myconn.CreateCommand();
                mycmd.CommandText = "SELECT * FROM log ORDER BY date DESC limit 60";
                MySqlDataReader myreader = mycmd.ExecuteReader();
                while (myreader.Read())
                {
                    string p1 = Convert.ToBoolean(myreader[1]) ? "YES" : "NO";
                    string p2 = Convert.ToBoolean(myreader[2]) ? "YES" : "NO";
                    ViewData["data"] += "<tr><td>" + myreader[0] + "</td><td>" + p1  + "</td><td>" + p2 + "</td><td>" + myreader[3] + "</td><td>" + myreader[4] + "</td></tr>";
                }
                myreader.Close();
                return View();
            }
        }

    }
}