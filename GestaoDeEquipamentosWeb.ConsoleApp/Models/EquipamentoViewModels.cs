using GestaoDeEquipamentosWeb.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentosWeb.ConsoleApp.Models;

public record ListarEquipamentosViewModel(
    string Id,
    string Nome,
    decimal PrecoAquisicao,
    DateTime DataFabricacao,
    string Fabricante
);

public record CadastrarEquipamentosViewModel(
    string Nome,
    decimal PrecoAquisicao,
    DateTime DataFabricacao,
    string FabricanteId
);