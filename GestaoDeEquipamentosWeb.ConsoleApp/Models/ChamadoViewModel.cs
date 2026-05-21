using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.Timeouts;

namespace GestaoDeEquipamentosWeb.ConsoleApp.Models;

public record ListarChamadoViewModel(
    string Id,
    string Titulo,
    string Equipamento,
    DateTime DataAbertura,
    int TempoDecorrido,
    bool EstaConcluido
);

public record CadastrarChamadosViewModel(
    [Required(ErrorMessage = "O campo \"Título\" deve ser preenchido.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo \"Título\" deve conter entre 2 a 50 caracteres.")]
    string Titulo,
    [StringLength(500, ErrorMessage = "O campo \"Descrição\" deve conter no maximo 500 caracteres.")]
    string? Descricao,

    [Required(ErrorMessage = "O campo \"Equipamento\" deve ser preenchido.")]
    string EquipamentoId
);

public record EditarChamadoViewModel(
    string Id,
    [Required(ErrorMessage = "O campo \"Título\" deve ser preenchido.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo \"Título\" deve conter entre 2 a 50 caracteres.")]
    string Titulo,
    [StringLength(500, ErrorMessage = "O campo \"Descrição\" deve conter no maximo 500 caracteres.")]
    string? Descricao,

    [Required(ErrorMessage = "O campo \"Equipamento\" deve ser preenchido.")]
    string EquipamentoId
);

public record ExcluirChamadoViewModel(
    string Id,
    string Titulo,
    string? Descricao,
    string Equipamento,
    DateTime DataAbertura,
    int TempoDecorrido,
    bool EstaConcluido
);