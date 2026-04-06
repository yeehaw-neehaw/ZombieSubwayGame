using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 0.76f);
    }
}
