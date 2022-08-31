using Microsoft.AspNetCore.Mvc;
using src.Models;

namespace src.Controllers;

[ApiController]
[Route("[controller]")]
public class PessoaController : ControllerBase
{

    [HttpGet]
    public Pessoa get()
    {
        Pessoa pessoa = new Pessoa("cinthia", 21, "12345678");
        Contrato contrato = new Contrato("abc123", 46.85);
        pessoa.contratos.Add(contrato);
        return pessoa;
    }

    [HttpPost]
    public Pessoa Post(Pessoa pessoa)
    {
        return pessoa;
    }

    [HttpPut("{id}")]
    public string Update(int id){
        return "Dados do id " + id + " atualizados";
    }
}