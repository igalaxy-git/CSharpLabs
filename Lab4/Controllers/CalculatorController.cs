using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Lab4.Data;
using Lab4.Models;

using Exception = System.Exception;

namespace Lab4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ApiContext _context;

        public CalculatorController(ApiContext context)
        {
            _context = context;
        }
        
        // Add operand or expression
        [Route("Add operand or expression")]
        [HttpPost]
        public JsonResult Operand(string expression)
        {
            NumberShell num = new NumberShell();
            if (IsDoubleRealNumber(expression))
            {
                num.Number = Convert.ToDouble(expression);
                _context.Numbers.Add(num);
            }
            else
            {
                try
                {
                    string result = Convert.ToDouble(new DataTable().Compute(expression, null)).ToString();
                    if (IsDoubleRealNumber(result))
                    {
                        num.Number = Convert.ToDouble(result);
                        _context.Numbers.Add(num);
                    }
                    else
                    {
                        throw new Exception("Not an expression!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }

            _context.SaveChanges();

            return new JsonResult(Ok(num));
        }
        
        // Add operator and operand
        [Route("Add operator and operand")]
        [HttpPost]
        public JsonResult Operator(string _operator, double operand)
        {
            NumberShell num = new NumberShell();
            num.Number = operand;

            try
            {
                switch (_operator)
                {
                    case "+":
                        num.Number = _context.Numbers.OrderBy(x=>x.Id).LastOrDefault().Number + operand;
                        break;
                    case "-":
                        num.Number = _context.Numbers.OrderBy(x=>x.Id).LastOrDefault().Number - operand;
                        break;
                    case "*":
                        num.Number = _context.Numbers.OrderBy(x=>x.Id).LastOrDefault().Number * operand;
                        break;
                    case "/":
                        num.Number = _context.Numbers.OrderBy(x=>x.Id).LastOrDefault().Number / operand;
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            
            
            _context.Numbers.Add(num);
            _context.SaveChanges();

            return new JsonResult(Ok(num));
        }
        
        // Get
        [Route("Get")]
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Numbers.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        // Delete
        /**
        [Route("Delete")]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Numbers.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            _context.Numbers.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }
        **/

        // Get all
        [Route("GetAll")]
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.Numbers.ToList();

            return new JsonResult(Ok(result));
        }
        
        private static bool IsDoubleRealNumber(string valueToTest)
        {
            if (double.TryParse(valueToTest, out double d) && !Double.IsNaN(d) && !Double.IsInfinity(d))
            {
                return true;
            }

            return false;
        }
        
    }
}