using System.Threading.Tasks;
using V8Notify.Application.Models.CustomModels;
using V8Notify.Domain.Models.Notify;

namespace V8Notify.Application.Interfaces
{
    public interface ISendNotificationServices : IBaseMasterService<Notification>
    {
        Task<ServiceResult> PushToUsers(int[] idsUser, string content, string url, int IDImpactUser = 0, int IDAffectedObject = 0, int AffectedObjectType = 0, int IDImpactAgency = 0, int IDImpactOrgan = 0, int UserImpactType = 0);
    }
}
