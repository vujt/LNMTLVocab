using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LNMTVocab.Data;
using System.Text;
using System.Net;
using System.IO;

namespace LNMTVocab.Controllers
{
    
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            var myList = ReadFile();
          //  SendData();

            return View(myList);
        }

        public void SendData()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://lnmtl.com/termProposition");

            var postData = "_token=lsu5YjVWugao5azbPp52VbDBa63uXnaJMX26lDfl";
            postData += "&type=create";
            postData += "&novel_id=19";
            postData += "&raw=test";
            postData += "&meaning=test";
            postData += "&author_note=note";
            

            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            //var response = (HttpWebResponse)request.GetResponse();

            //var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                   
            //response.Close();

            //  return View();
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