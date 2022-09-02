using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace src.Controllers;

[ApiController]
[Route("[controller]")]
public class PessoaController : ControllerBase
{
    private DatabaseContext _context { get; set; }

    public PessoaController(DatabaseContext context)
    {
        this._context = context;
    }

    [HttpGet]
    public ActionResult<List<Pessoa>> get()
    {
        var result = _context.Pessoas.Include(x => x.contratos).ToList();
        if (!result.Any())
        {
            return NoContent();
        }

        return Ok(result);
    }

    [HttpPost]
    public ActionResult<Pessoa> Post(Pessoa pessoa)
    {
        _context.Pessoas.Add(pessoa);
        _context.SaveChanges();

        try
        {
            _context.Pessoas.Update(pessoa);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {
            return BadRequest();
        }

        return Created("Criado", pessoa);
    }

    [HttpPut("{id}")]
    public ActionResult<Object> Update(int id, Pessoa pessoa)
    {
        try
        {
            _context.Pessoas.Update(pessoa);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {
            return BadRequest(new
            {
                msg = "Houve um erro ao enviar a solicitação de atualiazção",
                status = HttpStatusCode.OK
            });
        }


        return Ok(new
        {
            msg = "Dados do id " + id + " atualizados",
            status = HttpStatusCode.OK
        });
    }

    [HttpDelete("{id}")]
    public ActionResult<Object> Delete(int id)
    {
        var result = _context.Pessoas.SingleOrDefault(x => x.Id == id);

        if (result is null)
        {
            return BadRequest(new
            {
                msg = "Conteúdo inexistente, não é possível prosseguir",
                status = "400"
            });
        }
        _context.Pessoas.Remove(result);
        _context.SaveChanges();

        return Ok("Pessoa do id " + id + " excluida!");
    }
}