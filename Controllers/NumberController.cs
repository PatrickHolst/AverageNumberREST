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

            int number = input.Number;

            if (numberList.AddNumber(number))
            {
                return Ok($"Number {number} added");
            }
            else
            {
                return Conflict($"The number {number} already exists");
            }
        }

        [HttpGet("GET-average")]
        public IActionResult GetAverage()
        {
            double? average = numberList.GetAverage();
            if (average.HasValue)
            {
                return Ok(new { average = average.Value.ToString("F4") });
            }
            else
            {
                return NotFound("No numbers to calculate average");
            }
        }
    }
}
