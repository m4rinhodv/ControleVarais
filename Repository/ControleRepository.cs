using ControleVarais.Data;
using ControleVarais.Enum;
using ControleVarais.Models;


namespace ControleVarais.Repository.ControleRepository;

public class ControleRepository : IControleRepository
{
    private readonly BancoContext _bancoContext;
    public ControleRepository(BancoContext bancoContext)
    {
        _bancoContext = bancoContext;
    }

    public ClientesModels Adicionar(ClientesModels cliente)
    {
        _bancoContext.Add(cliente);
        _bancoContext.SaveChanges();
        return cliente;
    }

    public List<ClientesModels> BuscarClientes()
    {
        return _bancoContext.Clientes.ToList();
    }

    public int ClientesHoje()
    {
        return _bancoContext.Clientes.Count(c => c.DataCadastro.Date == DateTime.Today);
    }

    public ClientesModels Editar(int id)
    {
        var cliente = _bancoContext.Clientes.FirstOrDefault(x => x.Id == id);
        return cliente;
    }

    public bool Excluir(int id)
    {
        ClientesModels? clienteDb = _bancoContext.Clientes.FirstOrDefault(x => x.Id == id);

        if (clienteDb == null)
        {
            throw new Exception("Contato não encontrado");
        }

        _bancoContext.Clientes.Remove(clienteDb);
        _bancoContext.SaveChanges();

        return true;
    }

    public bool SalvarEdit(ClientesModels clienteAlterado)
    {
        // 1. Busca o cliente existente no banco pelo ID
        ClientesModels? clienteDb = _bancoContext.Clientes.FirstOrDefault(x => x.Id == clienteAlterado.Id);

        if (clienteDb == null)
        {
            throw new Exception("Contato não encontrado");
        }

        // 2. Atualiza apenas os campos necessários do registro existente
        clienteDb.Nome = clienteAlterado.Nome;
        clienteDb.Endereco = clienteAlterado.Endereco;
        clienteDb.Telefone = clienteAlterado.Telefone;
        clienteDb.Status = clienteAlterado.Status;
        clienteDb.Observacoes = clienteAlterado.Observacoes;

        // 3. Salva as alterações (o EF sabe que é um UPDATE porque o clienteDb veio do banco)
        _bancoContext.SaveChanges();
        return true;
    }
}