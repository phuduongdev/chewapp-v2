using ChewApp.Data.Access;
using ChewApp.Data.Access.Infrastructure;
using ChewApp.Data.Access.Repository;
using ChewApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChewApp.Service {
    public interface IKeeChewPlaceOrderService {
        IEnumerable<KeeChewPlaceOrderTbl> GetAll();
        KeeChewPlaceOrderTbl GetSingleById(int id);
        void SaveChanges();
    }

    public class KeeChewPlaceOrderService : IKeeChewPlaceOrderService {
        UnitOfWork _unitOfWork;
        IKeeChewPlaceOrderTblRepository _keeChewPlaceOrderRepository;

        public KeeChewPlaceOrderService(UnitOfWork unitOfWork, IKeeChewPlaceOrderTblRepository keeChewPlaceOrderRepository) {
            _unitOfWork = unitOfWork;
            _keeChewPlaceOrderRepository = keeChewPlaceOrderRepository;
        }

        public IEnumerable<KeeChewPlaceOrderTbl> GetAll() {
            return _keeChewPlaceOrderRepository.GetAll();
        }

        public KeeChewPlaceOrderTbl GetSingleById(int id) {
            return _keeChewPlaceOrderRepository.GetSingleByID(id);
        }

        public void SaveChanges() {
            _unitOfWork.Save();
        }
    }
}
