using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootballAssignment3.Models;

namespace FootballAssignment3.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {

            /* foreach(string key in formCollection.AllKeys)
             {
                 Response.Write("Key=" + key + " ");
                 Response.Write(formCollection[key]);
                 Response.Write("<br/>");
             }*/
            Football fb = new Football();
            fb.matchid = Convert.ToInt32(formCollection["matchid"]);
            fb.teamname1 = formCollection["teamname1"];
            fb.teamname2 = formCollection["teamname2"];
            fb.status = formCollection["status"];
            fb.winningteam = formCollection["winningteam"];
            fb.points = Convert.ToInt32(formCollection["points"]);
            footballdatafetch f = new footballdatafetch();
            f.AddFootballData(fb);
            return RedirectToAction("success");
            //return View();

        }

        public ActionResult Fetch()
        {
            footballdatafetch footballdatafetch = new footballdatafetch();  
            List<Football> fb = footballdatafetch.fbl.ToList();
            return View(fb);    
        }

        public ActionResult success()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

    }
}