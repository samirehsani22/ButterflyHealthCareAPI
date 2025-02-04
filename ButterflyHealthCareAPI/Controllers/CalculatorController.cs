using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ButterflyHealthCareAPI.Controllers
{
    /// <summary>
    /// Provides calculator operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        /// <summary>
        /// Adds two numbers.
        /// </summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <returns>The sum of the two numbers.</returns>
        [HttpPost("Add")]                                         // [Required] force user to provide the parameters
        public IActionResult Add([Required] int firstNumber, [Required] int secondNumber)
        {
            return Ok(firstNumber + secondNumber);
        }

        /// <summary>
        /// Substracting second number from the first number, returning the result
        /// </summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <returns></returns>
        [HttpPost("Substract")]
        public IActionResult Substract([Required] int firstNumber, [Required] int secondNumber)
        {
            return Ok(firstNumber - secondNumber);
        }

        /// <summary>
        /// Multiplying the numbers, returning the result
        /// </summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <returns></returns>
        [HttpPost("multiply")]
        public IActionResult multiply([Required] int firstNumber, [Required] int secondNumber)
        {
            return Ok(firstNumber * secondNumber);
        }

        /// <summary>
        /// Dividing the first number on the second number, returning the result
        /// </summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <returns></returns>
        [HttpPost("divide")]
        public IActionResult divide([Required] int firstNumber, [Required] int secondNumber)
        {
            if (secondNumber == 0)
                return BadRequest("Division by zero is not allowed.");

            return Ok(firstNumber / secondNumber);
        }
    }
}
