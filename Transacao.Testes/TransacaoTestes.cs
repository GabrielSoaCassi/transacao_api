using Transacao.Business.Model;
using Transacao.Business.Service;
using Transacao.Domain.Exceptions;

namespace Transacao.Testes;

public class TransacaoTestes
{
    [Fact]
    public void Quando__TransacaoForChamadaComDataSuperiorADataAtual__DeveRetornarException()
    {
        //Arrange
        var transacaoDummy = new TransacaoDTO(123.5,DateTime.Now.AddSeconds(2));
        var serviceMock = new TransacaoService();
        //Act
        var exception = Assert.Throws<TransacaoException>(() => serviceMock.AddTransacao(transacaoDummy));
        //Assert
        Assert.Equal("Data da transação maior que a data atual",exception.Message);
        Assert.False(TransacaoService.CountTransacao > 0);

    }
    
    [Theory]
    [InlineData(-10)]
    [InlineData(-2)]
    public void Quando__TransacaoForChamadaComValorNegativo__DeveRetornarException(double value)
    {
        //Arrange
        var transacaoDummy = new TransacaoDTO(value,DateTime.Now);
        var serviceMock = new TransacaoService();
        //Act
        var exception = Assert.Throws<TransacaoException>(() => serviceMock.AddTransacao(transacaoDummy));
        //Assert
        Assert.Equal("Valor da transação menor que 0 \n",exception.Message);
        Assert.False(TransacaoService.CountTransacao > 0);
    }
    
    [Fact]
    public void Quando__TransacaoForChamadaComValorEDataCorreto__DeveAdicionar()
    {
        //Arrange
        var transacaoDummy = new TransacaoDTO(123.5,DateTime.Now);
        var serviceMock = new TransacaoService();
        //Act
        serviceMock.AddTransacao(transacaoDummy);
        //Assert
        Assert.True(TransacaoService.CountTransacao > 0);
    }

    [Fact]
    public void Quando__DeletarTransacoesForChamada__DeveRemoverTodas()
    {
        //Arrange
        var transacaoDummy = new TransacaoDTO(123.5,DateTime.Now);
        var serviceMock = new TransacaoService();
        //Act
        serviceMock.AddTransacao(transacaoDummy);
        serviceMock.AddTransacao(transacaoDummy);
        serviceMock.AddTransacao(transacaoDummy);
        serviceMock.DeletarTransacoes();
        //Assert
        Assert.True(TransacaoService.CountTransacao == 0);
    }

    [Fact]
    public void Quando__GetTransacoesForChamada__DeveRetornarUmDoubleSummaryStatisticsDosUltimosSessentaSegundos()
    {
        var transacaoDummy1 = new TransacaoDTO(123.5,new DateTime(2022,11,20));
        var transacaoDummy2 = new TransacaoDTO(123.5,new DateTime(2022,11,20));
        var transacaoDummy3 = new TransacaoDTO(123.5,DateTime.Now);
        var transacaoDummy4 = new TransacaoDTO(2000,DateTime.Now);
        var serviceMock = new TransacaoService();
        //Act
        serviceMock.AddTransacao(transacaoDummy1);
        serviceMock.AddTransacao(transacaoDummy2);
        serviceMock.AddTransacao(transacaoDummy3);
        serviceMock.AddTransacao(transacaoDummy4);
        var doubleSummaryStatistics = serviceMock.GetTransacoes();
        //Assert
        Assert.Equal(2,doubleSummaryStatistics.Count);
        Assert.Equal(2000,doubleSummaryStatistics.Max);
        Assert.Equal(123.5,doubleSummaryStatistics.Min);
        Assert.Equal(((2000+123.5)/2),doubleSummaryStatistics.Average);
    }

    [Fact]
    public void
        Quando__GetTransacoesForChamadaSemTransacoesAdicionadas__DeveRetornarUmDoubleSummaryStatisticsDosUltimosSessentaSegundos()
    {

        var serviceMock = new TransacaoService();
        //Act

        var doubleSummaryStatistics = serviceMock.GetTransacoes();
        //Assert
        Assert.Equal(0, doubleSummaryStatistics.Count);
        Assert.Equal(0, doubleSummaryStatistics.Max);
        Assert.Equal(0, doubleSummaryStatistics.Min);
        Assert.Equal(0, doubleSummaryStatistics.Average);
    }
}