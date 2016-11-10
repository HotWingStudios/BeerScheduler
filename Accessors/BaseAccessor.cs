namespace BeerScheduler.Accessors
{
    public class BaseAccessor
    {
        #region Properties

        internal DatabaseContext DatabaseContextInstance { get; set; }

        #endregion

        #region Methods

        internal DatabaseContext CreateDatabaseContext()
        {
            return DatabaseContextInstance ?? CreateNewBeerSchedulerDbContext();
        }

        private static DatabaseContext CreateNewBeerSchedulerDbContext()
        {
            return new DatabaseContext();
        }

        #endregion
    }
}
