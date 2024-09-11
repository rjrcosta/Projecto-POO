using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBiblioteca
{
    internal class Livro
    {
        //*** Propriedades de um Livro ***
        public string Titulo { get; set; }

        //Aqui possível melhoria: criar classe Autor e aqui fazer List<Autor>
        public string Autor { get; set; }

        public int AnoPublicacao { get; set; }

        //Aqui uma alternativa: criar propriedades Exemplares, ExemplaresDisponiveis, ExemplaresEmprestados
        public int ExemplaresDisponiveis { get; set; }

        //*** Construtor com todos as propriedades como parâmetros ***
        public Livro(string titulo, string autor, int anoPublicacao, int exemplaresDisponiveis)
        {
            Titulo = titulo;
            Autor = autor;
            AnoPublicacao = anoPublicacao;
            ExemplaresDisponiveis = exemplaresDisponiveis;
        }

        //*** Métodos diretamente relacionados com Livro ***

        //Verificar se o Livro tem exemplares disponíveis para empréstimo
        public bool TemDisponibilidade()
        {
            //Se ExemplaresDisponiveis for maior que zero, devolve true. Se não, devolve false
            return ExemplaresDisponiveis > 0;
        }

        //Diminuir a quantidade de exemplares disponíveis ao fazer um empréstimo
        public void DiminuirDisponibilidade()
        {
            //Testar se tem exemplar disponível (com o método já construído)
            if (TemDisponibilidade())
            {
                //Diminui um exemplar disponível
                ExemplaresDisponiveis--;
            }
            else
            {
                //Avisa ao Utilizador
                Console.WriteLine("Este título não tem livros disponíveis para empréstimo no momento.");
            }
        }

        //Aumentar disponibilidade de exemplares
        public void AumentarDisponibilidade()
        {
            ExemplaresDisponiveis++;
        }

        //Mostrar informações
        public void ExibirInformacoes()
        {
            Console.WriteLine($"{Titulo} (Autor: {Autor}, Ano: {AnoPublicacao}) - Disponíveis: {ExemplaresDisponiveis}");
        }

    }
}
