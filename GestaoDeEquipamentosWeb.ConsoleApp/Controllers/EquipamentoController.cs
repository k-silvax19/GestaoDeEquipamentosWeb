using System.Diagnostics.Tracing;
using GestaoDeEquipamentosWeb.ConsoleApp.Compartilhado;
using GestaoDeEquipamentosWeb.ConsoleApp.Compartilhado.Arquivos;
using GestaoDeEquipamentosWeb.ConsoleApp.Models;
using GestaoDeEquipamentosWeb.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentosWeb.ConsoleApp.ModuloFabricante;
using Microsoft.AspNetCore.Mvc;
namespace GestaoDeEquipamentosWeb.ConsoleApp.Controllers;

public class EquipamentoController : Controller
{
    private readonly IRepositorio<Equipamento> repositorioEquipamento;
    private readonly IRepositorio<Fabricante> repositorioFabricante;
    public EquipamentoController()
    {
        ContextoJson contexto = new ContextoJson();
        contexto.Carregar();

        repositorioEquipamento = new RepositorioEquipamentoEmArquivo(contexto);
        repositorioFabricante = new RepositorioFabricanteEmArquivo(contexto);
    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<Equipamento> equipamentos = repositorioEquipamento.SelecionarTodos();

        List<ListarEquipamentosViewModel> listarVms = new List<ListarEquipamentosViewModel>();

        foreach (Equipamento e in equipamentos)
        {
            ListarEquipamentosViewModel viewModel = new ListarEquipamentosViewModel(
                e.Id,
                e.Nome,
                e.PrecoAquisicao,
                e.DataFabricacao,
                e.Fabricante.Nome
            );

            listarVms.Add(viewModel);
        }

        return View(listarVms);
    }
    [HttpGet]

    public ActionResult Cadastrar()
    {
        ViewBag.Fabricantes = CarregarFabricantes();

        return View();
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarEquipamentosViewModel cadastrarVm)
    {
        Fabricante? fabricante = repositorioFabricante.SelecionarPorId(cadastrarVm.FabricanteId);

        if (fabricante == null)
            return RedirectToAction(nameof(Listar));

        Equipamento novoEquipamento = new Equipamento(
            cadastrarVm.Nome,
            cadastrarVm.PrecoAquisicao,
            cadastrarVm.DataFabricacao,
            fabricante
        );

        repositorioEquipamento.Cadastrar(novoEquipamento);

        return RedirectToAction(nameof(Listar));
    }

    private List<ListarFabricanteViewModel> CarregarFabricantes()
    {
        List<Fabricante> fabricantes = repositorioFabricante.SelecionarTodos();

        List<ListarFabricanteViewModel> listarVms = new List<ListarFabricanteViewModel>();

        foreach (Fabricante f in fabricantes)
        {
            ListarFabricanteViewModel viewModel = new ListarFabricanteViewModel(
                f.Id,
                f.Nome,
                f.Email,
                f.Telefone
            );

            listarVms.Add(viewModel);
        }

        return listarVms;
    }
}