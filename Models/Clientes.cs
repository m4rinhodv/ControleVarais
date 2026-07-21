using System;
using ControleVarais.Enum;

namespace ControleVarais.Models;

public class ClientesModels
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Endereco { get; set; }
    public string? Telefone { get; set; }
    public StatusOrcamento Status { get; set; }
    public string? Observacoes { get; set; }



}