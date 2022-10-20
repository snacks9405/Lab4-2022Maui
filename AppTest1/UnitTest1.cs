using Lab2Solution;

namespace AppTest1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddTest()
        {
            String[] Clues = { "CLUE", "CLUE", "CLUE", null };
            BusinessLogic.AddEntry();
            Assert.Pass();
        }
    }
}