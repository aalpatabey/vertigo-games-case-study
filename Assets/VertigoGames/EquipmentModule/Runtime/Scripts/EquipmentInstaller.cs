using UnityEngine;
using VContainer;
using VertigoGames.General.Runtime.Scripts.Installer;

namespace VertigoGames.EquipmentModule.Runtime.Scripts
{
    public class EquipmentInstaller : MonoInstaller
    {
        [SerializeField]
        private GunAssetProvider _gunAssetProvider;

        [SerializeField]
        private PointRewardAssetProvider _pointRewardAssetProvider;
        
        [SerializeField]
        private CosmeticRewardAssetProvider _cosmeticRewardAssetProvider;
        
        [SerializeField]
        private ConsumableRewardAssetProvider _consumableRewardAssetProvider;
        
        public override void Install(InstallerData installerData)
        {
            installerData.ContainerBuilder.RegisterInstance(_gunAssetProvider).AsImplementedInterfaces();
            installerData.ContainerBuilder.RegisterInstance(_pointRewardAssetProvider).AsImplementedInterfaces();
            installerData.ContainerBuilder.RegisterInstance(_cosmeticRewardAssetProvider).AsImplementedInterfaces();
            installerData.ContainerBuilder.RegisterInstance(_consumableRewardAssetProvider).AsImplementedInterfaces();
        }
    }
}