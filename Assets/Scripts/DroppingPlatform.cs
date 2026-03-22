using UnityEngine;

public class DroppingPlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, 1f);
    }
}
