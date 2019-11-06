using ChewApp.Data.Access;
using ChewApp.Data.Access.Infrastructure;
using ChewApp.Data.Access.Repository;
using ChewApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChewApp.Service {
    public interface IUserService {
        UserTbl Insert(UserTbl entity);
        IEnumerable<UserTbl> GetAll();
        UserTbl GetSingleById(int id);
        void Update(UserTbl entityToUpdate);
        void SaveChanges();
    }

    public class UserService : IUserService {
        IUserTblRepository _userTblRepository;
        UnitOfWork _unitOfWork;
        public UserService(IUserTblRepository userTblRepository, UnitOfWork unitOfWork) {
            this._userTblRepository = userTblRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<UserTbl> GetAll() {
            return _userTblRepository.GetAll();
        }

        public UserTbl GetSingleById(int id) {
            return _userTblRepository.GetSingleByID(id);
        }

        public UserTbl Insert(UserTbl entity) {
            return _userTblRepository.Insert(entity);
        }

        public void SaveChanges() {
            _unitOfWork.Save();
        }

        public void Update(UserTbl entityToUpdate) {
            _userTblRepository.Update(entityToUpdate);
        }
    }
}
