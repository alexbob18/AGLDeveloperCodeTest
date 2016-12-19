using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AGLDeveloperCodeTest.Models;
using System.Net.Http;
using System.Configuration;
using System.Web.Script.Serialization;

namespace AGLDeveloperCodeTest.Service
{
    public class ProcessJsonDataService : IProcessJsonDataService
    {
        public const string JsonURL = "http://agl-developer-test.azurewebsites.net/people.json";
        public const string MConst = "Male";
        public const string FConst = "Female";
        public const string TypeConst = "Cat";
        /// <summary>
        /// Gets the Json data which is parsed, deserialized and sorted
        /// </summary>
        /// <returns></returns>
        public PetsViewModel GetPeoplePetsData()
        {
            PetsViewModel petsViewModel = new PetsViewModel();
            List<PeopleModel> peoplePetModelList = new List<PeopleModel>();
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(JsonURL);
            HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress).Result;
            if (response != null)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                //Deserialized to List<PeopleModel>
                peoplePetModelList = (List<PeopleModel>)js.Deserialize(response.Content.ReadAsStringAsync().Result, typeof(List<PeopleModel>));

                petsViewModel.MaleCats = ProcessViewModel(peoplePetModelList, MConst, TypeConst);
                petsViewModel.FemaleCats = ProcessViewModel(peoplePetModelList, FConst, TypeConst);
            }

            return petsViewModel;
        }
        /// <summary>
        /// Filtered and sorted
        /// </summary>
        /// <param name="peoplePetModelList"></param>
        /// <param name="gender"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private List<PetModel> ProcessViewModel(List<PeopleModel> peoplePetModelList, string gender, string type)
        {
            var orderedPetList = (from people in peoplePetModelList
                           where people.Pets != null && people.Gender == gender
                           from pets in people.Pets
                           where pets.Type == type
                           select pets).OrderBy(x => x.Name).ToList();
            return orderedPetList;
        }
    }
}