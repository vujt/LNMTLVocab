using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LNMTVocab.Data;

namespace LNMTVocab.Controllers
{
    
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            var myList = ReadFile();

            return View(myList);
        }

        
        private List<Glossary> ReadFile()
        {
         //   string path1 = string.Format("{0}/{1}", Server.MapPath("~/Data/"), "translation.txt");
            var root = AppDomain.CurrentDomain.BaseDirectory;
            List<Glossary> myList = new List<Glossary>();

            System.IO.StreamReader file = new System.IO.StreamReader(root + "\\Data\\translation.txt");
            string fileLines;

            
                while ((fileLines = file.ReadLine()) != null)
                {

                    string[] elements;
                    elements = fileLines.Split(new char[] { '\t' });

                    myList.Add(new Glossary() { vocab = elements[1], meaning = elements[2], vocabLength = elements[4] });
                    

                }

            return myList;

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}