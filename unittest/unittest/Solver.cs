namespace unittest
{
    public class Solver
    {
        public int AbsoluteValuesSumMinimization(IEnumerable<int> sortedArray)
        {
            int minimum = int.MaxValue;
            int result = 0;
            foreach (var selectedItem in sortedArray)
            {
                var total = 0;
                foreach (var item in sortedArray.Where(x => x != selectedItem))
                {
                    total += Math.Abs(selectedItem - item);
                }

                if (total < minimum)
                {
                    minimum = total;
                    result = selectedItem;
                }
            }
            return result;
        }

        public int SumOfDigits(int n)
        {
            var result = 0;
            while (n > 0)
            {
                result += n % 10;
                n /= 10;
            }
            return result;
        }

        public int AdjacentElementsProduct(IEnumerable<int> inputs)
        {
            if (inputs is null)
                return 0;

            var result = int.MinValue;
            var lastItem = inputs.First();
            for (int i = 1; i < inputs.Count(); i++)
            {
                var product = lastItem * inputs.ElementAt(i);
                if (product > result) result = product;
                lastItem = inputs.ElementAt(i);
            }
            return result;
        }

        public IEnumerable<int> AlternatingSums(IEnumerable<int> members)
        {
            var sumOfWeightsFirstGroup = 0;
            var sumOfWeightsSecondGroup = 0;
            for (int i = 0; i < members.Count(); i++)
            {
                if (i % 2 == 0) sumOfWeightsFirstGroup += members.ElementAt(i);
                else sumOfWeightsSecondGroup += members.ElementAt(i);
            }
            return new int[] { sumOfWeightsFirstGroup, sumOfWeightsSecondGroup };
        }

        public IEnumerable<int> AlternatingSums(IEnumerable<int> members, int groupCount)
        {
            var result = new int[groupCount];
            var groupIdx = 0;
            for (int i = 0; i < members.Count(); i++)
            {
                result[groupIdx++] += members.ElementAt(i);
                if (groupIdx == groupCount) groupIdx = 0;
            }
            return result;
        }
    }
}