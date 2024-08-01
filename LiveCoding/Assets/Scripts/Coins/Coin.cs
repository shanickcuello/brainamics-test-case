using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Coins
{
    public class Coin : MonoBehaviour, IPointerClickHandler
    {
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
            transform.DOLocalRotate(new Vector3(360 * 50, 0, 0), 50, RotateMode.FastBeyond360).SetRelative(true)
                .SetEase(Ease.Linear);
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