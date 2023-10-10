namespace VolvoREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NumberController : ControllerBase
    {
        private readonly NumberList numberList;

        public NumberController(NumberList numberList)
        {
            this.numberList = numberList;
        }

        [HttpPost("post-number")]
        public IActionResult PostNumber([FromBody] NumberInput input)
        {
            if (input == null)
            {
                return BadRequest();
            }

            int number = input.Number; // extracting the model

            if (numberList.GetPostedNumbers().Contains(number))
            {
                return Conflict($"The number {number} already exists");
            }

            numberList.AddNumber(number);
            return Ok($"Number {number} added");
        }

        [HttpGet("GET-numbers-list")]
        public IActionResult GetAddedNumbers()
        {
            List<int> postedNumbers = numberList.GetPostedNumbers();
            if (postedNumbers.Count == 0)
            {
                return NotFound($"List is empty");
            }
            return Ok(postedNumbers);
        }

        [HttpGet("GET-average")]
        public IActionResult GetAverage()
        {
            List<int> postedNumbers = numberList.GetPostedNumbers();

            if (postedNumbers.Count == 0)
            {
                return NotFound($"No numbers to calculate");
            }

            double average = postedNumbers.Average();
            string formattedAverage = average.ToString("F4"); // four decimal places

            return Ok(new { average = formattedAverage });
        }
    }
}
