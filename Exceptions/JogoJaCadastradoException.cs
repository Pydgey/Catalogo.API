using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogo_de_Jogos___API.Exceptions
{
    public class JogoJaCadastradoException : Exception
    {
        public JogoJaCadastradoException() 
            : base("Este jogo já esta cadastrado")
        { }
    }
}
