using ReactRedux.DAL.Entities;

namespace ReactRedux.DAL.Entities
{
    public abstract class Entity<T> : IEntity<T>
    {
        public virtual T Id { get; set; }
    }
}