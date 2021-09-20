using Cadastro_de_Filme;
using System;
using Cadastro_de_Series;

namespace Cadastro_de_Series
{
    class Program 
    {
        static SerieRepositorio repositorio = new SerieRepositorio();


		static void Main(string[] args)
		{
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeries();						
						break;
					case "3":
						InserirSerie();
						break;
					case "5":
						AtualizarSerie();
						break;
					case "7":
						ExcluirSerie();
						break;
					case "9":
						VisualizarSerie();
						break;


					case "2":
						ListarFilmes();
						break;
					case "4":
						InserirFilme();
						break;
					case "6":
						AtualizarFilme();
						break;
					case "8":
						ExcluirFilme(); 
						break;
					case "10":
						VisualizarFilme();
						break;

					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}
					       

		private static void ExcluirSerie()
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("Digite o id da Série: ");
			Console.ResetColor();
			int indiceSerie = int.Parse(Console.ReadLine());

			var lista = repositorio.Lista();
			if (lista.Count == 0)
			{
				Console.WriteLine("Id inexistente.");
				return;
			}

			repositorio.Exclui(indiceSerie);
		}

		private static void VisualizarSerie()
		{
			Console.WriteLine("--------------------------------");

			Console.ForegroundColor = ConsoleColor.Blue;
			Console.Write("Digite o id da Série: ");
			Console.ResetColor();
			int indiceSerie = int.Parse(Console.ReadLine());

			var lista = repositorio.Lista();
			if (lista.Count == 0)
			{
				Console.WriteLine("Id inexistente.");
				return;
			}

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			Console.WriteLine("--------------------------------");

			Console.ForegroundColor = ConsoleColor.Blue;
			Console.Write("Digite o id da Série: ");			
			Console.ResetColor();
			int indiceSerie = int.Parse(Console.ReadLine());


			var lista = repositorio.Lista();
			if (lista.Count == 0)
			{
				Console.WriteLine("Id inexistente.");
				return;
			}


			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

			Console.ForegroundColor = ConsoleColor.Blue;
			Console.Write("Digite o gênero entre as opções acima: ");
			Console.ResetColor();
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.ForegroundColor = ConsoleColor.Blue;
			Console.Write("Digite o Título da Série: ");
			Console.ResetColor();
			string entradaTitulo = Console.ReadLine();

			Console.ForegroundColor = ConsoleColor.Blue;
			Console.Write("Digite o Ano de Início da Série: ");
			Console.ResetColor();
			int entradaAno = int.Parse(Console.ReadLine());

			Console.ForegroundColor = ConsoleColor.Blue;
			Console.Write("Digite a Descrição da Série: ");
			Console.ResetColor();
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}

        private static void ListarSeries()
		{
			
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("Listar Série");
			Console.ResetColor();

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}


			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();

				
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));				
			}
		}

        private static void InserirSerie()
		{
			Console.WriteLine("--------------------------------");

			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("Inserir nova Série");
			Console.ResetColor();

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

			Console.ForegroundColor = ConsoleColor.Blue;
			Console.Write("Digite o gênero entre as opções acima: ");
			Console.ResetColor();
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.ForegroundColor = ConsoleColor.Blue;
			Console.Write("Digite o Título da Série: ");
			Console.ResetColor();
			string entradaTitulo = Console.ReadLine();

			Console.ForegroundColor = ConsoleColor.Blue;
			Console.Write("Digite o Ano de Início da Série: ");
			Console.ResetColor();
			int entradaAno = int.Parse(Console.ReadLine());

			Console.ForegroundColor = ConsoleColor.Blue;
			Console.Write("Digite a Descrição da Série: ");
			Console.ResetColor();
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		}
		        


         static FilmeRepositorio repositorios = new FilmeRepositorio();


        private static void ExcluirFilme()
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("Digite o id do Filme: ");
			Console.ResetColor();
			int indiceFilme = int.Parse(Console.ReadLine());

			var lista = repositorio.Lista();
			if (lista.Count == 0)
			{
				Console.WriteLine("Id inexistente.");
				return;
			}

			repositorios.Exclui(indiceFilme);
		}

		private static void VisualizarFilme()
		{
			Console.WriteLine("--------------------------------");

			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.Write("Digite o id do Filme: ");
			Console.ResetColor();
			int indiceFilme = int.Parse(Console.ReadLine());

			var lista = repositorio.Lista();
			if (lista.Count == 0)
			{
				Console.WriteLine("Id inexistente.");
				return;
			}

			var filme = repositorios.RetornaPorId(indiceFilme);
						
			Console.WriteLine(filme);
		}

		private static void AtualizarFilme()
		{
			Console.WriteLine("--------------------------------");

			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.Write("Digite o id do Filme: ");
			Console.ResetColor();
			int indiceFilme = int.Parse(Console.ReadLine());

			var lista = repositorio.Lista();
			if (lista.Count == 0)
			{
				Console.WriteLine("Id inexistente.");
				return;
			}


			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.Write("Digite o gênero entre as opções acima: ");
			Console.ResetColor();
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.Write("Digite o Título do Filme: ");
			Console.ResetColor();
			string entradaTitulo = Console.ReadLine();

			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.Write("Digite o Ano de Início do Filme: ");
			Console.ResetColor();
			int entradaAno = int.Parse(Console.ReadLine());

			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.Write("Digite a Descrição do Filme: ");
			Console.ResetColor();
			string entradaDescricao = Console.ReadLine();

			Filme atualizaFilme = new Filme(id: indiceFilme,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorios.Atualiza(indiceFilme, atualizaFilme);

		}

		private static void ListarFilmes()
		{

			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine("Listar Filmes");
			Console.ResetColor();

			var lista = repositorios.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum filme cadastrado.");
				return;
			}

			foreach (var filme in lista)
			{
				var excluido = filme.retornaExcluido();

				Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

		private static void InserirFilme()
		{
			Console.WriteLine("--------------------------------");

			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine("Inserir novo Filme");			
			Console.ResetColor();

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.Write("Digite o gênero entre as opções acima: ");
			Console.ResetColor();
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.Write("Digite o Título do Filme: ");
			Console.ResetColor();
			string entradaTitulo = Console.ReadLine();

			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.Write("Digite o Ano de Início do Filme: ");
			Console.ResetColor();
			int entradaAno = int.Parse(Console.ReadLine());

			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.Write("Digite a Descrição do Filme: ");
			Console.ResetColor();
			string entradaDescricao = Console.ReadLine();

			

			Filme novoFilme = new Filme(id: repositorios.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorios.Insere(novoFilme);

		}

		     

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine("--------------------------------");
									
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");
			Console.ResetColor();
			Console.WriteLine("");

			Console.WriteLine("1- Listar Séries");			
			Console.WriteLine("2- Listar Filmes");
			Console.WriteLine("");
			Console.WriteLine("3- Inserir nova Série"); 
			Console.WriteLine("4- Inserir novo Filme");
			Console.WriteLine("");
			Console.WriteLine("5- Atualizar Série"); 
			Console.WriteLine("6- Atualizar Filme");
			Console.WriteLine("");

			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("7- Excluir Série"); 
			Console.WriteLine("8- Excluir Filme");
			Console.ResetColor();
			Console.WriteLine("");

			Console.WriteLine("9- Visualizar Série"); 
			Console.WriteLine("10- Visualizar Filme");
			Console.WriteLine("");

			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.ResetColor();
			Console.WriteLine("--------------------------------"); 

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
			
		}
	}
}
