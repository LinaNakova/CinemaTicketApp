using System.Threading.Tasks;

namespace CinemaTicketApp.Service.Interface
{
    public interface IBackgroundEmailSender
    {
        Task DoWork();
    }
}
