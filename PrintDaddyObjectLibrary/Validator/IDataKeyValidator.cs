namespace PrintDaddyObjectLibrary
{
    public interface IDataKeyValidator : IValidator
    {
        bool IsValidKey(IDataKey dataKey);
    }
}