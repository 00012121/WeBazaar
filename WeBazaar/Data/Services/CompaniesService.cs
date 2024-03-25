using WeBazaar.Data.Base;
using WeBazaar.Models;

namespace WeBazaar.Data.Services
{
    public class CompaniesService : EntityBaseRepository<Company>, ICompaniesService
    {
        public CompaniesService(AppDbContext context) : base(context)
        {
                
        }
    }
}
