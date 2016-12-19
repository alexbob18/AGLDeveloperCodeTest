using System.Runtime.Serialization;

namespace AGLDeveloperCodeTest.Models
{
    [DataContract]
    public class PetModel
    {
        /// <summary>
        /// Name of the pet
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// Type of the pet
        /// </summary>
        [DataMember]
        public string Type { get; set; }
    }
}