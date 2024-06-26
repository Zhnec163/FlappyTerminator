using UnityEngine;

[RequireComponent(typeof(PlayerMover), typeof(PlayerShooter))]
public class Player : Character
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private BulletSpawner _bulletSpawner;

    private void Awake()
    {
        GetComponent<PlayerShooter>().Init(_bulletSpeed, _bulletSpawner);
    }
}
