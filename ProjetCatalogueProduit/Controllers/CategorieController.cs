using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetCatalogueProduit.Models;

namespace ProjetCatalogueProduit.Controllers
{
    public class CategorieController : Controller
    {
        BD_CATALOGUE_PRODUITEntities db = new BD_CATALOGUE_PRODUITEntities();
        // GET: Categorie
        public ActionResult Index()
        {
            //return View();
            return View("Index");
        }

        public ActionResult AjoutCategorie()
        {
            try 
            { 
                ViewBag.listeCategorie = db.CAT_CATEGORIE.ToList();
                return View(); 
            } catch(Exception e) 
            { 
                return HttpNotFound(); 
            }
        }

        [HttpPost]
        public ActionResult AjoutCategorie(CAT_CATEGORIE categorie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new BD_CATALOGUE_PRODUITEntities())
                    {
                        db.CAT_CATEGORIE.Add(categorie);
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(categorie);
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }
    }
}