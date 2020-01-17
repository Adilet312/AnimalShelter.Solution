using System;
namespace AnimalShelter.Models
{
    public class Animal
    {
        public int AnimalId{get;set;}
        public string AnimalType{get;set;}
        public string AnimalName{get; set;}
        public string AnimalGender{get;set;}
        public DateTime AttandenceDate{get;set;}
        public string Breed{get;set;}
        public Animal()
        {

        }
 
    }
}