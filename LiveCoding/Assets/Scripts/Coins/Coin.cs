using System;
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