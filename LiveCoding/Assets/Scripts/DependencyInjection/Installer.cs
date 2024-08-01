using Coins;
using Zenject;

namespace DependencyInjection
{
    public class Installer : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<CoinCollectedSignal>();
            Container.Bind<ScoreController>().AsSingle();
            Container.Bind<CoinsSpawner>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ScoreText>().FromComponentInHierarchy().AsSingle();
            Container.BindSignal<CoinCollectedSignal>()
                .ToMethod<ScoreController>(x => x.OnCoinCollectedSignalReceived).FromResolve();
        }
    }
}