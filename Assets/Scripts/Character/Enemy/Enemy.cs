using UnityEngine;

[RequireComponent(typeof(EnemyShooter))]
public class Enemy : Character
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }
}
