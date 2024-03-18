using WeBazaar.Data.Base;
using WeBazaar.Models;

namespace WeBazaar.Data.Services
{
    public class ProducersService:EntityBaseRepository<Producer>, IProducersService
    {
        public ProducersService(AppDbContext context) : base(context)
        {
                
        }
    }
}
