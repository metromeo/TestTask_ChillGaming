using UnityEngine;
using Zenject;

namespace CGTest
{
    [CreateAssetMenu(menuName = "CGTest/Game Settings")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        public DataSettings DataSettings;
        
        public override void InstallBindings()
        {
            Container.BindInstance(DataSettings);
        }
    }
}
