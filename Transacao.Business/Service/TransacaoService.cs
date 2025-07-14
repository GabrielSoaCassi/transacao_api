using Serilog;
using System.Text;
using Transacao.Domain.Exceptions;
using Transacao.Business.Model;

namespace Transacao.Business.Service;

public class TransacaoService
{
    private static List<TransacaoDTO> _transacaoDtos = new List<TransacaoDTO>();
    public static int CountTransacao => _transacaoDtos.Count;

    public void AddTransacao(TransacaoDTO transacaoDto)
    {
        StringBuilder message = new StringBuilder();
        if (transacaoDto.valor < 0)
            message.Append("Valor da transação menor que 0 \n");
        if (transacaoDto.dataTransacao > DateTime.Now)
            message.Append("Data da transação maior que a data atual");
        if (!string.IsNullOrEmpty(message.ToString()))
            throw new TransacaoException(message.ToString());
        _transacaoDtos.Add(transacaoDto);
        Log.Information($"Adicionando transação {transacaoDto}");
    }

    public void DeletarTransacoes()
    {
        Log.Information("Deletando todas transações");
        _transacaoDtos.Clear();
    }
    
    public DoubleSummaryStatistics GetTransacoes()
    {
        var result = new DoubleSummaryStatistics(_transacaoDtos);
        Log.Information("Retornado Informação das Transações");
        return result;
    }
}