using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Consulta
{
    public int? Id { get; set; }
    public DateTime DateTime { get; set; }
    public string Descricao { get; set; }


    //Construtor
    public Consulta( DateTime dateTime, string descricao)
    {
        DateTime = dateTime;
        Descricao = descricao;
    }

    public Consulta(){

    }

    public override string ToString()
    {
        return $"Id: {Id} | Data: {DateTime} | Descrição: {Descricao}";
    }
}