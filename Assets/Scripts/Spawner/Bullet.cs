using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed;

    public event Action<Bullet> OnCollisionDetected;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollisionDetected.Invoke(this);
    }

    private void OnEnable()
    {
        OnCollisionDetected = null;
    }

    public void Init(float speed, Action<Bullet> onCollisionDetected)
    {
        _speed = speed;
        OnCollisionDetected += onCollisionDetected;
        StartFlying();
    }

    public void StartFlying()
    {
        StartCoroutine(Flying());
    }

    private IEnumerator Flying()
    {
        while (enabled)
        {
            transform.position += transform.up * _speed * Time.deltaTime;
            yield return null;
        }
    }
}