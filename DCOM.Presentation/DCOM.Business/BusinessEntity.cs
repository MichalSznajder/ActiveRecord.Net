namespace DCOM.Business
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Data;

    public abstract class BusinessEntity<TEntity, TKey> : ActiveRecord<TEntity, TKey> where TEntity : class, new()
    {
        protected BusinessEntity(IDataContextProvider contextProvider) : base(contextProvider)
        {
        }

        public virtual bool IsValid(out IEnumerable<ValidationResult> validationResults)
        {
            var context = new ValidationContext(this);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(this, context, results, true) && OnValidate(results);

            validationResults = results;

            return isValid;
        }

        public override void Save()
        {
            if (!IsValid(out var results))
            {
                throw new ValidationException($"Entity was not be saved because there are {results.Count()} validation errors.");
            }

            base.Save();
        }
        
        protected virtual bool OnValidate(ICollection<ValidationResult> results)
        {
            return !results.Any();
        }
    }
}