using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
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


        [HttpGet]
        public ActionResult Delete(int id)
        {
            string a = "http://localhost:8084/reclamation/delete/" + id;

            using (HttpClient client = new HttpClient())
            {
                string Url = "http://localhost:8084/reclamation/delete/";
                var uri = new Uri(Url);
                var response = client.DeleteAsync(a).Result;
            }
            return Redirect(Request.UrlReferrer.ToString());
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            string a = "http://localhost:8084/reclamation/retrieves-all-reclamation/" + id;
            Reclamation p = new Reclamation();
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:44310/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync(a).Result;

            if (response.IsSuccessStatusCode)
            {
                p = response.Content.ReadAsAsync<Reclamation>().Result;
            }

            return View(p);
        }

        public ActionResult Edit(Reclamation post)
        {

            //   post.date = post.date.ToString("yyyyMMdd");

            string url = "http://localhost:8084/reclamation/update-reclamation/" + post.id;

            using (HttpClient client = new HttpClient())
            {

                //   var result = client.PutAsync(a, new StringContent(post.v)).Result;
                var json = new JavaScriptSerializer().Serialize(post);
                var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = client.PutAsync(url, content).Result;
            }

            return RedirectToAction("Index");
        }






    }
}
