namespace Atomic.Contexts
{
    public partial interface IContext
    {
        string Name { get; set; }
        
        IContext Parent { get; set; }

        void Clear();
    }
}