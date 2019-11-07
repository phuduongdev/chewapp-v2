using ChewApp.Data.Access.Infrastructure;
using ChewApp.Data.Access.Repository;
using ChewApp.Domain.Models;
using ChewApp.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChewApp.Service
{
    public interface IHelpCenterService
    {
        IEnumerable<HelpCenterDTO> GetAll();
        HelpCenterTbl GetSingleById(int id);
        void SaveChange();
    }
    public class HelpCenterService : IHelpCenterService
    {
        IHelpCenterRepository _helpCenterRepository;
        IUserTblRepository _userRepository;
        IKeeChewSoonChewHistoryRepository _keeChewSoonChewHistoryRepository;
        IFootRepository _footRepository;
        UnitOfWork _unitOfWork;
        public HelpCenterService(IHelpCenterRepository helpCenterRepository, UnitOfWork unitOfWork, IUserTblRepository userRepository, IKeeChewSoonChewHistoryRepository keeChewSoonChewHistoryRepository, IFootRepository footRepository)
        {
            this._userRepository = userRepository;
            this._keeChewSoonChewHistoryRepository = keeChewSoonChewHistoryRepository;
            this._helpCenterRepository = helpCenterRepository;
            this._footRepository = footRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<HelpCenterDTO> GetAll()
        {
            List<HelpCenterDTO> helpCenterDTOs = new List<HelpCenterDTO>();
            var helpCenters = _helpCenterRepository.GetAll();
            foreach (var helpCenter in helpCenters)
            {
                var reportedByUser = _userRepository.GetSingleByID(helpCenter.ReportByID);
                var reportedOnUser = _userRepository.GetSingleByID(helpCenter.ReportOnID);
                var connecttion = _keeChewSoonChewHistoryRepository.GetSingleByID(helpCenter.ConnectionID);
                var foot = _footRepository.GetSingleByID(connecttion.FootID);

                var helpCenterDTO = new HelpCenterDTO {
                    ID = helpCenter.ID,
                    ConnectionName = foot.Name,
                    ReportByName = reportedByUser.FullName,
                    ReportOnName = reportedOnUser.FullName,
                    ContentText = helpCenter.ContentText,
                    Status = helpCenter.Status,
                    ReportedDate = helpCenter.ReportedDate,
                    ReportedIssue = helpCenter.ReportedIssue
                    

                };
                helpCenterDTOs.Add(helpCenterDTO);

            }
            return  helpCenterDTOs;
        }

        public HelpCenterTbl GetSingleById(int id)
        {
            return _helpCenterRepository.GetSingleByID(id);
        }

        public void SaveChange()
        {
            _unitOfWork.Save();
        }
    }
}
