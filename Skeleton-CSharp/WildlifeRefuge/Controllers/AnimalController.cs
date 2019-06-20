using Microsoft.AspNetCore.Mvc;
using WildlifeRefuge.Models;
using System.Linq;

namespace WildlifeRefuge.Controllers
{
    public class AnimalController : Controller
    {
        private readonly WildlifeRefugeDbContext context;

        public AnimalController(WildlifeRefugeDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            using (var db = new WildlifeRefugeDbContext())
            {
                var allAnimals = db.Animals.ToList();
                return this.View(allAnimals);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(Animal animal)
        {
            using (var db = new WildlifeRefugeDbContext())
            {
                db.Animals.Add(animal);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new WildlifeRefugeDbContext())
            {
                var animalEdit = db.Animals.FirstOrDefault(t => t.Id == id);

                if (animalEdit == null)
                {
                    return RedirectToAction("Index");

                }
                return View(animalEdit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Animal animal)
        {
            using (var db = new WildlifeRefugeDbContext())
            {
                db.Animals.Update(animal);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new WildlifeRefugeDbContext())
            {
                Animal animalDelete = db.Animals.Find(id);
                if (animalDelete == null)
                {
                    return RedirectToAction("Index");

                }
                return View(animalDelete);
            }
        }

        [HttpPost]
        public IActionResult Delete(Animal animal)
        {
            using (var db = new WildlifeRefugeDbContext())
            {
                db.Animals.Remove(animal);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}