using VContainer;
using VertigoGames.General.Runtime.Scripts.Installer;

namespace VertigoGames.SpendModule.Runtime.Scripts.Installer
{
    public class SpendInstaller : MonoInstaller
    {
        public override void Install(InstallerData installerData)
        {
            installerData.ContainerBuilder.Register<SpendController>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
        }
    }
}