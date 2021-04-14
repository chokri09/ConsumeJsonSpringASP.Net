using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebServiceRest.Models;

namespace WebServiceRest.Controllers
{
    public class ReclamationController : Controller
    {
        // GET: Reclamation
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:44310");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:8084/reclamation/retrieves-all-reclamation").Result;

            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Reclamation>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }
            
            return View();
        }



        // GET: Reclamation/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Reclamation/Create
        [HttpPost]
        public ActionResult Create(Reclamation rec)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44310");
            client.PostAsJsonAsync<Reclamation>("http://localhost:8084/reclamation/save-reclamation", rec).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

            return RedirectToAction("Index");
        }

       
       
    }
}
