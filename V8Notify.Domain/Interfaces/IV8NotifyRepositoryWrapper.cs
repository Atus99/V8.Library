using System.Threading.Tasks;
namespace V8Notify.Domain.Interfaces
{
    public interface IV8NotifyRepositoryWrapper
    {
        INotificationRepository Notification { get; }
        Task SaveAync();
    }
}
