using ControleVarais.Models;
using ControleVarais.Enum;
namespace ControleVarais.Repository;

public interface IControleRepository
{
    List<ClientesModels> BuscarClientes();
    ClientesModels Adicionar(ClientesModels clientes);
    ClientesModels Editar(int id);
    bool SalvarEdit(ClientesModels cliente);
    bool Excluir(int id);
}