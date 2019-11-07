using ChewApp.Data.Access.Infrastructure;
using ChewApp.Domain.Models;

namespace ChewApp.Data.Access.Repository {

    public interface IAdministratorRepository : GenericRepository<AdministratorsTbl> {
    }

    public class AdministratorRepository : GenericRepositoryImplement<AdministratorsTbl>, IAdministratorRepository {

        public AdministratorRepository(DbFactory dbFactory) : base(dbFactory) {
        }
    }
}