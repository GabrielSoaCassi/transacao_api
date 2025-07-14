namespace Transacao.Domain.Exceptions;

public class TransacaoException: Exception
{
    public TransacaoException()
    {
        
    }
    public TransacaoException(string msg) : base(msg)
    {
        
    }
    
    public TransacaoException(string msg,Exception innerException) : base(msg,innerException)
    {
        
    }
}