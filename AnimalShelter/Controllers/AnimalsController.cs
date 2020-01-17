using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;
using System.Collections.Generic;
using System.Linq;

namespace AnimalShelter.Controllers
{
    
  public class AnimalsController : Controller
  {
      private readonly AnimalContext _dataBase;
      public AnimalsController(AnimalContext dataBase)
      {
          _dataBase = dataBase;
      }
      [HttpGet]
      public ActionResult Index()
      {
          List<Animal> model = _dataBase.Animals.ToList();
          return View(model);
      }
      [HttpGet]
      public ActionResult Create()
      {
          return View();
      }
      [HttpPost]
      public ActionResult Create(Animal givenAnimal)
      {
        _dataBase.Animals.Add(givenAnimal);
        _dataBase.SaveChanges();
        return RedirectToAction("Index");
      }
      [HttpGet]
      public ActionResult Details(int id)
      {
            Animal thisAnimal = _dataBase.Animals.FirstOrDefault(animals => animals.AnimalId == id);
            return View(thisAnimal);
      }
       [HttpGet]
      public ActionResult SortByAscendingOrder()
      {
          var animalsByOrder = _dataBase.Animals.OrderBy(animals => animals.AnimalType).ToList();
          return View(animalsByOrder);
      }
       [HttpGet]
      public ActionResult SortByDescendingOrder()
      {
          var animalsByOrder = _dataBase.Animals.OrderByDescending(animals => animals.AnimalType).ToList();
          return View(animalsByOrder);
      }
      [HttpPost]
      public ActionResult SearchAnimalByName(string givenName)
      {
          Animal foundAnimal = _dataBase.Animals.Where(animals => animals.AnimalName==givenName).FirstOrDefault<Animal>();
          if(foundAnimal==null)
          {
            return RedirectToAction("SearchAnimalByName");
          }
          return View("ShowFoundAnimal",foundAnimal);
      }
      [HttpGet]
      public ActionResult SearchAnimalByName()
      {
          return View();
      }
      
     
    // [HttpGet]
    //  public ActionResult ShowByOrder()
    //  {
    //      var query = from statement in _dataBase.Animals
    //                  where statement.AnimalType=="Cat"
    //                  select statement;
    //                  var animalType = query.FirstOrDefault<Animal>();
    //                  return View(animalType);
    //  }
    //   [HttpGet]
    //   public ActionResult SortByLongestDay()
    //   {
    //       var animalsByGroup = _dataBase.Animals.GroupBy(animals=> animals.AttandenceDate).ToList();
    //       return View(animalsByGroup);
    //   }
      
  }
}