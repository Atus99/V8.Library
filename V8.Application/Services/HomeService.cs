using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V8.Application.Commons;
using V8.Application.Interfaces;
using V8.Application.Models.ViewModels;
using V8.Domain.Interfaces.V8;
using V8.Domain.Interfaces.V8Notify;

namespace V8.Application.Services
{
    public class HomeService : IHomeServices
    {
        protected IV8RepositoryWrapper _v8Repo;
        protected IV8NotifyRepositoryWrapper _v8NotifyRepo;
        protected IMapper _mapper;

        public HomeService(IV8RepositoryWrapper v8Repo
            , IV8NotifyRepositoryWrapper v8NotifyRepo
            , IMapper mapper)
        {
            _v8Repo = v8Repo;
            _v8NotifyRepo = v8NotifyRepo;
            _mapper = mapper;
        }

        // Get List Notification
        public async Task<PaginatedList<VMNotification>> GetListNotificationPaging(NotificationCondition condition)
        {
            IQueryable<Domain.Models.V8Notify.Notification> temp; //<> List<Notification>
            var toDate = Utils.GetDate(condition.ToDate) ?? DateTime.MinValue;
            var fromDate = Utils.GetDate(condition.FromDate) ?? DateTime.MaxValue;
            if(condition.Status > 0)
            {
                temp = from n in _v8NotifyRepo.Notification.GetAll().AsNoTracking()
                       where n.UserId == condition.UserId
                       && n.IsRead == condition.NotiStatus
                       && (string.IsNullOrWhiteSpace(condition.Keyword) || n.Content.Contains(condition.Keyword))
                       && n.CreatedDate.Date >= fromDate
                       && n.CreatedDate.Date <= toDate
                       orderby n.ID descending
                       select n;
            }
            else
            {
                temp = from n in _v8NotifyRepo.Notification.GetAll()
                       where n.UserId == condition.UserId
                       && (string.IsNullOrWhiteSpace(condition.Keyword) || n.Content.Contains(condition.Keyword))
                       && n.CreatedDate.Date >= fromDate
                       && n.CreatedDate.Date <= toDate
                       orderby n.ID descending
                       select n;
            }
            var total = await temp.LongCountAsync();
            if (total == 0)
            {
                return null;
            }
            int totalPage = (int)Math.Ceiling(total / (double)condition.PageSize);
            if (totalPage < condition.PageIndex)
            {
                condition.PageIndex = 1;
            }
            var notifications = await temp.Skip((condition.PageIndex - 1) * condition.PageSize).Take(condition.PageSize).ToListAsync();
            List<VMNotification> vmNotifications = _mapper.Map<List<VMNotification>>(notifications);
            return new PaginatedList<VMNotification>(vmNotifications, (int)total, condition.PageIndex, condition.PageSize);
        }

        public async Task<HeaderNotification> GetHeaderNotification(NotificationCondition condition)
        {
            int userID = 1; // ID User Login
            HeaderNotification rs = new HeaderNotification();
            var tempCount = from n in _v8NotifyRepo.Notification.GetAll().AsNoTracking()
                            where n.UserId == userID && !n.IsRead
                            select n;
            rs.TotalUnreadNotification = Convert.ToInt32(await tempCount.LongCountAsync());

            var temp = from n in _v8NotifyRepo.Notification.GetAll().AsNoTracking()
                       where n.UserId == userID
                       orderby n.ID descending
                       select n;

            var total = await temp.LongCountAsync();
            if (total == 0)
            {
                return new HeaderNotification();
            }

            int totalPage = (int)Math.Ceiling(total / (double)condition.PageSize);
            if (totalPage < condition.PageIndex)
            {
                condition.PageIndex = 1;
            }

            var notifications = await temp.Skip((condition.PageIndex - 1) * condition.PageSize).Take(condition.PageSize).ToListAsync();
            List<VMNotification> vmNotifications = _mapper.Map<List<VMNotification>>(notifications);

            rs.ListNotification = new PaginatedList<VMNotification>(vmNotifications, (int)total, condition.PageIndex, condition.PageSize);
            return rs;
        }

        // Read 1 Notification
        public async Task<bool> ReadNotification(int id)
        {
            var noti = await _v8NotifyRepo.Notification.GetAsync(id);
            if (!noti.IsNotEmpty())
            {
                return false;
            }

            noti.IsRead = true;
            await _v8NotifyRepo.Notification.UpdateAsync(noti);
            await _v8NotifyRepo.SaveAync();
            return true;
        }

        // Read All Notification
        public async Task<bool> ReadAllNotification()
        {
            var notifications = await _v8NotifyRepo.Notification.GetAllListAsync(n => n.IsRead == false && n.UserId == 1);
            if (notifications.IsEmpty())
            {
                return false;
            }

            foreach (var item in notifications)
            {
                item.IsRead = true;
            }
            await _v8NotifyRepo.Notification.UpdateAsync(notifications);
            await _v8NotifyRepo.SaveAync();
            return true;
        }
    }
}
