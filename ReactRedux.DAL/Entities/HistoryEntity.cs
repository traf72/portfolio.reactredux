using System;

namespace ReactRedux.DAL.Entities
{
    public abstract class HistoryEntity<T> : Entity<T>, IHistoryEntity<T>
    {
        public DateTime Created { get; set; }

        public string Author { get; set; }

        public DateTime? Modified { get; set; }

        public string Modifier { get; set; }
    }
}