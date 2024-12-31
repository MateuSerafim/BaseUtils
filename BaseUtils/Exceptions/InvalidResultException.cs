namespace BaseUtils.Exceptions;

public class InvalidResultException : Exception
{
    public InvalidResultException(string mensagem) : 
    base(mensagem) { }

    public InvalidResultException(string mensagem, Exception innerException) : 
    base(mensagem, innerException) { }
}
