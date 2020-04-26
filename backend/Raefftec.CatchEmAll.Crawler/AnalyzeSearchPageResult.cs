using System.Collections.Generic;

namespace Raefftec.CatchEmAll
{
    public class AnalyzeSearchPageResult
    {
        public IEnumerable<ArticleData> Articles { get; set; } = new List<ArticleData>();
    }
}
