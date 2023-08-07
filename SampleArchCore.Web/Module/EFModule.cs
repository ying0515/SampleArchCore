using Autofac;
using Microsoft.EntityFrameworkCore;
using SampleArch.Model;
using SampleArch.Repository;
using SampleArch.Repository.Interface;
using System;

namespace SampleArch.Web.Module
{
    public class EFModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());

            builder.RegisterType(typeof(SampleArchContext)).As(typeof(DbContext)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerRequest();

        }
    }
}