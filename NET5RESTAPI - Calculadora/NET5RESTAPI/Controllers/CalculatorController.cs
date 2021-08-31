using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NET5RESTAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
       

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

                // SOMA
        // Não podemos ter duas rotas iguais, senao terão o erro de ambiguidade.
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {

                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }


            // SUBTRAÇÃO
        // Não podemos ter duas rotas iguais, senao terão o erro de ambiguidade.
        [HttpGet("subtract/{firstNumber}/{secondNumber}")]
        public IActionResult Subtract(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {

                var subtract = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(subtract.ToString());
            }
            return BadRequest("Invalid Input");
        }


            // MULTIPLICAÇÃO
        // Não podemos ter duas rotas iguais, senao terão o erro de ambiguidade.
        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {

                var multiplicate = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(multiplicate.ToString());
            }
            return BadRequest("Invalid Input");
        }



        // Não podemos ter duas rotas iguais, senao terão o erro de ambiguidade.
        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Div(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {

                var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }


        // MÉDIA
        // Não podemos ter duas rotas iguais, senao terão o erro de ambiguidade.
        [HttpGet("media/{firstNumber}/{secondNumber}")]
        public IActionResult Media(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {

                var media = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                return Ok(media.ToString());
            }
            return BadRequest("Invalid Input");
        }


            // RAIZ QUADRADA
        // Não podemos ter duas rotas iguais, senao terão o erro de ambiguidade.
        [HttpGet("raiz/{firstNumber}")]
        public IActionResult Raiz(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {

                var raiz = Math.Sqrt((double)ConvertToDecimal(firstNumber));
                return Ok(raiz.ToString());
            }
            return BadRequest("Invalid Input");
        }


        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                    strNumber,
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.NumberFormatInfo.InvariantInfo,
                    out number
                );

            return isNumber;
        }
    }
}
