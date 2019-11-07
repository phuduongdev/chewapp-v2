using ChewApp.Common.Utils;
using ChewApp.Data.Access.Infrastructure;
using ChewApp.Data.Access.Repository;
using ChewApp.Domain.Models;
using System;
using System.Linq;

namespace ChewApp.Service {

    public interface IAdministratorService {

        AdministratorsTbl GetAdminByUsernameAndPassword(string username, string password);

        void SaveChanges();
    }

    public class AdministratorService : IAdministratorService {
        private IAdministratorRepository _administratorRepository;
        private UnitOfWork _unitOfWork;

        public AdministratorService(IAdministratorRepository administratorRepository, UnitOfWork unitOfWork) {
            this._administratorRepository = administratorRepository;
            this._unitOfWork = unitOfWork;
        }

        public AdministratorsTbl GetAdminByUsernameAndPassword(string username, string password) {
            AdministratorsTbl admin = null;
            try {
                var encodePassword = Encryption.EncodeSHA1(password);
                admin = _administratorRepository
                    .GetAllAndFilter(a => a.UserName.Equals(username) && a.Password.Equals(encodePassword))
                    .Single();
            } catch(Exception e) {
                Console.WriteLine(e.StackTrace);
            }
            return admin;
        }

        public void SaveChanges() {
            _unitOfWork.Save();
        }
    }
}