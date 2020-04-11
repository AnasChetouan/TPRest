using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IbisAPI.Models;

namespace IbisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChambresController : ControllerBase
    {
        private readonly IbisContext _context;

        public ChambresController(IbisContext context)
        {
            _context = context;

            Adresse aMonmartre = new Adresse(1, "France", "Paris", "Caulaincourt", "5", "75018");

            Hotel ibis = new Hotel(1, "Ibis", 3, aMonmartre, 1);
            _context.Ibis = ibis;

            Chambre cDouble1 = new Chambre(1, 1, 2, 60);
            Chambre cDouble2 = new Chambre(2, 1, 2, 70);

            Chambre cSimple1 = new Chambre(3, 1, 1, 40.50f);
            Chambre cSimple2 = new Chambre(4, 1, 1, 40.50f);

            Chambre cDeuxSimple1 = new Chambre(5, 2, 2, 55.90f);
            Chambre cDeuxSimple2 = new Chambre(6, 2, 2, 55.90f);

            Chambre cTroisSimple1 = new Chambre(7, 3, 3, 70);
            Chambre cTroisSimple2 = new Chambre(8, 3, 3, 80);

            _context.Chambres.AddAsync(cDouble1);
            _context.Chambres.AddAsync(cDouble2);

            _context.Chambres.AddAsync(cSimple1);
            _context.Chambres.AddAsync(cSimple2);

            _context.Chambres.AddAsync(cDeuxSimple1);
            _context.Chambres.AddAsync(cDeuxSimple2);

            _context.Chambres.AddAsync(cTroisSimple1);
            _context.Chambres.AddAsync(cTroisSimple2);

            ClientPrincipal C1 = new ClientPrincipal(1, "Client", "Principal");
            var exp = new DateTime(2022, 8, 10, 0, 0, 0);
            new CartePaiement(1, "123 456 789", "123", exp, C1.Nom, C1.Prenom);
            C1.IDCartePaiement = 1;

            _context.Clients.AddAsync(C1);

            var arr = new DateTime(2020, 3, 15, 0, 0, 0);
            //Console.WriteLine(arr.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR")));

            var dep = new DateTime(2020, 3, 20, 0, 0, 0);

            Reservation R1 = new Reservation(1, C1.IDclient, cDouble1.IDchambre, 80.90f, arr, dep, 2);

            _context.Reservations.AddAsync(R1);

            // On initialise notre hotel avec une agence déjà partenaire
            // On dit que l'ID de Ibis = 1 et ID de l'agence Booking partenaire = 100

            Partenariat p = new Partenariat(1, 100, 1, "Booking.com", "Ibis", "login", "mdp", 0.10f);
            _context.Partenariats.AddAsync(p);

            _context.SaveChangesAsync();
            //_context = context;
        }

        private Boolean Authentification(int idAgence, string login, string motdepasse)
        {
            foreach (Partenariat p in _context.Partenariats)
            {
                if(p.IdAgence == idAgence && p.Login.Equals(login) && p.Motdepasse.Equals(motdepasse))
                {
                    // Connexion réussie
                    return true;
                }
            }
            // Connexion échouée, partenariat non trouvé ou login/mdp non correct
            return false;
        }

        // GET: api/Chambres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chambre>>> GetChambres()
        {
            return await _context.Chambres.ToListAsync();
        }

        // GET: api/Chambres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chambre>> GetChambre(int id)
        {
            var chambre = await _context.Chambres.FindAsync(id);

            if (chambre == null)
            {
                return NotFound();
            }

            return chambre;
        }

        // GET : https://localhost:44348/api/Chambres/100/login/mdp/1/1/Prenom/Nom
        [HttpGet("{idAgence}/{log}/{mdp}/{idOffre}/{idPersonne}/{prenom}/{nom}")]
        public string SetReservation(int idAgence, string log, string mdp, int idOffre, int idPersonne, string prenom, string nom)
        {
            if (Authentification(idAgence, log, mdp))
            {
                foreach (Offre a in _context.Offres)
                {
                    if (a.IdOffre == idOffre)
                    {
                        _context.Reservations.AddAsync(new Reservation(52, 20, a.IdChambre, a.Prix, DateTime.Now, DateTime.Now.AddDays(10), 2));
                        return "Réservé";
                    }

                }
                return "Erreur de reservation";

            }
            else
            {
                return "Erreur de reservation";
            }
        }

        // GET: https://localhost:44348/api/Chambres/100/login/mdp/Paris/10-04-2020/20-04-2020/0/100/-1/1
        [HttpGet("{idAgence:int}/{login}/{motdepasse}/{ville}/{dateArr}/{dateDep}/{prixMin:float}/{prixMax:float}/{nbEtoiles:int}/{nbClients:int}")]
        public async Task<ActionResult<IEnumerable<Offre>>> GetOffres(int idAgence, string login, string motdepasse, string ville, string dateArr, string dateDep, float prixMin, float prixMax, int nbEtoiles, int nbClients)
        {
            if(Authentification(idAgence, login, motdepasse))
            {
                

                List<Offre> listeOffres = new List<Offre>();

                Adresse adresseIbis = _context.Ibis.Adresse;
                if (adresseIbis.Ville.Equals(ville) && (this._context.Ibis.NbEtoiles == nbEtoiles || nbEtoiles == -1)) // -1 est la valeur quand le client n'applique aucun filtre sur le nombre d'étoiles de l'hotel
                {
                    foreach (Chambre c in this._context.Chambres)
                    {
                        if (c.PrixBase >= prixMin && c.PrixBase <= prixMax)
                        {
                            if (c.NbPlaces >= nbClients)
                            {
                                Boolean disponible = true;
                                
                                foreach (Reservation r in _context.Reservations)
                                {
                                    // Si la chambre en cours est déjà réservée
                                    if (r.Chambre == c.IDchambre)
                                    {
                                        string[] decompDep = dateDep.Split('-');
                                        int jourDep = int.Parse(decompDep[0]);
                                        int moisDep = int.Parse(decompDep[1]);
                                        int anneeDep = int.Parse(decompDep[2]);
                                        DateTime arr = new DateTime(anneeDep, moisDep, jourDep, 0, 0, 0);

                                        string[] decompArr = dateArr.Split('-');
                                        int jourArr = int.Parse(decompDep[0]);
                                        int moisArr = int.Parse(decompDep[1]);
                                        int anneeArr = int.Parse(decompDep[2]);

                                        DateTime dep = new DateTime(anneeArr, moisArr, jourArr, 0, 0, 0);

                                        // Verifier les dates
                                        int comp1 = DateTime.Compare(r.DateArrivee, arr);
                                        int comp2 = DateTime.Compare(r.DateDepart, arr);
                                        int comp3 = DateTime.Compare(r.DateArrivee, dep);
                                        int comp4 = DateTime.Compare(r.DateDepart, dep);

                                        if ((comp1 > 0 && comp2 < 0) || (comp3 > 0 && comp4 < 0))
                                        {
                                            disponible = false;
                                        }
                                    }
                                }

                                if (disponible)
                                {
                                    Offre o = new Offre(this._context.Ibis.NbOffres, c.IDchambre, c.PrixBase, c.NbLits);
                                    this._context.Ibis.NbOffres++;
                                    // Ajout de l'offre à la BDD
                                    await this._context.Offres.AddAsync(o);
                                    await _context.SaveChangesAsync();

                                    // Ajout de l'offre à la liste des offres qui seront retournées
                                    listeOffres.Add(o);
                                   // offres.Add(c.NbPlaces + "|" + c.NbLits + "|" + c.PrixBase + "|" + c.Id);
                                }
                            }
                        }
                    }
                }

          
                return listeOffres;
            }

            return NotFound(); 
        }

        //string idAgence, string nomAgence, string login, string motdepasse, string ville, DateTime arr, DateTime dep, float prixMin, float prixMax, int nbEtoiles, int nbClients

        // PUT: api/Chambres/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChambre(int id, Chambre chambre)
        {
            if (id != chambre.IDchambre)
            {
                return BadRequest();
            }

            _context.Entry(chambre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChambreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Chambres
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Chambre>> PostChambre(Chambre chambre)
        {
            _context.Chambres.Add(chambre);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChambreExists(chambre.IDchambre))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChambre", new { id = chambre.IDchambre }, chambre);
        }

        // DELETE: api/Chambres/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Chambre>> DeleteChambre(int id)
        {
            var chambre = await _context.Chambres.FindAsync(id);
            if (chambre == null)
            {
                return NotFound();
            }

            _context.Chambres.Remove(chambre);
            await _context.SaveChangesAsync();

            return chambre;
        }

        private bool ChambreExists(int id)
        {
            return _context.Chambres.Any(e => e.IDchambre == id);
        }
    }
}
