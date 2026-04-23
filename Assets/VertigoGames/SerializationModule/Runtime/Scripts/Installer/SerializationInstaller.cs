using VContainer;
using VertigoGames.General.Runtime.Scripts.Installer;

namespace VertigoGames.SerializationModule.Runtime.Scripts.Installer
{
    public class SerializationInstaller : MonoInstaller
    {
        public override void Install(InstallerData installerData)
        {
            installerData.ContainerBuilder.Register<SerializationController>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            installerData.ContainerBuilder.Register<JSONSerializationStrategy>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}