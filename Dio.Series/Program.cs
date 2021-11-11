using System;
using System.Collections.Generic;

namespace Dio.Series
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Seja Bem-Vindo a DIO SERIES! \n");

            string opcao_usuario = obter_opcaousuario();

            SerieRepositorio ListaSeries =new SerieRepositorio();

            while (opcao_usuario.ToUpper() != "X")
            {
                switch (opcao_usuario)
                {
                    case "1":
                        if (ListaSeries.ProximoId() == 0)
                            {
                                Console.WriteLine("Não há séries armazenadas no sistema.\n");
                                break;                          
                            }

                                            

                        foreach (Serie series_Cadastradas in ListaSeries.Lista())
                            {
                                bool statusExclusao = series_Cadastradas.retornaExlcuido();
                                Console.WriteLine("#{0} - {1} {2}",series_Cadastradas.retornaID(), series_Cadastradas.retornaTitulo(), (statusExclusao ? "*Excluído*":""));
                                
                            }

                        break;

                    case "2":

                        Console.WriteLine("Digite o Gênero da Série conforme a lista abaixo:");                                                
                        
                        foreach (int i in Enum.GetValues(typeof(Genero)))
                            Console.WriteLine("#{0} - {1}",i,Enum.GetNames(typeof(Genero))[i-1]);

                        int genero = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite o Título da Série:");
                        string titulo = Console.ReadLine();
                        Console.WriteLine("Descrição:");
                        string descricao = Console.ReadLine();
                        Console.WriteLine("Digite o Ano da Série:");
                        int ano = int.Parse(Console.ReadLine());

                        Serie novaSerie = new Serie(id:ListaSeries.ProximoId(),
                                                    titulo: titulo,
                                                    genero: (Genero) genero,
                                                    ano: ano,
                                                    descricao: descricao);

                        ListaSeries.Insere(novaSerie);

                        break;

                    case "3":
                        Console.WriteLine("Digite o Código da Série para Atualização:");
                        int cd_serie = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite o Gênero da Série conforme a lista abaixo:");                                                
                        
                        foreach (int i in Enum.GetValues(typeof(Genero)))
                            Console.WriteLine("#{0} - {1}",i,Enum.GetNames(typeof(Genero))[i-1]);

                        int genero_novo = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite o Título da Série:");
                        string titulo_novo = Console.ReadLine();
                        Console.WriteLine("Descrição:");
                        string descricao_novo = Console.ReadLine();
                        Console.WriteLine("Digite o Ano da Série:");
                        int ano_novo = int.Parse(Console.ReadLine());

                        Serie atualiza_serie = new Serie(id:cd_serie,
                                                    titulo: titulo_novo,
                                                    genero: (Genero) genero_novo,
                                                    ano: ano_novo,
                                                    descricao: descricao_novo);
       
                        ListaSeries.Atualiza(cd_serie, atualiza_serie);


                        break;

                    case "4":
                        Console.WriteLine("Digite o Código da Série para Exclusão:");
                        int codigo_serie = int.Parse(Console.ReadLine());
                        ListaSeries.Excluir(codigo_serie);
                        break;

                    case "5":
                        Console.WriteLine("Digite o Código da Série para Visualizar:");
                        int cd_serie_visual = int.Parse(Console.ReadLine());
                        
                        var series = ListaSeries.Lista();

                        Console.WriteLine(series[cd_serie_visual].ToString()+"\n");

                        break;

                    case "C":
                        Console.Clear();
                        break;                                       

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcao_usuario = obter_opcaousuario();
            }
            //Opção X ou x:
            Console.WriteLine("Obrigado por utilizar a plataforma de Series da DIO!");
            Console.ReadLine();

        }

        private static string obter_opcaousuario()
        {
            Console.WriteLine("Digite a opção desejada:" +
                             "\n 1 - Listar Séries" +
                             "\n 2  -Inserir Nova Série" +
                             "\n 3 - Atualizar Série" +
                             "\n 4 - Excluir Série" +
                             "\n 5 - Visualizar Série" +
                             "\n C - Limpar Console" +
                             "\n X- Sair");

            string opcao_usuario = Console.ReadLine();
            return opcao_usuario;
        }
    }
}
