using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Consulta
{
    public int Id { get; set; }
    public DateOnly Data { get; set; }
    public string Descricao { get; set; }
    public int PacienteId { get; set; }
    public int MedicoId { get; set; }


    //Construtor
    public Consulta(DateOnly dateTime, string descricao, int pacienteId, int medicoId)
    {
        Data = dateTime;
        Descricao = descricao;
        PacienteId = pacienteId;
        MedicoId = medicoId;
    }

    public Consulta()
    {

    }

}