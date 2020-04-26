using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Raefftec.CatchEmAll.Types
{
    [Owned]
    public class ArticleInfo
    {
        [StringLength(100)]
        public string Name { get; private set; } = string.Empty;

        public DateTimeOffset Created { get; private set; }

        public DateTimeOffset Ends { get; private set; }

        public bool IsClosed { get; private set; }

        public bool IsSold { get; private set; }

        public ArticleInfo(
            string name,
            DateTimeOffset created,
            DateTimeOffset ends,
            bool isClosed,
            bool isSold)
        {
            this.Name = name;
            this.Created = created;
            this.Ends = ends;
            this.IsClosed = isClosed;
            this.IsSold = isSold;
        }
    }
}
