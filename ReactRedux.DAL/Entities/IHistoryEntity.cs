using System;

namespace ReactRedux.DAL.Entities
{
    public interface IHistoryEntity<T> : IEntity<T>
    {
        DateTime Created { get; set; }

        string Author { get; set; }

        DateTime? Modified { get; set; }

        string Modifier { get; set; }
    }
}