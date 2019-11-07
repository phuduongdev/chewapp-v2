using ChewApp.Data.Access.Infrastructure;
using ChewApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChewApp.Data.Access.Repository
{
    public interface IKeeChewSoonChewHistoryRepository : GenericRepository<KeeChewSoonChewHistoryTbl>
    {

    }
    public class KeeChewSoonChewHistoryRepository : GenericRepositoryImplement<KeeChewSoonChewHistoryTbl>, IKeeChewSoonChewHistoryRepository
    {

        public KeeChewSoonChewHistoryRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

    }
}
