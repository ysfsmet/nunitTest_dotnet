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
    }
}