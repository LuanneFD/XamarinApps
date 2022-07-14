using AppTarefa.Modelos;
using Microsoft.EntityFrameworkCore;

namespace AppTarefa.BancoDados
{
  public class BancoContext : DbContext
  {
    public DbSet<Tarefa> TarefasApp { get; set; }

    public BancoContext()
    {
      //ctor tab -> gera construtor
      //Database.EnsureCreated(); //Garantia que o bd esteja criado.
      Database.Migrate(); //cria o bd e verifica se existem novas migrations para serem executadas.
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite($"FileName={Constantes.CaminhoDoBanco}");
    }
  }
}
