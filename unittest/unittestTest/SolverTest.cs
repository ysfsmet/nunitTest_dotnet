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
        public int FindSmallestValue_GivenSortedIntegerArray_ReturnSmallest(IEnumerable<int> array)
        {
            return solver.AbsoluteValuesSumMinimization(array);
        }

        [Test]
        public void SumOfDigits_GivenInteger_ResultDigitsSum()
        {
            Assert.Multiple(() =>
            {
                Assert.That(solver.SumOfDigits(29), Is.EqualTo(11));
                Assert.That(solver.SumOfDigits(90000), Is.EqualTo(9));
                Assert.That(solver.SumOfDigits(111), Is.EqualTo(3));
                Assert.That(solver.SumOfDigits(101010), Is.EqualTo(3));
                Assert.That(solver.SumOfDigits(98765400), Is.EqualTo(39));
            });
        }

        [Test]
        public void AdjacentElementsProduct_GivenIntegerArray_ResultLargestProduct()
        {
            Assert.Multiple(() =>
            {
                Assert.That(solver.AdjacentElementsProduct(new int[] { 3, 6, -2, -5, 7, 3 }), Is.EqualTo(21));
                Assert.That(solver.AdjacentElementsProduct(new int[] { 3, 6, -2, -5, -7, 3 }), Is.EqualTo(35));
            });
        }

        [Test]
        public void AlternatingSums_GivenIntegerArray_ResultGroupedSums()
        {
            Assert.Multiple(() =>
            {
                Assert.That(solver.AlternatingSums(new int[] { 50, 60, 60, 45, 70 }), Is.EqualTo(new int[] { 180, 105 }));
                Assert.That(solver.AlternatingSums(new int[] { 15, 35, 30, 25, 10 }, 3), Is.EqualTo(new int[] { 40, 45, 30 }));
            });
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, ExpectedResult = 186)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, ExpectedResult = 98)]
        [TestCase(new int[] { -1, -2, 8 }, ExpectedResult = -24)]
        public int ArrayConversion_GivenAnArray_ReturnResult(IEnumerable<int> array)
        {
            return solver.ArrayConversion(array);
        }

        [Test]
        public void ArrayPreviousLess_GivenIntegerArray_ReturnPreviousLessArray()
        {
            var given = new int[] { 3, 5, 2, 4, 5 };
            var result = solver.ArrayPreviousLess(given);
            Assert.That(result, Is.EqualTo(new int[] { -1, 3, -1, 2, 4 }));
        }


    }
}