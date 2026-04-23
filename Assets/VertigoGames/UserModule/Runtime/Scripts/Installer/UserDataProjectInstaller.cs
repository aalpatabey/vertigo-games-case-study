using VContainer;
using VertigoGames.General.Runtime.Scripts.Installer;

namespace VertigoGames.UserModule.Runtime.Scripts.Installer
{
    public class UserDataProjectInstaller : MonoInstaller
    {
        public override void Install(InstallerData installerData)
        {
            installerData.ContainerBuilder.Register<UserDataHolder>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            installerData.ContainerBuilder.Register<UserDataStoreController>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            installerData.ContainerBuilder.Register<LocalUserDataStore>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}