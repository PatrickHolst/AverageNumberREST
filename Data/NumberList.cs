namespace VolvoREST.Data
{
    public class NumberList
    {
        private readonly HashSet<int> postedNumbers = new HashSet<int>();
        private double sum = 0;
        private int count = 0;
        private readonly object lockObject = new object();

        public bool AddNumber(int number)
        {
            lock ( lockObject)
            {
                if(postedNumbers.Contains(number))
                {
                    return false;
                }
                postedNumbers.Add(number);
                sum += number;
                count++;

                return true;
            }
        }

        public double? GetAverage()
        {
            lock ( lockObject)
            {
                if (count == 0) return null;

                double average = sum / count;
                return average;
            }
        }
    }
}
