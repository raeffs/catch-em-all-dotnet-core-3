namespace Raefftec.CatchEmAll
{
    public interface IContextFactory
    {
        public IDbContext GetContext();
    }
}
