using Aula2407.Data;
using Aula2407.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Aula2407.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly AulaContext _context;
        
        public IActionResult CadrastroProdutos()
        {
            return View();
        }
        public ProdutosController(AulaContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> DetalhesProdutos(int id)
        {
            return View(await _context.Produtos.FindAsync(id));
        }


        public async Task<IActionResult> BuscarProdutos()
        {
            return View(await _context.Produtos.ToListAsync());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> CadrastroProdutos([Bind("Id,Nome,Preco,validade_Pro,quatidade',valorUnitario,'valorTotal,")] Produtos produtos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produtos);
                await _context.SaveChangesAsync();
                return RedirectToAction("BuscarProdutos");
            }
            return View(produtos);
        }
    }
}

