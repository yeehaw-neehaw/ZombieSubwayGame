using UnityEngine;

public class ProjectileDeleter : MonoBehaviour
{
    private int PierceCounter = 1;
    public int PierceLevel = 3;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            if (PierceCounter < PierceLevel)
            {
                PierceCounter += 1;
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
    }
}
