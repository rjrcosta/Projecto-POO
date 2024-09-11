using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBiblioteca
{
    internal class Biblioteca
    {
        private List<Livro> livros = new List<Livro>();
        private List<Emprestimo> emprestimos = new List<Emprestimo>();

        public void RegistrarLivro(Livro livro)
        {
            livros.Add(livro);
        }

        public void ListarLivrosDisponiveis()
        {
            var disponiveis = livros.Where(l => l.TemDisponibilidade()).ToList();
            if (disponiveis.Count > 0)
            {
                Console.WriteLine("Livros disponíveis:");
                foreach (var livro in disponiveis)
                {
                    livro.ExibirInformacoes();
                }
            }
            else
            {
                Console.WriteLine("Nenhum livro disponível no momento.");
            }
        }

        public void EmprestarLivro(string tituloLivro, string nomeUsuario)
        {
            var livro = livros.FirstOrDefault(l => l.Titulo == tituloLivro && l.TemDisponibilidade());
            var usuario = Utilizador.usuarios.FirstOrDefault(u => u.Nome == nomeUsuario);

            if (livro != null && usuario != null)
            {
                var emprestimo = new Emprestimo(livro, usuario);
                emprestimos.Add(emprestimo);
                Console.WriteLine($"Livro '{livro.Titulo}' emprestado para {usuario.Nome}.");
            }
            else
            {
                Console.WriteLine("Livro ou usuário não encontrado.");
            }
        }

        public void DevolverLivro(string tituloLivro, string nomeUsuario)
        {
            var emprestimo = emprestimos.FirstOrDefault(e => e.LivroEmprestado.Titulo == tituloLivro && e.Usuario.Nome == nomeUsuario);

            if (emprestimo != null)
            {
                emprestimo.LivroEmprestado.AumentarDisponibilidade();
                emprestimos.Remove(emprestimo);
                Console.WriteLine($"Livro '{tituloLivro}' devolvido por {nomeUsuario}.");
            }
            else
            {
                Console.WriteLine("Empréstimo não encontrado.");
            }
        }

        public void GerarRelatorioEmprestimos()
        {
            if (emprestimos.Count > 0)
            {
                Console.WriteLine("Relatório de Empréstimos:");
                foreach (var emprestimo in emprestimos)
                {
                    emprestimo.ExibirInformacoes();
                }
            }
            else
            {
                Console.WriteLine("Nenhum empréstimo registrado.");
            }
        }

        public void HistoricoEmprestimosUsuario(string idUsuario)
        {
            var historico = emprestimos.Where(e => e.Usuario.Identificador == idUsuario).ToList();
            if (historico.Count > 0)
            {
                Console.WriteLine($"Histórico de Empréstimos de {idUsuario}:");
                foreach (var emprestimo in historico)
                {
                    emprestimo.ExibirInformacoes();
                }
            }
            else
            {
                Console.WriteLine("Nenhum empréstimo encontrado para o usuário.");
            }
        }
    }
}
