using UnityEngine;

public class PlayerShooter : Shooter
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
            Shooting();
    }
}