﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BeerhallEF.Models
{
    public class Brewer
    {
        #region Properties

        [Key]
        public int BrewerId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ContactEmail { get; set; }

        public DateTime? DateEstablished { get; set; }

        public int? Turnover { get; set; }

        public string Street { get; set; }

        public ICollection<Beer> Beers { get; private set; }

        public int NrOfBeers => Beers.Count;

        public Location Location { get; set; }

        #endregion

        #region Constructors
        public Brewer()
        {
            Beers = new HashSet<Beer>();
        }

        public Brewer(string name) : this()
        {
            Name = name;
        }

        public Brewer(string name, Location location, string street) : this(name)
        {
            Location = location;
            Street = street;
        }
        #endregion

        #region Methods
        public void AddBeer(string name, decimal price)
        {
            Beers.Add(new Beer(name, price));
        }

        public void DeleteBeer(Beer beer)
        {
            Beers.Remove(beer);
        }
        #endregion
    }

}




