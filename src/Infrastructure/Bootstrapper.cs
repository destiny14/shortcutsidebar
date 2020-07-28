namespace ShortcutSidebar.Infrastructure
{
    using System;
    using Autofac;
    using ViewModels;

    public static class Bootstrapper
    {
        private static ILifetimeScope _rootScope;

        public static ViewModelBase RootVisual
        {
            get
            {
                if (_rootScope == null)
                    Start();

                if (_rootScope == null)
                    throw new InvalidOperationException();

                return _rootScope.Resolve<TaskbarIconViewModel>();
            }
        }

        public static void Start()
        {
            if (_rootScope != null) return;

            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<TaskbarIconViewModel>().InstancePerLifetimeScope();

            _rootScope = containerBuilder.Build();
        }

        public static void Stop()
        {
            _rootScope.Dispose();
            _rootScope = null;
        }
    }
}