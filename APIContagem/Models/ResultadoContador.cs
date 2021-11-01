namespace APIContagem.Models;

public class ResultadoContador
{
    public int ValorAtual { get; set; } 
    public string? Local { get; set; } 
    public string? Kernel { get; set; } 
    public string? Framework { get; set; } 
    public string? MensagemFixa { get; set; } 
    public object? MensagemVariavel { get; set; }
}