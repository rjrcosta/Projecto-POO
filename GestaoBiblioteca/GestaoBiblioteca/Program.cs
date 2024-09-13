using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestaoBiblioteca
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Biblioteca biblioteca = new Biblioteca();
            InicializarObjectos(biblioteca);



            //Console.WriteLine(DateTime.Now.DayOfWeek.ToString());
            //Console.WriteLine((int)DateTime.Now.DayOfWeek);

            int opcao1;
            string titulo = "";
            string autor = "";
            int ano = 0;
            int exemplares = 0;

            while (true)
            {
                menuInicial();
                string opcao = Console.ReadLine();

                switch (validacaoInt(opcao))
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Nome do Usuário: ");
                        string nome = Console.ReadLine();
                        Console.Write("Endereço: ");
                        string endereco = Console.ReadLine();
                        Console.Write("Telefone: ");
                        string telefone = Console.ReadLine();
                        Console.Write("Identificador: ");
                        string id = Console.ReadLine();
                        Console.Write("Senha: ");
                        string pass = Console.ReadLine();

                        Utilizador.usuarios.Add(new Utente(nome, endereco, telefone, id, pass));

                        break;


                    case 2:
                        Console.Clear();
                        Console.WriteLine("Bem-vindo à Biblioteca. Faça login.");
                        Console.Write("Identificador: ");
                        string identificador = Console.ReadLine();
                        Console.Write("Senha: ");
                        string senha = Console.ReadLine();

                        var usuarioLogado = Utilizador.Login(identificador, senha);

                        if (usuarioLogado != null)
                        {
                            if (usuarioLogado is Funcionario funcionario) // Menu para Funcionário
                            {

                                Console.Clear();
                                string opcaoFuncionario;
                                do
                                {

                                    Console.WriteLine("Menu Funcionário:");
                                    Console.WriteLine("1. Registrar Livro");
                                    Console.WriteLine("2. Registrar Usuário");
                                    Console.WriteLine("3. Emprestar Livro");
                                    Console.WriteLine("4. Devolver Livro");
                                    Console.WriteLine("5. Consultar Livros Disponíveis");
                                    Console.WriteLine("6. Relatório de Empréstimos");
                                    Console.WriteLine("0. Sair");
                                    Console.Write("Escolha uma opção: ");

                                    opcaoFuncionario = Console.ReadLine();

                                    switch (validacaoInt(opcaoFuncionario))
                                    {

                                        case 1:
                                            RegistarLivro(biblioteca);
                                            funcionario.RegistrarLivros(biblioteca, titulo, autor, ano, exemplares);
                                            break;
                                        case 2:
                                            Console.Clear();
                                            Console.Write("Nome do Usuário: ");
                                            nome = Console.ReadLine();
                                            Console.Write("Endereço: ");
                                            endereco = Console.ReadLine();
                                            Console.Write("Telefone: ");
                                            telefone = Console.ReadLine();
                                            Console.Write("Identificador: ");
                                            id = Console.ReadLine();
                                            Console.Write("Senha: ");
                                            pass = Console.ReadLine();
                                            funcionario.RegistrarUsuario(nome, endereco, telefone, id, pass);
                                            break;
                                        case 3:
                                            Console.Clear();
                                            Console.Write("Título do Livro: ");
                                            string tituloLivro = Console.ReadLine();
                                            Console.Write("Nome do Usuário: ");
                                            string nomeEmprestimo = Console.ReadLine();
                                            funcionario.EmprestarLivro(biblioteca, tituloLivro, nomeEmprestimo);
                                            break;
                                        case 4:
                                            Console.Clear();
                                            Console.Write("Título do Livro: ");
                                            string tituloDevolucao = Console.ReadLine();
                                            Console.Write("Nome do Usuário: ");
                                            string nomeDevolucao = Console.ReadLine();
                                            funcionario.DevolverLivro(biblioteca, tituloDevolucao, nomeDevolucao);
                                            break;
                                        case 5:

                                            funcionario.ConsultarDisponibilidade(biblioteca);
                                            break;
                                        case 6:
                                            Console.Clear();
                                            funcionario.GerarRelatorioEmprestimos(biblioteca);
                                            break;
                                        case 0:
                                            Console.Clear();
                                            Console.WriteLine("Saindo...");
                                            break;
                                        default:
                                            Console.WriteLine("Opção inválida.");
                                            break;
                                    }
                                } while (validacaoInt(opcaoFuncionario) != 0);
                            }
                            else if (usuarioLogado is Utente usuario) // Menu para Usuário
                            {
                                string opcaoUsuario;
                                Console.Clear();
                                do
                                {
                                    Console.WriteLine("Menu Usuário:");
                                    Console.WriteLine("1. Consultar Livros Disponíveis");
                                    Console.WriteLine("2. Histórico de Empréstimos");
                                    Console.WriteLine("0. Sair");
                                    Console.Write("Escolha uma opção: ");
                                    opcaoUsuario = Console.ReadLine();

                                    switch (validacaoInt(opcaoUsuario))
                                    {
                                        case 1:
                                            Console.Clear();
                                            usuario.ConsultarDisponibilidade(biblioteca);
                                            break;
                                        case 2:
                                            Console.Clear();
                                            usuario.HistoricoEmprestimos(biblioteca);
                                            break;
                                        case 0:
                                            
                                            Console.WriteLine("Saindo...");
                                            break;
                                        default:
                                            Console.WriteLine("Opção inválida.");
                                            break;
                                    }
                                } while (validacaoInt(opcaoUsuario) != 0);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Login inválido. Tente novamente.");
                        }
                        break;
                    default:
                        Console.WriteLine("Opção não é válida. Escolha 1 ou 2");
                        break;
                }
             
                

              
            
                }


        }
        //Inicializar Livros, Funcionarios e Utentes
        static void InicializarObjectos(Biblioteca biblioteca)
        {
            biblioteca.RegistrarLivro(new Livro("1984", "George Orwell", 1949, 5));
            biblioteca.RegistrarLivro(new Livro("Moby Dick", "Herman Melville", 1851, 3));
            biblioteca.RegistrarLivro(new Livro("O Senhor dos Anéis", "J.R.R. Tolkien", 1954, 4));
            biblioteca.RegistrarLivro(new Livro("Orgulho e Preconceito", "Jane Austen", 1813, 2));
            biblioteca.RegistrarLivro(new Livro("O Sol é para Todos", "Harper Lee", 1960, 6));
            biblioteca.RegistrarLivro(new Livro("Dom Quixote", "Miguel de Cervantes", 1605, 3));
            biblioteca.RegistrarLivro(new Livro("Guerra e Paz", "Lev Tolstói", 1869, 4));
            biblioteca.RegistrarLivro(new Livro("O Pequeno Príncipe", "Antoine de Saint-Exupéry", 1943, 7));
            biblioteca.RegistrarLivro(new Livro("Cem Anos de Solidão", "Gabriel García Márquez", 1967, 5));
            biblioteca.RegistrarLivro(new Livro("O Grande Gatsby", "F. Scott Fitzgerald", 1925, 3));
            Utilizador.usuarios.Add(new Utente("Ana Costa", "Rua A, 123", "1234-5678", "ana.costa", "senha123"));
            Utilizador.usuarios.Add(new Utente("Carlos Silva", "Avenida B, 456", "9876-5432", "carlos.silva", "senha456"));
            Utilizador.usuarios.Add(new Utente("Fernanda Oliveira", "Praça C, 789", "1357-2468", "fernanda.oliveira", "senha789"));
            Utilizador.funcionarios.Add(new Funcionario("João Pereira", "Estrada D, 101", "2468-1357", "joao.pereira", "senha012"));
            Utilizador.funcionarios.Add(new Funcionario("Mariana Santos", "Largo E, 202", "8642-7531", "mariana.santos", "senha345"));
            Utilizador.funcionarios.Add(new Funcionario("José Carlos Silva", "Avenida B, 456", "9876-5432", "jose.carlos", "senha456"));

            //Usuario teste
            Utilizador.funcionarios.Add(new Funcionario("teste", "Avenida B, 456", "9876-5432", "t", "t"));

        }

        //************************************ Métodos
        //Função para validar inteiros
        static int validacaoInt(string y)
        {
            while (true)
            {
                if (int.TryParse(y, out int x))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("caractere inválido");
                    y = Console.ReadLine();
                }
            }
            int yInt = int.Parse(y);

            return yInt;
        }

        //Menu Inicial
        static void menuInicial()
        {
            Console.WriteLine("Bem-Vindo a Bilbioteca Ler é Crescer");
            Console.WriteLine("1- registar usuario");
            Console.WriteLine("2- Login ");
           
        }
        static Livro RegistarLivro(Biblioteca biblioteca)
        {
            Console.Clear();
            Console.Write("Título: ");
            string titulo = Console.ReadLine();
            Console.Write("Autor: ");
            string autor = Console.ReadLine();
            Console.Write("Ano de Publicação: ");
            int ano = int.Parse(Console.ReadLine());
            Console.Write("Exemplares: ");
            int exemplares = int.Parse(Console.ReadLine());

            Livro novoLivro = new Livro(titulo, autor, ano, exemplares);
            biblioteca.RegistrarLivro(novoLivro);

            return novoLivro;
        }


        //static Livro DevolverLivro(Biblioteca biblioteca)
        //{
       
        //}




    }
}



