using VContainer;
using VContainer.Unity;
using VertigoGames.General.Runtime.Scripts.Installer;

namespace VertigoGames.UserModule.Runtime.Scripts.Installer
{
    public class UserDataGameplayInstaller : MonoInstaller
    {
        public override void Install(InstallerData installerData)
        {
            installerData.ContainerBuilder.RegisterInstance(installerData.ParentScope.Container.Resolve<UserDataHolder>().userData);
            installerData.ContainerBuilder.Register<UserDataSaver>(Lifetime.Singleton).AsSelf();
        }
    }
}