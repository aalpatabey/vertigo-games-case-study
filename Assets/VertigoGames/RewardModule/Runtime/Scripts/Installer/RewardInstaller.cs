using VContainer;
using VertigoGames.General.Runtime.Scripts.Installer;

namespace VertigoGames.RewardModule.Runtime.Scripts.Installer
{
    public class RewardInstaller : MonoInstaller
    {
        public override void Install(InstallerData installerData)
        {
            installerData.ContainerBuilder.Register<RewardAssetProvider>(Lifetime.Singleton);
            installerData.ContainerBuilder.Register<RewardEarnController>(Lifetime.Singleton);
        }
    }
}