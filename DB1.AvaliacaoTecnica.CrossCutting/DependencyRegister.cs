﻿using DB1.AvaliacaoTecnica.Domain.Contracts.Repositories;
using DB1.AvaliacaoTecnica.Infrastructure.Data;
using DB1.AvaliacaoTecnica.Infrastructure.Persistence;
using DB1.AvaliacaoTecnica.Infrastructure.Repositories;
using DB1.AvaliacaoTecnica.SharedKernel.Events;
using DB1.AvaliacaoTecnica.SharedKernel;
using Microsoft.Practices.Unity;
using DB1.AvaliacaoTecnica.Domain.Services;
using DB1.AvaliacaoTecnica.ApplicationService;

namespace DB1.AvaliacaoTecnica.CrossCutting
{
    public class DependencyRegister
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        public static void Register(UnityContainer container)
        {
            container.RegisterType<StoreDataContext, StoreDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IVacancyRepository, VacancyRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITechnologyRepository, TechnologyRepository>(new HierarchicalLifetimeManager());

            container.RegisterType<ITechnologyApplicationService, TechnologyApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IVacancyApplicationService, VacancyApplicationService>(new HierarchicalLifetimeManager());

            container.RegisterType<IHandler<DomainNotification>, DomainNotificationHandler>(new HierarchicalLifetimeManager());
        }
    }
}
