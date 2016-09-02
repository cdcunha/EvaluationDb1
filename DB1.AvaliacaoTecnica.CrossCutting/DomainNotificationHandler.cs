using DB1.AvaliacaoTecnica.SharedKernel;
using DB1.AvaliacaoTecnica.SharedKernel.Events;
using System.Collections.Generic;
using System;

namespace DB1.AvaliacaoTecnica.CrossCutting
{
    public class DomainNotificationHandler : IHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public void Handle(DomainNotification args)
        {
            _notifications.Add(args);
        }

        public bool HasNotifications()
        {
            return GetValue().Count > 0;
        }

        public IEnumerable<DomainNotification> Notify()
        {
            return GetValue();
        }

        private List<DomainNotification> GetValue()
        {
            return _notifications;
        }

        public void Dispose()
        {
            this._notifications = new List<DomainNotification>();
        }
    }
}
