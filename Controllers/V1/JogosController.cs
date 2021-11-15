using Catalogo_de_Jogos___API.InputModel;
using Catalogo_de_Jogos___API.Services;
using Catalogo_de_Jogos___API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public async Task<ActionResult<IEnumerable<JogoViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {      
            var jogos = await _jogoService.Obter(pagina, quantidade);

            if(jogos.Count() == 0)
            {
                return NoContent();
            }
            return Ok(jogos);
        }

        [HttpGet("(idjogo:guid)")]
        public async Task<ActionResult<JogoViewModel>> Obter([FromRoute] Guid idjogo)
        {
            var jogo = await _jogoService.Obter(idjogo);

            if (jogo == null)
                return NoContent();

            return Ok(jogo);
        }

        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> InserirJogo([FromBody] JogoInputModel jogoInputModel)
        {
            try
            {
                var jogo = await _jogoService.Inserir(jogoInputModel);

                return Ok(jogo);
            }
            //catch (JogoJaCadastradoException ex)
            catch (Exception ex)
            {
                return UnprocessableEntity("Já existe um jogo com esse nome cadastrado");

            }
            
        }

        [HttpPut("(idjogo:guid)")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idjogo, [FromBody] JogoInputModel jogoInputModel)
        {
            try
            {
                await _jogoService.Atualizar(idjogo, jogoInputModel);

                return Ok();
            }
            //catch (JogoNaoCadastradoException ex)
            catch (Exception ex)
            {
                return NotFound("Jogo não encontrado");

            }

        }

        [HttpPatch("(idjogo:guid)/preco/(preco:double)")]
        public async Task<ActionResult> AtualizarPreco([FromRoute] Guid idjogo, [FromRoute] double preco)
        {
            try
            {
                await _jogoService.AtualizarPreco(idjogo, preco);

                return Ok();
            }
            //catch (JogoNaoCadastradoException ex)
            catch (Exception ex)
            {
                return NotFound("Jogo não encontrado");
            }
        }

        [HttpDelete("(idjogo:guid)")]
        public async Task<ActionResult> ApagarJogo([FromRoute] Guid idjogo)
        {
            try
            {
                await _jogoService.Remover(idjogo);

                return Ok();
            }
            //catch (JogoNaoCadastradoException ex)
            catch (Exception ex)
            {
                return NotFound("Jogo não encontrado");
            }
        }
    }
}
