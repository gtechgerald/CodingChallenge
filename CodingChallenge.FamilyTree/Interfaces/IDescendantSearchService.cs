using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.FamilyTree.Interfaces
{
    /// <summary>
    /// Interface for the Descendant Search Service
    /// </summary>
    public interface IDescendantSearchService 
    {
        Person FindDescendantByName(Person ancestor, string name); 
    }
}
