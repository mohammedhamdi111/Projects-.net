using ProjectSW2.Models;

namespace ProjectSW2.Repository
{
    public interface IUnitOfWork:IDisposable
    {
        IBaseRepository<Product> Products { get; }
        IBaseRepository<Category> Categories { get; }
        IBaseRepository<Address> Address { get; }
        IBaseRepository<Cart> Carts { get; }
        IBaseRepository<Country> Countries { get; }
        IBaseRepository<OrderTable> OrderTables { get; }
        IBaseRepository<Review> Reviews { get; }

        int Complete();
    }
}
