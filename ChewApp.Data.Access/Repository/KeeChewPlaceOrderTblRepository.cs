using ChewApp.Data.Access.Infrastructure;
using ChewApp.Domain.Models;

namespace ChewApp.Data.Access.Repository {

    public interface IKeeChewPlaceOrderTblRepository : GenericRepository<KeeChewPlaceOrderTbl> {
    }

    public class KeeChewPlaceOrderTblRepository : GenericRepositoryImplement<KeeChewPlaceOrderTbl>, IKeeChewPlaceOrderTblRepository {

        public KeeChewPlaceOrderTblRepository(DbFactory dbFactory) : base(dbFactory) {
        }
    }
}