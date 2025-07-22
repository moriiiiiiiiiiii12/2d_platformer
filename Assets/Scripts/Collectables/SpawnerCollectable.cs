using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnerCollectable : MonoBehaviour
{
    [SerializeField] private Collider2D _platformCollider;
    [SerializeField] private Collectable _prefabCollectable;

    [SerializeField] private int _poolSize = 5;
    [SerializeField] private float _spawnInterval = 1f;

    private int _countActiveCollectables = 0;
    private ObjectPool<Collectable> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Collectable>
        (
        createFunc: () =>
        {
            Collectable collectable = Instantiate(_prefabCollectable);
            collectable.gameObject.SetActive(false);

            return collectable;
        },
        actionOnGet: (collectable) => ActionOnGet(collectable),
        actionOnRelease: (collectable) => collectable.gameObject.SetActive(false),
        actionOnDestroy: (collectable) => Object.Destroy(collectable),
        collectionCheck: true,
        defaultCapacity: _poolSize,
        maxSize: _poolSize
        );
    }

    private void Start() => StartCoroutine(Spawn());

    private IEnumerator Spawn()
    {
        while (enabled)
        {
            if (_countActiveCollectables <= _poolSize)
            {
                _countActiveCollectables++;
                Collectable collectable = _pool.Get();

                collectable.OnCollected += Destroy;
            }

            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    private void ActionOnGet(Collectable collectable)
    {
        collectable.transform.position = GetRandomPositionPlatform();

        collectable.gameObject.SetActive(true);
    }
    
    private void Destroy(Collectable collectable)
    {
        if (collectable != null)
        {
            collectable.OnCollected -= Destroy;

            _pool.Release(collectable);
            _countActiveCollectables--;
        }
    }

    private Vector2 GetRandomPositionPlatform()
    {
        Bounds boundsPlatform = _platformCollider.bounds;

        float randomX = Random.Range(boundsPlatform.min.x, boundsPlatform.max.x);
        float randomY = Random.Range(boundsPlatform.min.y, boundsPlatform.max.y);

        return new Vector2(randomX, randomY);
    }
}