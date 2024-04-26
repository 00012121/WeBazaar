using WeBazaar.Data.Base;
using WeBazaar.Models;

namespace WeBazaar.Data.Services
{
    public interface IItemsService: IEntityBaseRepository<Item>
    {
        Task<Item> GetItemByIdAsync(int id);
    }
}
