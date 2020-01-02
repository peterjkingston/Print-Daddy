namespace PrintDaddyObjectLibrary
{
    interface IDataKeyValidator : IValidator
    {
        bool IsValidKey(IDataKey dataKey);
    }
}