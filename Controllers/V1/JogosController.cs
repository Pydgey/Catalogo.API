using Catalogo_de_Jogos___API.InputModel;
using Catalogo_de_Jogos___API.Services;
using Catalogo_de_Jogos___API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogo_de_Jogos.API.Controllers.V1
{

    [Route("api/V1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogoService _jogoService;

        public JogosController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<JogoViewModel>>> Obter()
        {
            var result = await _jogoService.Obter(1, 5);
            return Ok(result);
        }

        [HttpGet("(idjogo:guid)")]
        public async Task<ActionResult<JogoViewModel>> Obter(Guid idjogo)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> InserirJogo(JogoInputModel jogo)
        {
            return Ok();
        }

        [HttpPut("(idjogo:guid)")]
        public async Task<ActionResult> AtualizarJogo(Guid idjogo, JogoInputModel jogo)
        {
            return Ok();
        }

        [HttpPatch("(idjogo:guid)/preco/(preco:double)")]
        public async Task<ActionResult> AtualizarPreco(Guid idjogo, double preco)
        {
            return Ok();
        }

        [HttpDelete("(idjogo:guid)")]
        public async Task<AcceptedResult> ApagarJogo(Guid idjogo)
        {
            return Ok();
        }
    }
}
