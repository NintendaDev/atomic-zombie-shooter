namespace Atomic.Entities
{
    public partial interface IEntity
    {
        int InstanceId { get; }
        
        string Name { get; set; }
        
        void Clear();
    }
}