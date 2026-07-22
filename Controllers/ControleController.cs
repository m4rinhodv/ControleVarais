using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ControleVarais.ViewModels;
using ControleVarais.Repository;
using ControleVarais.Models;

namespace ControleVarais.Controllers;

public class ControleController : Controller
{
    private readonly IControleRepository _controleRepository;
    public ControleController(IControleRepository controleRepository)
    {
        _controleRepository = controleRepository;
    }

    public IActionResult Index()
    {

        var viewModel = new ClientesViewModel
        {
            ClientesHoje = _controleRepository.BuscarClientesHoje(),
            ClientesTotais = _controleRepository.BuscarClientes()
        };

        return View(viewModel);
    }

    public IActionResult Excluir(int id)
    {
        _controleRepository.Excluir(id);
        return RedirectToAction("Index");
    }

    public IActionResult Editar(int id)
    {
        var cliente = _controleRepository.Editar(id);
        return View(cliente);
    }



    public IActionResult Adicionar()
    {
        return View();
    }

    public IActionResult SalvarEdit(ClientesModels cliente)
    {

        _controleRepository.SalvarEdit(cliente);
        return RedirectToAction("Index");
    }


    [HttpPost]
    public IActionResult Adicionar(ClientesModels cliente)
    {
        cliente.DataCadastro = DateTime.UtcNow;
        _controleRepository.Adicionar(cliente);
        return RedirectToAction("Index");
    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}