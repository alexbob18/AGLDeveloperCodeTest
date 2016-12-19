using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGLDeveloperCodeTest.Models
{
    public class PetsViewModel
    {
        /// <summary>
        /// Collection of Male cats
        /// </summary>
        public List<PetModel> MaleCats { get; set; }
        /// <summary>
        /// Collection of female cats
        /// </summary>
        public List<PetModel> FemaleCats { get; set; }
    }
}