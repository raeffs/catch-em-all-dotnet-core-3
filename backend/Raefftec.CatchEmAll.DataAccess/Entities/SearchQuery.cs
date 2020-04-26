using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Raefftec.CatchEmAll.Types;

namespace Raefftec.CatchEmAll.Entities
{
    public class SearchQuery : IHasIdentifier
    {
        public Guid Id { get; private set; }

        [StringLength(100)]
        public string Name { get; private set; }

        public Guid UserId { get; private set; }

        [ForeignKey(nameof(UserId))]
        public virtual UserReference User { get; private set; }

        public UpdateInfo UpdateInfo { get; private set; }

        public ICollection<SearchResult> Results { get; private set; }

        public SearchCriteria Criteria { get; private set; }

        private SearchQuery()
        {
            this.Name = null!;
            this.User = null!;
            this.UpdateInfo = null!;
            this.Results = null!;
            this.Criteria = null!;
        }

        public SearchQuery(string name, UserReference user, SearchCriteria criteria)
        {
            this.Name = name;
            this.User = user;
            this.UserId = user.Id;
            this.UpdateInfo = new UpdateInfo();
            this.Results = new HashSet<SearchResult>();
            this.Criteria = criteria;
        }
    }
}
