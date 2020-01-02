namespace PrintDaddyObjectLibrary
{
    public interface ISelector
    {
        bool Next();
        object GetCurrentItem();
        void Reset();
        void Reload();
    }
}