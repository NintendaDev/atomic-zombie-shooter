namespace Atomic.Contexts
{
    public interface IContextInstaller
    {
        void Install(IContext context);
    }
    
    public interface IContextInstaller<in T> : IContextInstaller where T : IContext
    {
        void IContextInstaller.Install(IContext context) => this.Install((T) context);
        void Install(T context);
    }
}