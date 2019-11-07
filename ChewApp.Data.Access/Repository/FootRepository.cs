using ChewApp.Data.Access.Infrastructure;
using ChewApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChewApp.Data.Access.Repository
{
    public interface IFootRepository : GenericRepository<FoodTbl>
    {

    }
    public class FootRepository : GenericRepositoryImplement<FoodTbl>, IFootRepository
    {
        public FootRepository(DbFactory dbFactory):base(dbFactory)
        {

        }
    }
}
