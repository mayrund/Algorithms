using NUnit.Framework;
using Algorithms.LevenshteinDistance;
using Algorithms.Tests;
using System.Collections.Generic;

namespace Tests
{
    public class LevenshteinTests
    {
        public List<TestData> TestData { get; set; }

        [SetUp]
        public void Setup()
        {
            TestData = new List<TestData>();
            TestData.Add(new TestData("facebook", "facebookk", 1));
            TestData.Add(new TestData("cat", "flat", 2));
            TestData.Add(new TestData("whatsa?p", "whatsapp", 0));
            TestData.Add(new TestData("netherlands", "nthrlandz", 3));
            TestData.Add(new TestData("amsterda?", "amsterdam", 0));
            TestData.Add(new TestData("helloworld", "h3ll0w0rld", 3));
        }

        [Test]
        public void Repeated_Return_Correct_Distances()
        {
            foreach (var test in TestData)
            {
                var results = StringDistance.Distance(test.Word, test.CorrectedWord);
                Assert.AreEqual(test.Distance, results.Distance);
            }
        }
    }
}