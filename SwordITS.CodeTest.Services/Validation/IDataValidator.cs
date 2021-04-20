namespace SwordITS.CodeTest.Services.Validation
{
    public interface IDataValidator<T> where T : class
    {
        bool IsValid(T data);
    }
}