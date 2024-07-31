using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int InitialCount = 10;

    [SerializeField] private Collider _bounds;

    [SerializeField] private GameObject _coinPrefab;

    [SerializeField] private Transform _coinsParent;

    private void Start()
    {
        for (var i = 0; i < InitialCount; i++)
            Spawn();
    }

    private void Spawn()
    {
        var min = _bounds.bounds.min;
        var max = _bounds.bounds.max;
        var val = new Vector3(Random.Range(min.x, max.x), 0, Random.Range(min.z, max.z));
        Instantiate(_coinPrefab, val, Quaternion.identity, _coinsParent);
    }
}