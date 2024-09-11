using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBiblioteca
{
    internal class Utente
    {
        //*** Propriedades do Usuário ***
        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public string Telefone { get; private set; }
        public string Identificador { get; private set; }
        public string Senha { get; private set; }
        // consultar com o grupo
        public DateTime DataRegisto { get; private set; }

        //*** Construtor com todas as propriedades
        public Utente(string nome, string endereco, string telefone, string identificador, string senha)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            DataRegisto= DateTime.Now;
            Identificador = identificador;
            Senha = senha;
        }

        //*** Métodos ***

        //Consultar disponibilidade passando pela classe Biblioteca
        public void ConsultarDisponibilidade(Biblioteca biblioteca)
        {
            biblioteca.ListarLivrosDisponiveis();
        }

        //Consultar histórico de empréstimos desse Usuário
        public void HistoricoEmprestimos(Biblioteca biblioteca)
        {
            biblioteca.HistoricoEmprestimosUsuario(Identificador);
        }

       
        

        // fazer o emprestimo
        public void EmprestarLivro(Biblioteca biblioteca, string tituloLivro, string nomeUsuario)
        {
            biblioteca.EmprestarLivro(tituloLivro, nomeUsuario);
        }


        //Devolver Livros
        public void DevolverLivro(Biblioteca biblioteca, string tituloLivro, string nomeUsuario)
        {
            biblioteca.DevolverLivro(tituloLivro, nomeUsuario);
        }

    }
}
