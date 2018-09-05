using JetBrains.Annotations;
using System;
using System.Reflection;

namespace Acw.Core.Acw.Modularity
{
    public abstract class AcwModule :
        IAcwModule,
        IOnPreApplicationInitialization,
        IOnApplicationInitialization,
        IOnPostApplicationInitialization,
        IOnApplicationShutdown,
        IPreConfigureServices,
        IPostConfigureServices
    {
        public virtual void ConfigureServices(ServiceConfigurationContext context)
        {
           
        }

        public virtual void OnApplicationInitialization([NotNull] ApplicationInitializationContext context)
        {
            
        }

        public virtual void OnApplicationShutdown([NotNull] ApplicationShutdownContext context)
        {
            
        }

        public virtual void OnPostApplicationInitialization([NotNull] ApplicationInitializationContext context)
        {
            
        }

        public virtual void OnPreApplicationInitialization([NotNull] ApplicationInitializationContext context)
        {
            
        }

        public virtual void PostConfigureServices(ServiceConfigurationContext context)
        {
            
        }

        public virtual void PreConfigureServices(ServiceConfigurationContext context)
        {
            
        }

        public static bool IsAcwModule(Type type)
        {
            var typeInfo = type.GetTypeInfo();

            return
                typeInfo.IsClass &&
                !typeInfo.IsAbstract &&
                !typeInfo.IsGenericType &&
                typeof(IAcwModule).GetTypeInfo().IsAssignableFrom(type);
        }

        internal static void CheckAcwModuleType(Type moduleType)
        {
            if (!IsAcwModule(moduleType))
            {
                throw new ArgumentException("Given type is not an Acw module: " + moduleType.AssemblyQualifiedName);
            }
        }
    }
}
