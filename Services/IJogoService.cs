using Catalogo_de_Jogos___API.InputModel;
using Catalogo_de_Jogos___API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogo_de_Jogos___API.Services
{
    public interface IJogoService
    {
        Task<List<JogoViewModel>> Obter(int pagina, int quantidade);

        Task<JogoViewModel> Obter(Guid id);

        Task<JogoViewModel> Inserir(JogoInputModel jogo);

        Task Atualizar(Guid id, JogoInputModel jogo);

        Task AtualizarPreco(Guid id, double preco);

        Task Recover(Guid id);
    }
}
