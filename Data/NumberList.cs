namespace VolvoREST.Data
{
    public class NumberList
    {
        private List<int> postedNumbers = new List<int>();

        public void AddNumber(int number)
        {
            postedNumbers.Add(number);
        }

        public List<int> GetPostedNumbers()
        {
            return postedNumbers;
        }
    }
}
