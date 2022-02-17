using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using V8Notify.Application.Interfaces;
using V8Notify.Application.Models;
using V8Notify.Application.Models.CustomModels;
using V8Notify.Domain.Interfaces;
using V8Notify.Domain.Models.Notify;

namespace V8Notify.Application.Services
{
    public class NotificationService : BaseMasterService, INotificationService
    {
        public NotificationService(IV8NotifyRepositoryWrapper v8NotifyRepository) : base(v8NotifyRepository)
        {

        }

        public Task<ServiceResult> Create(Notification model)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> Delete(object id)
        {
            throw new NotImplementedException();
        }

        public Task<Notification> Get(object id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Notification>> Gets()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult> PushToUsers(VMSendNotification model)
        {
            try
            {
                List<Notification> listNoti = new List<Notification>();
                foreach (var userId in model.idsUser)
                {
                    listNoti.Add(new Notification
                    {
                        UserId = userId,
                        Content = model.content,
                        IsRead = false,
                        CreatedDate = DateTime.Now,
                        Url = model.url,
                        IDImpactUser = model.IDImpactUser,
                        IDAffectedObject = model.IDAffectedObject,
                        AffectedObjectType = model.AffectedObjectType,
                        IDImpactAgency = model.IDImpactAgency,
                        IDImpactOrgan = model.IDImpactOrgan,
                        UserImpactType = model.UserImpactType
                    });
                }

                await _v8NotifyRepo.Notification.InsertAsync(listNoti);
                await _v8NotifyRepo.SaveAync();
                return new ServiceResultSuccess();
            }
            catch (Exception ex)
            {
                return new ServiceResultError(ex.Message);
            }
        }

        public Task<ServiceResult> Update(Notification model)
        {
            throw new NotImplementedException();
        }
    }
}
