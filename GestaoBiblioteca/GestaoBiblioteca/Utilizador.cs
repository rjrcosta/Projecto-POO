using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBiblioteca
{
    internal static class Utilizador
    {
        //*** Propriedades do Utilizador que terá subclasses Utente e Funcionario ***
        public static List<Utente> usuarios = new List<Utente>();
        public static List<Funcionario> funcionarios = new List<Funcionario>();

        //*** Métodos ***

        //Login
        public static object Login(string identificador, string senha)
        {
            //Tenta encontrar na lista de usuários, o identificador e a senha. Se encontrar retorna um usuário
            var usuario = usuarios.FirstOrDefault(u => u.Identificador == identificador && u.Senha == senha);
            if (usuario != null)
            {
                return usuario;
            }

            //Se até aqui o método não retornou ainda um usuário, procura na lista um funcionário com aquele identificaror e senha
            var funcionario = funcionarios.FirstOrDefault(f => f.Identificador == identificador && f.Senha == senha);
            if (funcionario != null)
            {
                return funcionario;
            }

            //Retorna nulo se não encontrar usuário ou funcionário com aquele identificador ou senha
            //O nulo precisa ser tratado na classe onde o método será invocado
            return null;
        }

    }
}
