using VContainer;
using VContainer.Unity;

namespace VertigoGames.General.Runtime.Scripts.Installer
{
    public class InstallerData
    {
        public readonly IContainerBuilder ContainerBuilder;

        public readonly LifetimeScope ParentScope;

        public InstallerData(IContainerBuilder containerBuilder, LifetimeScope parentScope)
        {
            ContainerBuilder = containerBuilder;
            ParentScope = parentScope;
        }
    }
}