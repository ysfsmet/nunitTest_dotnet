using System.Security.Cryptography.X509Certificates;
using System.Text;

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

        public IEnumerable<int> ArrayConverter(IEnumerable<int> input, bool isSumOperation = true)
        {
            var result = new List<int>();
            for (int i = 0; i < input.Count(); i += 2)
            {
                var firstItem = input.ElementAt(i);
                var secondItem = i + 1 < input.Count() ? input.ElementAt(i + 1) : isSumOperation ? 0 : 1;
                if (isSumOperation)
                    result.Add(firstItem + secondItem);
                else
                    result.Add(firstItem * secondItem);
            }

            if (result.Count() != 1)
                return ArrayConverter(result, !isSumOperation);

            return result;
        }


        public int ArrayConversion(IEnumerable<int> input)
        {
            return ArrayConverter(input).First();
        }

        public int ReturnNearestLess(IEnumerable<int> inputs, int target)
        {
            var biggest = -1;
            for (int i = 0; i < inputs.Count(); i++)
            {
                var item = inputs.ElementAt(i);
                if (biggest < item && item < target) biggest = item;
            }
            return biggest;
        }

        public IEnumerable<int> ArrayPreviousLess(IEnumerable<int> input)
        {
            var result = new List<int>() { -1 };
            for (int i = 1; i < input.Count(); i++)
            {
                result.Add(input.ElementAt(i - 1) < input.ElementAt(i) ? input.ElementAt(i - 1) : -1);
            }
            return result;
        }

        private string GetLine(string word, int maxCharCount)
        {
            StringBuilder sb = new StringBuilder(maxCharCount);
            sb.Append('*');
            for (int i = 0; i < maxCharCount; i++)
            {
                if (word.Length > i)
                    sb.Append(word[i]);
                else if (word.Length == 0)
                    sb.Append('*');
                else
                    sb.Append(' ');
            }
            sb.Append('*');
            return sb.ToString();
        }

        public IEnumerable<string> AddBorder(IEnumerable<string> words)
        {
            if (words.Count() == 0)
                throw new ArgumentException("Count can not be zero",nameof(words));

            var results = new List<string>();
            var maxLength = words.MaxBy(w => w.Length)?.Length ?? 0; // with first and last * assign
            // Top Line
            results.Add(GetLine(string.Empty, maxLength));
            for (int i = 0; i < words.Count(); i++)
            {
                results.Add(GetLine(words.ElementAt(i), maxLength));
            }
            // Bottom Line
            results.Add(GetLine(string.Empty, maxLength));
            return results;
        }

        public void PrintBorderedWords(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}