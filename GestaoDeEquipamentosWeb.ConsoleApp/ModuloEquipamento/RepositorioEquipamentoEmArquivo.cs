using GestaoDeEquipamentosWeb.ConsoleApp.Compartilhado;
using GestaoDeEquipamentosWeb.ConsoleApp.Compartilhado.Arquivos;
using GestaoDeEquipamentosWeb.ConsoleApp.ModuloChamado;

namespace GestaoDeEquipamentosWeb.ConsoleApp.ModuloEquipamento;

public class RepositorioEquipamentoEmArquivo :
    RepositorioBaseEmArquivo<Equipamento>, IRepositorio<Equipamento>
{
    public RepositorioEquipamentoEmArquivo(ContextoJson contexto) : base(contexto) { }

    protected override List<Equipamento> CarregarRegistros()
    {
        return contexto.Equipamentos;
    }

}
