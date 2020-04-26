using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Raefftec.CatchEmAll.Types
{
    [Owned]
    public class SearchCriteria
    {
        [StringLength(100)]
        public string WithAllTheseWords { get; private set; }

        public SearchCriteria(string withAllTheseWords)
        {
            this.WithAllTheseWords = withAllTheseWords;
        }
    }
}
