using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Consulta
{
    public int Id { get; set; }
    public DateOnly Data { get; set; }
    public string Descricao { get; set; }
    public int PacienteId { get; set; }
    public int FuncionarioId { get; set; }


    //Construtor
    public Consulta( DateOnly dateTime, string descricao)
    {
        Data = dateTime;
        Descricao = descricao;
    }

    public Consulta(){

    }

    public void ToString()
    {
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("Id: " + Id);
        Console.WriteLine("" + Data.ToString());
        Console.WriteLine("" + Descricao);

    }
}