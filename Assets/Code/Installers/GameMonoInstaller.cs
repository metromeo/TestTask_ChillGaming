using Zenject;

namespace CGTest
{
    public class GameMonoInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            GameBaseInstaller.Install(Container);
        }
    }
    
    public class GameBaseInstaller : Installer<GameBaseInstaller>
    {	    
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<JsonDataProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<SessionInitializer>().AsSingle();

            Container.Bind<PlayersModelsHolder>().FromComponentInHierarchy().AsSingle();
            Container.Bind<PlayerStatFactory>().AsSingle();
            Container.Bind<PlayerFactory>().AsSingle();
            Container.Bind<PlayerActionsHandler>().AsSingle();
            Container.Bind<PlayersViewHolder>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IActionsTargetHandler>().To<ActionsTargetHandlerDuel>().AsSingle();
            
            Container.Bind<BuffsSelector>().AsSingle();
            Container.Bind<BuffsApplier>().AsSingle();

            Container.Bind<UI_SessionInitializer>().FromComponentInHierarchy().AsSingle();

        }
    }
}
