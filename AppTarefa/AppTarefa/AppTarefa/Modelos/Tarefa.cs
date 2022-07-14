using System;

namespace AppTarefa.Modelos
{
  public class Tarefa
  {
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime? Data { get; set; }
    public TimeSpan HoraInicial { get; set; }
    public TimeSpan HoraFinal { get; set; }
    public string Nota { get; set; }
    public bool Finalizada { get; set; }
    public string Prioridade { get; set; }
  }
}
