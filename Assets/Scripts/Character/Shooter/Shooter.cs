using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    private float _bulletSpeed;
    private BulletSpawner _bulletSpawner;
    private float _offsetX = 1.5F;

    public void Init(float bulletSpeed, BulletSpawner bulletSpawner)
    {
        _bulletSpeed = bulletSpeed;
        _bulletSpawner = bulletSpawner;
    }

    public void Shooting()
    {
        Bullet bullet = _bulletSpawner.Get();
        bullet.transform.position = transform.position + transform.up * _offsetX;
        bullet.transform.rotation = transform.rotation;
        bullet.Init(_bulletSpeed, HandleBulletCollision);
    }

    private void HandleBulletCollision(Bullet bullet)
    {
        _bulletSpawner.Release(bullet);
    }
}