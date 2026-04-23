using VContainer;
using VContainer.Unity;

namespace VertigoGames.General.Runtime.Scripts.Installer
{
    public class Installer : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            InstallerData installerData = new InstallerData(builder, Parent);
            
            MonoInstaller[] monoInstallers = GetComponentsInChildren<MonoInstaller>();
            for (int index = 0; index < monoInstallers.Length; index++)
            {
                MonoInstaller monoInstaller = monoInstallers[index];
                monoInstaller.Install(installerData);
            }
        }
    }
}