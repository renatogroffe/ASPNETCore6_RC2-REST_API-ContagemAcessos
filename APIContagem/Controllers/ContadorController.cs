using Microsoft.AspNetCore.Mvc;
using APIContagem.Models;

namespace APIContagem.Controllers;

[ApiController]
[Route("[controller]")]
public class ContadorController : ControllerBase
{
    private static readonly Contador _CONTADOR = new Contador();
    private readonly ILogger<ContadorController> _logger;
    private readonly IConfiguration _configuration;

    public ContadorController(ILogger<ContadorController> logger,
        IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    [HttpGet]
    public ResultadoContador Get()
    {
        lock (_CONTADOR)
        {
            _CONTADOR.Incrementar();
            _logger.LogInformation($"Contador - Valor atual: {_CONTADOR.ValorAtual}");

            return new()
            {
                ValorAtual = _CONTADOR.ValorAtual,
                Local = _CONTADOR.Local,
                Kernel = _CONTADOR.Kernel,
                Framework = _CONTADOR.Framework,
                MensagemFixa = "Testes",
                MensagemVariavel = _configuration["MensagemVariavel"]
            };
        }
    }
}