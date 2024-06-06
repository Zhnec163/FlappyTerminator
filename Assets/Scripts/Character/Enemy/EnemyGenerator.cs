using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private int _maxEnemy;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField, Space(15)] private float _bulletSpeed;
    [SerializeField] private float _rateShooting;
    [SerializeField] private BulletSpawner _bulletSpawner;

    private void Awake()
    {
        if (_maxEnemy > _spawnPoints.Count)
            _maxEnemy = _spawnPoints.Count;
        
        SpawnOnRandomPosition();
    }

    private void SpawnOnRandomPosition()
    {
        for (int i = 0; i < _maxEnemy; i++)
        {
            Transform spawnPoint = _spawnPoints[RandomHelper.GetRandomNumber(0, _spawnPoints.Count)];
            _spawnPoints.Remove(spawnPoint);
            Enemy enemy = Instantiate(_prefab, spawnPoint.position, _prefab.transform.rotation);
            
            if (enemy.TryGetComponent(out EnemyShooter enemyShooter))
                enemyShooter.Init(_bulletSpeed, _rateShooting, _bulletSpawner);
        }
    }
}