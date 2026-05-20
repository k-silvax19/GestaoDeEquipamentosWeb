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

public record EditarEquipamentosViewModel(
    string Id,
    string Nome,
    decimal PrecoAquisicao,
    DateTime DataFabricacao,
    string FabricanteId
);

public record ExcluirEquipamentosViewModel(
    string Id,
    string Nome,
    decimal PrecoAquisicao,
    DateTime DataFabricacao,
    string Fabricante
);