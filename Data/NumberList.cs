namespace VolvoREST.Data
{
    public class NumberList
    {
        private List<int> postedNumbers = new List<int>();
        private readonly object lockObject = new object();

        public void AddNumber(int number)
        {
            lock (lockObject)
            {
                postedNumbers.Add(number);
            }
        }

        public List<int> GetPostedNumbers()
        {
            lock (lockObject)
            {
                return new List<int>(postedNumbers);
            }
        }
    }
}
