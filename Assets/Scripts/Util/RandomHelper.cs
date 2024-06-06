using UnityEngine;

public class RandomHelper : MonoBehaviour
{
    public static int GetRandomNumber(int min, int max)
    {
        return Random.Range(min, max);
    }
}
