using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingList.Models;

namespace ShoppingList.Pages.Items
{
    public class ResponseModel : PageModel
    {
        private readonly ShoppingList.Data.ShoppingListContext _context;
        
        public ResponseModel(ShoppingList.Data.ShoppingListContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public List List { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.List.Add(List);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
