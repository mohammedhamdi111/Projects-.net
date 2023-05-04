using ProjectSW2.Models;
using ProjectSW2.Repository;

namespace ProjectSW2.Implemetation
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Products = new BaseRepository<Product>(_context);
            Categories = new BaseRepository<Category>(_context);
            Address = new BaseRepository<Address>(_context);
            Carts = new BaseRepository<Cart>(_context);
            OrderTables = new BaseRepository<OrderTable>(_context);
            Reviews = new BaseRepository<Review>(_context);
        }

        public IBaseRepository<Product> Products { get; private set; }

        public IBaseRepository<Category> Categories { get; private set; }

        public IBaseRepository<Address> Address { get; private set; }

        public IBaseRepository<Cart> Carts { get; private set; }


        public IBaseRepository<Country> Countries { get; private set; }


        public IBaseRepository<OrderTable> OrderTables { get; private set; }

        public IBaseRepository<Review> Reviews { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
