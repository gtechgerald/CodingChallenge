using System;
using CodingChallenge.FamilyTree.Interfaces;


namespace CodingChallenge.FamilyTree
{
    public class Solution
    {
        private readonly IDescendantSearchService _descendantSearchService; 

        public Solution(IDescendantSearchService descendantSearchService)
        {
            _descendantSearchService = descendantSearchService; 
        }

        public string GetBirthMonth(Person person, string descendantName)
        {
            var descendant = _descendantSearchService.FindDescendantByName(person, descendantName);  

            if(descendant == null)
            {
                return String.Empty; 
            }
            else
            {
                return descendant.Birthday.ToString("MMMM"); 
            }
        }
    }
}