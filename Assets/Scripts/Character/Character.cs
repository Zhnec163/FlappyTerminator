using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
            ToDie();
    }
    
    private void ToDie()
    {
        gameObject.SetActive(false);
    }
}
