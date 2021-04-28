using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebServiceRest.Models;

namespace WebServiceRest.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:44310");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:8084/user/retrieves-all-user").Result;

            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<User>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }

            return View();
        }




        // GET: User/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Reclamation/Create
        [HttpPost]
        public ActionResult Create(User rec)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44310");
            client.PostAsJsonAsync<User>("http://localhost:8084/secure/auth/admin/add", rec).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Signaler(int id)
        {
            string a = "http://localhost:8084/secure/auth/signaler/" + id;

            using (HttpClient client = new HttpClient())
            {
                string Url = "http://localhost:8084/secure/auth/signaler/" + id;
                var uri = new Uri(Url);
                var response = client.GetAsync(a).Result;
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
        
       

    }
}
