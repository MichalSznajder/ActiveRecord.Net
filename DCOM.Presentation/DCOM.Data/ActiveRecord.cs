namespace DCOM.Data
{
    using System;

    public abstract class ActiveRecord<TEntity, TKey> where TEntity : class, new()
    {
        protected readonly IDataContextProvider ContextProvider;
        protected readonly DataContext Context;
        protected TEntity Entity;

        protected ActiveRecord(IDataContextProvider contextProvider)
        {
            ContextProvider = contextProvider;
            Context = contextProvider.GetContext();
        }

        public TKey Id
        {
            get;
            protected set;
        }

        public virtual void Load(TKey id)
        {
            Entity = Context.Find<TEntity>(id);

            if (Entity != null)
            {
                Id = id;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public virtual void New()
        {
            Entity = new TEntity();

            Context.Add(Entity);
        }

        public virtual void Delete()
        {
            if (Entity == null)
            {
                throw new InvalidOperationException();
            }

            Context.Remove(Entity);
            Context.SaveChanges();
        }

        public virtual void Save()
        {
            Context.SaveChanges();
        }
    }
}