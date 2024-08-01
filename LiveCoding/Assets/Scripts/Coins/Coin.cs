using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Coins
{
    public class Coin : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private CoinsAnimationSettings _animationSettings;
        private SignalBus _signalBus;
        private CoinsSpawner _coinsSpawner;

        [Inject]
        public void Construct(SignalBus signalBus, CoinsSpawner coinsSpawner)
        {
            _signalBus = signalBus;
            _coinsSpawner = coinsSpawner;
        }

        private void Start()
        {
            RotateInfinitely();
        }

        private void RotateInfinitely()
        {
            transform.DOLocalRotate(
                    _animationSettings.rotationVector * _animationSettings.rotationSpeed,
                    _animationSettings.duration,
                    _animationSettings.rotateMode)
                .SetRelative(_animationSettings.relative)
                .SetEase(_animationSettings.easeAnimationCurve)
                .SetLoops(_animationSettings.loopsAmount);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _signalBus.Fire(new CoinCollectedSignal());
            _coinsSpawner.ReturnCoinToPool(this);
        }

        public static void TurnOn(Coin coin)
        {
            coin.gameObject.SetActive(true);
        }

        public static void TurnOff(Coin coin)
        {
            coin.gameObject.SetActive(false);
        }
    }
}