using UnityEngine;
using VContainer;
using VertigoGames.General.Runtime.Scripts.Installer;

namespace VertigoGames.WalletModule.Runtime.Scripts
{
    public class CashInstaller : MonoInstaller
    {
        [SerializeField]
        private CashRewardAssetProvider _cashRewardAssetProvider;
        
        public override void Install(InstallerData installerData)
        {
            installerData.ContainerBuilder.Register<CashController>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            installerData.ContainerBuilder.Register<CashRewardEarnAndSpendStrategy>(Lifetime.Singleton).AsImplementedInterfaces();
            installerData.ContainerBuilder.RegisterInstance(_cashRewardAssetProvider).AsImplementedInterfaces();
        }
    }
}