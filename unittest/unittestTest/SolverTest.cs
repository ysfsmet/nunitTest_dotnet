using unittest;

namespace unittestTest
{
    [TestFixture(TestOf = typeof(Solver))]
    public class SolverTest
    {
        Solver solver;

        [SetUp]
        public void Setup()
        {
            solver = new Solver();
        }

        [TestCase(new int[] { 2, 4, 7 }, ExpectedResult = 4)]
        [TestCase(new int[] { 2, 4, 7, 6 }, ExpectedResult = 4)]
        [TestCase(new int[] { 2, 4, 7, 6, 6, 8 }, ExpectedResult = 6)]
        [TestCase(new int[] { 2, 4, 7, 6, 6 }, ExpectedResult = 6)]
        [TestCase(null, ExpectedResult = 6)]
        public int FindSmallestValue_GivenSortedIntegerArray_ReturnSmallest(IEnumerable<int> array)
        {
            return solver.AbsoluteValuesSumMinimization(array);
        }
    }
}