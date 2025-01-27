using UnityEngine;

public class BouncePlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) collision.transform.position += Vector3.up * 0.01f;
    }
}
