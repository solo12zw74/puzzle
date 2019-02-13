using NUnit.Framework;
using Resolver.AStar;

namespace Tests
{    
    public class ResolveTestFixture
    {
        AStarResolver resolver;
        [SetUp]
        public void Setup()
        {
            resolver = new AStarResolver();
        }

        [TestCase(new int[] { 1, 2, 3, 4, 6, 5, 0, 7, 8, 9 }, new int[] { 6, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 6, 5, 8, 9, 7, 0 }, new int[] { 9, 7, 8, 6, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 6, 0, 8, 5, 7, 9 }, new int[] { 5, 7, 8, 6, 4 })]
        [TestCase(new int[] { 1, 2, 0, 3, 4, 5, 6, 7, 8, 9 }, new int[] { 3 })]
        public void ResolveCorrect(int[] input, int[] output)
        {
            var result = resolver.Resolve(input);
            Assert.That(result, Is.EqualTo(output));
        }
    }
}