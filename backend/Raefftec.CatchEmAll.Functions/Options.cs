namespace Raefftec.CatchEmAll
{
    internal class Options
    {
        /// <summary>
        /// The number of requests done in a single batch.
        /// We need to limit that to prevent running into a rate limit.
        /// This affects the number of articles updated in a single batch
        /// as well as the number of search pages queried in a single batch,
        /// and thus also affects the maximal number of search results.
        /// </summary>
        public int BatchSize { get; set; }

        public int UpdateIntervalInHours { get; set; }
    }
}
