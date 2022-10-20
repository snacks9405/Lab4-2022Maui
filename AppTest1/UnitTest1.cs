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
            InvalidFieldError idealResult = InvalidFieldError.NoError;
            BusinessLogic businessLogic = new();

            String[] clues = { "CLUE", "CLUE", "CLUE", "" };
            String[] answers = { "answer", "answer", "answer", "" };
            int[] difficulties = { 0, 1, 3, 2 };
            String[] dates = { "05/25/1991", "05/35/1991", "05/25/1991", "05/25/1991" };
            for (int i = 0; i < 4; i++)
            {
                InvalidFieldError e = businessLogic.AddEntry(clues[i], answers[i], difficulties[i], dates[i]);
                Assert.That(e, Is.EqualTo(idealResult));
            }


        }
    }
}