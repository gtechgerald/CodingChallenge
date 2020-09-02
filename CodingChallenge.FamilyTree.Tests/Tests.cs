using System;
using Given.Common;
using NUnit.Framework;
using CodingChallenge.FamilyTree.Services;
using CodingChallenge.FamilyTree.Interfaces; 

namespace CodingChallenge.FamilyTree.Tests
{
    [TestFixture]
    public class TreeTests
    {
        private DescendantSearchService CreateDescendantSearchService()
        {
            return new DescendantSearchService(); 
        }
        
        [TestCase(1)]
        [TestCase(33)]
        [TestCase(22)]
        public void if_the_person_exists_in_tree_the_result_should_be_their_birthday(int index)
        {
            var tree = FamilyTreeGenerator.Make();
            var result = new Solution(CreateDescendantSearchService()).GetBirthMonth(tree, "Name" + index);
            result.ShouldEqual(DateTime.Now.AddDays(index - 1).ToString("MMMM"));
        }

        [Test]
        public void if_the_person_does_not_exist_in_the_tree_the_result_should_be_empty()
        {
            var tree = FamilyTreeGenerator.Make();
            var result = new Solution(CreateDescendantSearchService()).GetBirthMonth(tree, "Jeebus");
            result.ShouldEqual("");
        }
    }
}
