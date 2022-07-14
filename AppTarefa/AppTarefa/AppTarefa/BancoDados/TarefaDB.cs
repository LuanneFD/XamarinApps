using AppTarefa.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTarefa.BancoDados
{
  public class TarefaDB
  {
    private BancoContext Banco { get; set; }
    public TarefaDB()
    {
      Banco = new BancoContext();
    }

    public async Task<List<Tarefa>> PesquisarPorDataAsync(DateTime data)
    {
      return await Banco.TarefasApp.Where(t =>
         t.Data.HasValue &&
         t.Data.Value.Year == data.Year &&
         t.Data.Value.Month == data.Month &&
         t.Data.Value.Date == data.Date
        ).ToListAsync();
    }

    public async Task<bool> InserirAsync(Tarefa tarefa)
    {
      Banco.TarefasApp.Add(tarefa);
      int linha = await Banco.SaveChangesAsync();
      return linha > 0;
    }

    public async Task<bool> AlterarAsync(Tarefa tarefa)
    {
      Banco.TarefasApp.Update(tarefa);
      int linha = await Banco.SaveChangesAsync();
      return linha > 0;
    }

    public async Task<bool> ExcluirAsync(int id)
    {
      Tarefa tarefa = await ConsultarAsync(id);
      Banco.TarefasApp.Remove(tarefa);
      int linha = await Banco.SaveChangesAsync();
      return linha > 0;
    }

    public async Task<Tarefa> ConsultarAsync(int id)
    {
      return await Banco.TarefasApp.FindAsync(id);
    }
  }
}
