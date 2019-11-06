using ChewApp.Data.Access.Infrastructure;
using ChewApp.Domain.Models;

namespace ChewApp.Data.Access.Repository {

    public interface IUserTblRepository : GenericRepository<UserTbl> {
    }

    public class UserTblRepository : GenericRepositoryImplement<UserTbl>, IUserTblRepository {

        public UserTblRepository(DbFactory dbFactory) : base(dbFactory) {
        }
    }
}