using System.Reflection;
using Autofac;
using EVA.Application.MediatR.Behaviors;
using MediatR;
using Module = Autofac.Module;


namespace EVA.Application.Autofac.Modules
{
    public class MediatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            builder.Register<ServiceFactory>(ctx =>
            {
                var componentContext = ctx.Resolve<IComponentContext>();
                return t => componentContext.TryResolve(t, out var o) ? o : null;

            });

            builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));            
        }
    }
}
