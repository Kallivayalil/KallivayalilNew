using System;
using Kallivayalil.Common;
using Kallivayalil.Domain.ReferenceData;
using NHibernate.Search.Attributes;

namespace Kallivayalil.Domain
{
    [Serializable,Indexed]
    public class ConstituentName : Entity
    {

        public override string ToString()
        {
            return string.Format("{3}. {0} {1} {2}", FirstName, MiddleName, LastName, Salutation.Description);
        }

        [DocumentId]
        public override int Id { get; set; }

        [Field(Index.Tokenized, Store = Store.Yes)]
        public virtual string FirstName { get; set; }

        public virtual string MiddleName { get; set; }

        [Field(Index.Tokenized, Store = Store.Yes)]
        public virtual string LastName { get; set; }

        public virtual string PreferedName { get; set; }
        public virtual SalutationType Salutation { get; set; }
    }
}