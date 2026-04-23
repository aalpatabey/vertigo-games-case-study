using VContainer;
using VertigoGames.General.Runtime.Scripts.Installer;

namespace VertigoGames.UserModule.Runtime.Scripts.Installer
{
    public class UserDataSplashInstaller : MonoInstaller
    {
        public override void Install(InstallerData installerData)
        {
            installerData.ContainerBuilder.Register<UserDataSplashInitializable>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}