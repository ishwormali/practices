using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProfessionalMVCTest.Models
{
    public class CollectionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public static IList<CollectionModel> GetAll()
        {
            return new List<CollectionModel>(){
                new CollectionModel(){Id=1,Name="Name A",Address ="Address 1"},
                new CollectionModel(){Id=2,Name="Name B",Address ="Address 2"},
                new CollectionModel(){Id=3,Name="Name C",Address ="Address 3"},
                new CollectionModel(){Id=4,Name="Name D",Address ="Address 4"},
                new CollectionModel(){Id=5,Name="Name E",Address ="Address 5"},
                new CollectionModel(){Id=6,Name="Name F",Address ="Address 6"}
            };

        }
    }
}