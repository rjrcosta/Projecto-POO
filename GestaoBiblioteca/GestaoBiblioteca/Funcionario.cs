using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBiblioteca
{
    internal class Funcionario : Utente
    {
        //*** Construtor baseado na superclasse Utente ***
        public Funcionario(string nome, string endereco, string telefone, string identificador, string senha)
            : base(nome, endereco, telefone, identificador, senha)
        {
        }


        //*** Métodos ***

        //Registar novos livros
        public void RegistrarLivros(Biblioteca biblioteca, string titulo, string autor, int ano, int exemplares)
        {
            biblioteca.RegistrarLivro(new Livro(titulo, autor, ano, exemplares));
        }

        //Registar novos usuários
        public void RegistrarUsuario(string nome, string endereco, string telefone, string identificador, string senha)
        {
            Utilizador.usuarios.Add(new Utente(nome, endereco, telefone, identificador, senha));
        }

       
        //Ver histórico de todos os empréstimos
        public void GerarRelatorioEmprestimos(Biblioteca biblioteca)
        {
            biblioteca.GerarRelatorioEmprestimos();
        }

    }
}
