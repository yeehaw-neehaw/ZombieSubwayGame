using UnityEngine;

public class ProjectileDeleter : MonoBehaviour
{
    public int piercePower = 1;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Player"))
        {
            if (piercePower <= 0)
            {
                Destroy(gameObject);
            }
            piercePower -= 1;
        }
    }
}
