using BlogWeb.Data.Abstractions;
using BlogWeb.Data.Concretes;
using BlogWeb.Data.Context;

namespace BlogWeb.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext dbContext;
        public UnitOfWork(AppDbContext dbContext)
        {
			this.dbContext = dbContext;
        }
        public async ValueTask DisposeAsync()
		{
			await dbContext.DisposeAsync();
		}

		public int Save()
		{
			return dbContext.SaveChanges();
		}

		public async Task<int> SaveAsync()
		{
			return await dbContext.SaveChangesAsync();
		}

		IRepository<T> IUnitOfWork.GetRepository<T>()
		{
			return new Repository<T>(dbContext);
		}
	}
}
