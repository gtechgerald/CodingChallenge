using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingChallenge.FamilyTree.Interfaces; 

namespace CodingChallenge.FamilyTree.Services
{
    public class DescendantSearchService : IDescendantSearchService
    {
        /// <summary>
        /// Searches for a descendant
        /// </summary>
        /// <param name="ancestor">Person object that is the ancestor of the family tree</param>
        /// <param name="name">Name of the person that is being searched for</param>
        /// <returns></returns>
        public Person FindDescendantByName(Person ancestor, string name)
        {
            //Check to ensure that the name is not the name of the ancestor 
            if(ancestor.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                return ancestor; 
            }

            //No Descendants found exists so no further processing is needed 
            if (ancestor.Descendants.Count == 0)
            {            
                return null; 
            }

            //Search on the descendants 
            return SearchDescendants(ancestor.Descendants, name); 
        }

        /// <summary>
        /// Searches a list of descendants for 
        /// the name provided
        /// </summary>
        /// <param name="descendants">Collection of descendants</param>
        /// <param name="name">Name to search for</param>
        /// <returns>Person object if a descendant is found otherwise it will return a null</returns>
        /// <remarks>This method will ignore case of the name</remarks>
        private Person SearchDescendants(List<Person> descendants, string name)
        {
            foreach(var descendant in descendants)
            {
                if(descendant.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return descendant; 
                }

                //Search the descendant's descendants
                if(descendant.Descendants.Count > 0)
                {
                    var searchResult = SearchDescendants(descendant.Descendants, name); 

                    //If one of the descendant's descendants is found 
                    //return it 
                    if(searchResult != null)
                    {
                        return searchResult; 
                    }
                }
            }

            //If no one is found retun a null
            return null; 
        }

        
    }
}
