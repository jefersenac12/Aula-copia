using Aula2407.Data;
using Aula2407.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Aula2407.Controllers
{
    public class ClienteController : Controller
    {
        //Contexto  do banco de dados para operaçao de Crud
        private readonly AulaContext _context;

        public ClienteController(AulaContext context)
        {
            _context = context;
        }
        //metodo pra BuscarCliente todos os Clientes e exibir numa View
        public async Task<IActionResult> BuscarClientes()
        {

            //retorna uma view com a lista de clientes
            return View(await _context.Clientes.ToListAsync());
        }
        // metodo pra exibir detalhes de um cliente especifico
        public async Task<IActionResult> DetalhesClientes(int Id)
        {

            // retorna uma view com os detalhes do clientes encontrado pelo id
            return View(await _context.Clientes.FindAsync(Id));
        }
        // metodo para cadastro de clientes . pode ser usado para criar ou editar.
        public async  Task<IActionResult> CadrastroCliente(int? Id)
        {
             // se o id for nulo, retorna uma  view vazia para cadastro de um novo cliente
          if(Id == null)
            {
                return View();
            }
           //se o id nao for nulo, retorna uma view com os dados do cliente para ediçao
          else 
            {
                return View(await _context.Clientes.FindAsync(Id));
            } 
        }
         //metodo para allterar os dados de um cliente existente
        public async Task <IActionResult> AlterarCliente(int Id)
        {
            //retorna uma view com os dados de um cliente para alteraçao
            return View(await _context.Clientes.FindAsync(Id));
        }
         // metodo para processar o formulario de cadastro de clientes
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> CadrastroCliente([Bind("Id,Nome,RG,CPF,Usuario,Senha,CEP,UF,Cidade,Bairro,Rua,Numero,Completo")] Cliente cliente)
        {    

            // verifica se o modelo e valido.
            if (ModelState.IsValid)
            {

                // se o id do cliente for diferente de zero,atualiza o cliente existente
                if(cliente.Id != 0)
                {
                 _context.Update(cliente);
                 await _context.SaveChangesAsync();
                }
                //se o id do cliente for zero,adiciona um novo cliente ao banco de dados
                else
                {
                    _context.Add(cliente);
                    await _context.SaveChangesAsync();
                }
                // redirediciona para o metodo  buscarClientes apos o cadastro ou atualizaçao
                return RedirectToAction("BuscarClientes");
            }
            // se o modelo nao for valido retorna a view com os dados do cliente para correçao
            return View(cliente);
        }
    }
}

