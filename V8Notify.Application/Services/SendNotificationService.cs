using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using V8Notify.Application.Interfaces;
using V8Notify.Application.Models.CustomModels;
using V8Notify.Domain.Interfaces;
using V8Notify.Domain.Models.Notify;

namespace V8Notify.Application.Services
{
    public class SendNotificationService : BaseMasterService, ISendNotificationServices
    {
        private readonly string _apiNotify;
        public SendNotificationService(
            IV8NotifyRepositoryWrapper v8NotifyRepository,
            IConfiguration configuration) : base(v8NotifyRepository)
        {
            _apiNotify = configuration["NotifyDomain"];

            if (string.IsNullOrWhiteSpace(_apiNotify))
            {
                throw new Exception("Not found domain Notification Service, please check appsettings config");
            }
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

        public async Task<ServiceResult> PushToUsers(int[] idsUser, string content, string url, int IDImpactUser = 0, int IDAffectedObject = 0, int AffectedObjectType = 0, int IDImpactAgency = 0, int IDImpactOrgan = 0, int UserImpactType = 0)
        {
            try
            {
                List<Notification> listNoti = new List<Notification>();
                foreach (var userId in idsUser)
                {
                    listNoti.Add(new Notification
                    {
                        UserId = userId,
                        Content = content,
                        IsRead = false,
                        CreatedDate = DateTime.Now,
                        Url = url,
                        IDImpactUser = IDImpactUser,
                        IDAffectedObject = IDAffectedObject,
                        AffectedObjectType = AffectedObjectType,
                        IDImpactAgency = IDImpactAgency,
                        IDImpactOrgan = IDImpactOrgan,
                        UserImpactType = UserImpactType
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
