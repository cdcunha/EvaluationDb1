using DB1.AvaliacaoTecnica.Infrastructure.Persistence;
using DB1.AvaliacaoTecnica.SharedKernel;
using DB1.AvaliacaoTecnica.SharedKernel.Events;

namespace DB1.AvaliacaoTecnica.ApplicationService
{
    public class ApplicationService
    {
        private IUnitOfWork _unitOfWork;
        private IHandler<DomainNotification> _notifications;

        public ApplicationService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._notifications = DomainEvent.Container.GetService<IHandler<DomainNotification>>();
        }

        public bool Commit()
        {
            if(_notifications.HasNotifications())
                return false;

            _unitOfWork.Commit();
            return true;
        }
    }
}
