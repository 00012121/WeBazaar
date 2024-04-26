using WeBazaar.Data.Base;
using WeBazaar.Data.ViewModels;
using WeBazaar.Models;

namespace WeBazaar.Data.Services
{
    public interface IItemsService: IEntityBaseRepository<Item>
    {
        Task<Item> GetItemByIdAsync(int id);
        Task<NewItemDropdownsVM> GetNewItemDropdownsValues();
    }
}
