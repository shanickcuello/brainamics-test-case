using Pooling;
using UnityEngine;

namespace Coins
{
    public class CoinsSpawner : MonoBehaviour
    {
        public int InitialCount = 10;
        public ObjectPool<Coin> Pool;

        [SerializeField] private Collider _bounds;

        [SerializeField] private Coin _coinPrefab;

        [SerializeField] private Transform _coinsParent;
        
        
        private void Start()
        {
            Pool = new ObjectPool<Coin>(GetCoinInstance, Coin.TurnOn, Coin.TurnOff, InitialCount);

            for (var i = 0; i < InitialCount; i++)
            {
                InstantiateCoin();
            }
        }

        private void InstantiateCoin()
        {
            var coin = Pool.GetObject();
            var min = _bounds.bounds.min;
            var max = _bounds.bounds.max;
            var val = new Vector3(Random.Range(min.x, max.x), 0, Random.Range(min.z, max.z));
            coin.transform.position = val;
        }

        private Coin GetCoinInstance()
        {
            var coin = Instantiate(_coinPrefab, _coinsParent);
            return coin;
        }

        public void ReturnCoinToPool(Coin coin)
        {
            Pool.ReturnObject(coin);
        }

        public void OnCoinCollected()
        {
            InstantiateCoin();
        }
    }
}