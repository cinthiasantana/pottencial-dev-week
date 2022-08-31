namespace src.Models;
using System.Collections.Generic;
public class Pessoa
{
    public Pessoa(){
        this.Nome = "template";
        this.Idade = 0;
        this.contratos = new List<Contrato>();
        this.Ativado = true;
    }

    public Pessoa(string nome, int idade, string cpf){
        this.Nome = nome;
        this.Idade = idade;
        this.Cpf = cpf;
        this.contratos = new List<Contrato>();
        this.Ativado = true;
    }

    public int Id { get; set; }
    public string Nome {get; set;}
    public int Idade { get; set; }
    public string? Cpf { get; set; }
    public bool Ativado { get; set; }
    public List<Contrato> contratos { get; set; }
}