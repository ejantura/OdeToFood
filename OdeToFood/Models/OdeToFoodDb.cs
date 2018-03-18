using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace OdeToFood.Models
{
    public class OdeToFoodDb : DbContext

    {
        public OdeToFoodDb() :  base("name=DefaultConnection")
        {

        }
        public DbSet<Restaurant> Resteurants { get; set; }
        public DbSet<ResteurantReview> Reviews { get; set; }

        public System.Data.Entity.DbSet<OdeToFood.Models.Comments> Comments { get; set; }
    }

}