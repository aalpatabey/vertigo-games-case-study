using VContainer;
using VertigoGames.General.Runtime.Scripts.Installer;

namespace VertigoGames.SceneNavigationModule.Runtime.Scripts.Installer
{
    public class SceneNavigationInstaller : MonoInstaller
    {
        public override void Install(InstallerData installerData)
        {
            installerData.ContainerBuilder.Register<SceneNavigationController>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            installerData.ContainerBuilder.Register<UnitySceneNavigationService>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}