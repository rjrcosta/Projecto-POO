using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBiblioteca
{
    internal class Emprestimo
    {
        public Livro LivroEmprestado { get; private set; }
        public Utente Usuario { get; private set; }
        public DateTime DataEmprestimo { get; private set; }
        public DateTime DataDevolucao { get; private set; }

        public Emprestimo(Livro livro, Utente usuario)
        {
            LivroEmprestado = livro;
            Usuario = usuario;
            DataEmprestimo = DateTime.Now;
            DataDevolucao = DataEmprestimo.AddDays(3); // 3 dias de empréstimo
            livro.DiminuirDisponibilidade();
        }

        public void ExibirInformacoes()
        {
            Console.WriteLine($"{LivroEmprestado.Titulo} empréstimo no nome de {Usuario.Nome} com o ID {Usuario.Identificador} em {DataEmprestimo.ToShortDateString()}. Devolução até {DataDevolucao.ToShortDateString()}.");
        }
    }
}
