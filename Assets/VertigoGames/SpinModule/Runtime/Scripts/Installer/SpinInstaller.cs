using UnityEngine;
using VContainer;
using VertigoGames.General.Runtime.Scripts.Factory;
using VertigoGames.General.Runtime.Scripts.Installer;
using VertigoGames.SpinModule.Runtime.Scripts.Model;
using VertigoGames.SpinModule.Runtime.Scripts.UI;

namespace VertigoGames.SpinModule.Runtime.Scripts.Installer
{
    public class SpinInstaller : MonoInstaller
    {
        [SerializeField]
        private SpinDataList _spinDataList;
        
        public override void Install(InstallerData installerData)
        {
            installerData.ContainerBuilder.RegisterInstance(_spinDataList);
            installerData.ContainerBuilder.Register<DefaultPrefabFactory<CollectedSpinRewardView>>(Lifetime.Singleton);
        }
    }
}