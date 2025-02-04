using Pooling;
using UnityEngine;

namespace Coins
{
    public class CoinsSpawner : MonoBehaviour
    {
        [SerializeField] private Collider _bounds;
        [SerializeField] private Coin _coinPrefab;
        [SerializeField] private Transform _coinsParent;
        
        public int InitialCount = 10;
        
        private ObjectPool<Coin> _pool;
        private const float CoinHeightSpawnPosition = .5f;
        
        private void Start()
        {
            _pool = new ObjectPool<Coin>(GetCoinInstance, Coin.TurnOn, Coin.TurnOff, InitialCount);

            for (var i = 0; i < InitialCount; i++)
            {
                InstantiateCoin();
            }
        }
        
        public void ReturnCoinToPool(Coin coin)
        {
            _pool.ReturnObject(coin);
        }

        public void OnCoinCollected()
        {
            InstantiateCoin();
        }

        private void InstantiateCoin()
        {
            var coin = _pool.GetObject();
            var min = _bounds.bounds.min;
            var max = _bounds.bounds.max;
            var val = new Vector3(Random.Range(min.x, max.x), CoinHeightSpawnPosition, Random.Range(min.z, max.z));
            coin.transform.position = val;
        }

        private Coin GetCoinInstance()
        {
            var coin = Instantiate(_coinPrefab, _coinsParent);
            return coin;
        }
    }
}