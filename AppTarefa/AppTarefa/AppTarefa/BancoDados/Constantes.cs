using System;
using System.IO;

namespace AppTarefa.BancoDados
{
  public static class Constantes
  {
    public const string NomeDoArquivo = "AppTarefa.db3";

    public static string CaminhoDoBanco
    {
      get
      {
        //Pasta onde o app está instalado no aparelho e o app pode escrever/armazenar dados
        var caminhoBase = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        return Path.Combine(caminhoBase, NomeDoArquivo);
      }
    }
  }
}
