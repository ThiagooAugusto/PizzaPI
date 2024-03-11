
using Microsoft.AspNetCore.Mvc;
using PizzaPi.Models;
using PizzaPi.Services;
namespace PizzaPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController
    {
        public PizzaController() { }
        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() =>
    PizzaService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza == null)
                return new NotFoundResult();

            return pizza;
        }

        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            PizzaService.Add(pizza);
            return new CreatedAtActionResult(nameof(Get),"pizza", new { id = pizza.Id }, pizza);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            if(id != pizza.Id)
                    return new BadRequestResult();

            var existingPizza = PizzaService.Get(id);
            if (existingPizza == null)
                return new NotFoundResult();

            PizzaService.Update(pizza);
            return new NoContentResult();
            
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var existingPizza = PizzaService.Get(id);

            if (existingPizza == null)
                return new NotFoundResult();
            PizzaService.Delete(id);
            return new NoContentResult();
        }

    }
}
