using System.Collections.Generic;

namespace User.Domain.Entities{

    public abstract class Base{

        public Long Id { get; set; }

        internal List<string> _errors;
        public IReadOnlyCollection<string> Erros => _errors;

        public abstract bool Validate();

    }

}