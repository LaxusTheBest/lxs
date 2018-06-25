namespace Calc.Controllers
{
    using System;
    using System.Web.Mvc;

    /// <summary>
    /// Provides calculator functions 
    /// </summary>
    public class CalculatorController : Controller
    {
        /// <summary>
        /// Calculating based on the object properties
        /// </summary>
        /// <param name="calculator">Calculating object</param>
        /// <param name="logs">Previous logs</param>
        /// <returns>View with previous logs</returns>  
        public ActionResult Calculator(Models.CalculatorModel calculator = null, string logs = null)
        {
            if (calculator != null)
            {
                if (ModelState.IsValid)
                {
                    if (calculator.SelectedMethod == "Sum")
                    {
                        int res = this.Sum(calculator.X, calculator.Y);
                        ViewBag.logs = logs + $"Дата и время: {DateTime.Now.ToString()}     {calculator.X} + {calculator.Y} = {res} \n";
                    }

                    if (calculator.SelectedMethod == "Prod")
                    {
                        int res = this.Prod(calculator.X, calculator.Y);
                        ViewBag.logs = logs + $"Дата и время: {DateTime.Now.ToString()}     {calculator.X} * {calculator.Y} = {res} \n";
                    }

                    return this.View();
                }
                else
                {
                    ViewBag.NotValidMessage = "Данные не прошли валидацию";//todo pn строки-сообщения - в ресурсы
                    ViewBag.logs = logs;
                    return this.View();
                }
            }

            return this.View();
        }

        /// <summary>
        /// Summing two numbers
        /// </summary>
        /// <param name="x">first number</param>
        /// <param name="y">second number</param>
        /// <returns>Sum of numbers</returns>
        public int Sum(int x, int y) => x + y;

        /// <summary>
        /// Multiplies two numbers
        /// </summary>
        /// <param name="x">first number</param>
        /// <param name="y">second number </param>
        /// <returns>Product of numbers</returns>
        public int Prod(int x, int y) => y * x;
    }
}