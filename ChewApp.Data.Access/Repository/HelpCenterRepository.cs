using ChewApp.Data.Access.Infrastructure;
using ChewApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChewApp.Data.Access.Repository
{
    public interface IHelpCenterRepository : GenericRepository<HelpCenterTbl>
    {

    }
    public class HelpCenterRepository : GenericRepositoryImplement<HelpCenterTbl> , IHelpCenterRepository 
    {
        public HelpCenterRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

        
    }
}
