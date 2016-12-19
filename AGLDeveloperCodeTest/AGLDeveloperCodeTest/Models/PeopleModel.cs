using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AGLDeveloperCodeTest.Models
{
    [DataContract]
    public class PeopleModel
    {
        /// <summary>
        /// Name of the person
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// Gender of the person
        /// </summary>
        [DataMember]
        public string Gender { get; set; }
        /// <summary>
        /// Age of the person
        /// </summary>
        [DataMember]
        public int Age { get; set; }
        /// <summary>
        /// Collection of pets
        /// </summary>
        [DataMember]
        public List<PetModel> Pets { get; set; }
    }
}