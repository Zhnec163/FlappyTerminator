using System.Collections;
using UnityEngine;

public class EnemyShooter : Shooter
{
    private WaitForSeconds _delay;

    public void Init(float bulletSpeed, float rate, BulletSpawner bulletSpawner)
    {
        base.Init(bulletSpeed, bulletSpawner);
        _delay = new WaitForSeconds(rate);
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        while (enabled)
        {
            base.Shooting();
            yield return _delay;
        }
    }
}