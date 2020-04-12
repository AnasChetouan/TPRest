using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripAdvasorAPI.Models;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TripAdvasorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripAdvasorController : ControllerBase
    {
        static readonly HttpClient client = new HttpClient();

        public TripAdvasorController()
        {
            client.BaseAddress = new Uri("https://localhost:44348/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: https://localhost:44339/api/Booking/Paris/10-04-2020/20-04-2020/0/100/-1/1
        [HttpGet("{ville}/{dateArr}/{dateDep}/{prixMin:float}/{prixMax:float}/{nbEtoiles:int}/{nbClients:int}")]
        public async Task<ActionResult<IEnumerable<Offre>>> GetOffres(string ville, string dateArr, string dateDep, float prixMin, float prixMax, int nbEtoiles, int nbClients)
        {
            string path = "/api/Chambres/100/login/mdp/"+ ville+"/"+dateArr+"/"+dateDep+"/"+prixMin+"/"+prixMax+"/"+nbEtoiles+"/"+nbClients;

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                List<Offre> offres;
                offres = await response.Content.ReadAsAsync<List<Offre>>();
                return offres;
            }
            else
                return NotFound();
        }
    }
}