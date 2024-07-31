using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Coins
{
    public class Coin : MonoBehaviour, IPointerClickHandler
    {
        private SignalBus _signalBus;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
    
        public void OnPointerClick(PointerEventData eventData)
        {
            _signalBus.Fire(new CoinCollectedSignal());
            Destroy(gameObject);
        }
    }
}