using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace VertigoGames.General.Runtime.Scripts.Installer
{
    public abstract class MonoInstaller : MonoBehaviour
    {
        public abstract void Install(InstallerData installerData);
    }
}