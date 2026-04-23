using VContainer;
using VContainer.Unity;
using VertigoGames.General.Runtime.Scripts.Installer;

namespace VertigoGames.SplashModule.Runtime.Scripts.Installer
{
    public class SplashInstaller : MonoInstaller
    {
        public override void Install(InstallerData installerData)
        {
            installerData.ContainerBuilder.RegisterEntryPoint<SplashLoader>(Lifetime.Singleton);
        }
    }
}