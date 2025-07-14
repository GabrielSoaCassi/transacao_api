namespace Transacao.Business.Model;

public record TransacaoDTO(double valor, DateTimeOffset dataTransacao = default)
{
}
