﻿using System;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Acw.Modularity
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
        protected internal bool SkipAutoServiceRegistration { get; protected set; }

        protected internal ServiceConfigurationContext ServiceConfigurationContext
        {
            get
            {
                if (_serviceConfigurationContext == null)
                {
                    throw new AcwException($"{nameof(ServiceConfigurationContext)} is only available in the {nameof(PreConfigureServices)}, {nameof(PreConfigureServices)} and {nameof(PreConfigureServices)} methods.");
                }

                return _serviceConfigurationContext;
            }
            internal set => _serviceConfigurationContext = value;
        }

        private ServiceConfigurationContext _serviceConfigurationContext;

        public virtual void PreConfigureServices(ServiceConfigurationContext context)
        {

        }
        public virtual void ConfigureServices(ServiceConfigurationContext context)
        {

        }
        public virtual void PostConfigureServices(ServiceConfigurationContext context)
        {

        }
        public virtual void OnPreApplicationInitialization(ApplicationInitializationContext context)
        {

        }
        public virtual void OnApplicationInitialization(ApplicationInitializationContext context)
        {

        }
        public virtual void OnPostApplicationInitialization(ApplicationInitializationContext context)
        {

        }
        public virtual void OnApplicationShutdown(ApplicationShutdownContext context)
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

        protected void Configure<TOptions>(Action<TOptions> configureOptions)
          where TOptions : class
        {
            ServiceConfigurationContext.Services.Configure(configureOptions);
        }

        protected void Configure<TOptions>(string name, Action<TOptions> configureOptions)
            where TOptions : class
        {
            ServiceConfigurationContext.Services.Configure(name, configureOptions);
        }

        protected void Configure<TOptions>(IConfiguration configuration)
            where TOptions : class
        {
            ServiceConfigurationContext.Services.Configure<TOptions>(configuration);
        }

        protected void Configure<TOptions>(IConfiguration configuration, Action<BinderOptions> configureBinder)
            where TOptions : class
        {
            ServiceConfigurationContext.Services.Configure<TOptions>(configuration, configureBinder);
        }

        protected void Configure<TOptions>(string name, IConfiguration configuration)
            where TOptions : class
        {
            ServiceConfigurationContext.Services.Configure<TOptions>(name, configuration);
        }

        protected void PreConfigure<TOptions>(Action<TOptions> configureOptions)
            where TOptions : class
        {
            ServiceConfigurationContext.Services.PreConfigure(configureOptions);
        }
    }
}
