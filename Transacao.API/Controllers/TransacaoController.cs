using Serilog;
using Microsoft.AspNetCore.Mvc;
using Transacao.Business.Model;
using Transacao.Business.Service;

namespace Transacao.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TransacaoController : ControllerBase
{
    private readonly TransacaoService _transacaoService;
    
    public TransacaoController(TransacaoService transacaoService)
    {
        _transacaoService = transacaoService;
    }

    [HttpPost]
    public IActionResult AdicionarTransacao([FromBody] TransacaoDTO transacaoDto)
    {
        try{
            _transacaoService.AddTransacao(transacaoDto);
            return CreatedAtAction(nameof(ObterTransacoes), null);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return UnprocessableEntity(ex.Message);
        }
    }

    [HttpGet]
    public IActionResult ObterTransacoes()
    {
        try
        {
            var result = _transacaoService.GetTransacoes();
            return Ok(result);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    public IActionResult DeletarTransacoes()
    {
        try
        {
            _transacaoService.DeletarTransacoes();
            return Ok("Transações deletadas com sucesso!");    
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return BadRequest(ex.Message);
        }
    }
}