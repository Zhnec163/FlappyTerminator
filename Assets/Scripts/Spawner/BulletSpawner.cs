using UnityEngine;
using UnityEngine.Pool;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private int _poolCapacity = 20;
    [SerializeField] private int _maxSize = 40;
    
    private ObjectPool<Bullet> _pool;
    
    private Bullet HandleActionOnCreate()
    {
        return Instantiate(_prefab);
    }
    
    private void HandleActionOnGet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.StartFlying();
    }
    
    private void HandleActionOnRelease(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void HandleActionOnDestroy(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }
    
    private void Init()
    {
        _pool = new ObjectPool<Bullet>
        (
            createFunc: HandleActionOnCreate,
            actionOnGet:  HandleActionOnGet,
            actionOnRelease: obj => HandleActionOnRelease(obj),
            actionOnDestroy: obj => HandleActionOnDestroy(obj),
            defaultCapacity: _poolCapacity,
            maxSize: _maxSize
        );
    }
    
    public Bullet Get()
    {
        if (_pool == null)
            Init();
        
        return _pool.Get();
    }
    
    public void Release(Bullet bullet)
    {
        if (_pool == null)
            Init();
        
        _pool.Release(bullet);
    }
}
