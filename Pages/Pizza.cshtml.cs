using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesPizza.Models;
using RazorPagesPizza.Services;

namespace RazorPagesPizza.Pages
{
    public class PizzaModel : PageModel
    {
        [BindProperty]
        public Pizza NewPizza { get; set; } = new();
        public List<Pizza> pizzas=new();
        public void OnGet()
        {
            pizzas=PizzaService.GetAll();
        }

        public string GlutenFreeText(Pizza pizza)
        {
            return pizza.IsGlutenFree ? "Gluten Free": "Not Gluten Free";
        }
        //Vérifier les donnée envoyé par l'utilisateur publiée dans le "PageModel" sont valide
        //présenté à nv l'utilisateur si les modifications  apporté à "PageModel" ne sont pas valide
        //si la m-a-j est valide => les changement de donnée sont passé au service appelé PizzaService 
        //PizzaService gere les requetes http et les reponse envoyée à API Web
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            PizzaService.Add(NewPizza);
            return RedirectToAction("Get");
        }
        public IActionResult OnPostDelete(int id)
        {
            PizzaService.Delete(id);
            return RedirectToAction("Get");
        }

        
    }
}
