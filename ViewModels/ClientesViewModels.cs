using ControleVarais.Models;

namespace ControleVarais.ViewModels
{
    public class ClientesViewModel
    {
        public List<ClientesModels> ClientesHoje { get; set; } = new List<ClientesModels>();

        public List<ClientesModels> ClientesTotais { get; set; } = new List<ClientesModels>();
    }
}