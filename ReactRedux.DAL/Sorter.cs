using System;
using System.Linq;
using System.Linq.Expressions;

namespace ReactRedux.DAL
{
    public interface ISorter<TEntity>
    {
        IOrderedQueryable<TEntity> ApplyOrderBy(IQueryable<TEntity> source);

        IOrderedQueryable<TEntity> ApplyThenBy(IOrderedQueryable<TEntity> source);
    }

    public abstract class Sorter<TEntity> : ISorter<TEntity>
    {
        public static Sorter<TEntity, TKeyType> Create<TKeyType>(Expression<Func<TEntity, TKeyType>> keySelector, bool descending = false)
        {
            return new Sorter<TEntity, TKeyType>(keySelector, descending);
        }

        public abstract IOrderedQueryable<TEntity> ApplyOrderBy(IQueryable<TEntity> source);

        public abstract IOrderedQueryable<TEntity> ApplyThenBy(IOrderedQueryable<TEntity> source);
    }

    public class Sorter<TEntity, TKeyType> : Sorter<TEntity>
    {
        public Expression<Func<TEntity, TKeyType>> KeySelector { get; set; }

        public bool Descending { get; set; }

        public Sorter(Expression<Func<TEntity, TKeyType>> keySelector, bool descending = false)
        {
            KeySelector = keySelector;
            Descending = descending;
        }

        public override IOrderedQueryable<TEntity> ApplyOrderBy(IQueryable<TEntity> source)
        {
            return Descending
                ? source.OrderByDescending(KeySelector)
                : source.OrderBy(KeySelector);
        }

        public override IOrderedQueryable<TEntity> ApplyThenBy(IOrderedQueryable<TEntity> source)
        {
            return Descending
                ? source.ThenByDescending(KeySelector)
                : source.ThenBy(KeySelector);
        }
    }
}