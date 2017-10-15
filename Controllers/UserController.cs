using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;



namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        private JUserContext db = new JUserContext();
        private shgloldEntities db1 = new shgloldEntities();

        // GET: User
        public ActionResult Index()
        {
            JUser jj = new JUser("edge","234567");
            db.JUsers.Add(jj);
            db.SaveChanges();
            //string name = db.JUsers.Select(p => p.Name).FirstOrDefault().ToString();
            //Console.WriteLine(name);

            //JUser juser1 = db.JUsers.Where(p => p.Name == "sss").FirstOrDefault();
            //juser1.Name = "CYW";
            //db.SaveChanges();

            //name = db.JUsers.Select(p => p.Name).FirstOrDefault().ToString();
            return View();
        }

        public ActionResult ListAll()
        {

            return View(db.JUsers);
        }
        public ActionResult Smjsmj()
        {
            return View(db1.ITequipment);
        }
    }
}