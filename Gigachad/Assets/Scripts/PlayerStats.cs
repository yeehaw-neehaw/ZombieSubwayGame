using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;
    public static int PlayerCash = 0;
    public static float ReloadSpeed = 2.5f;
    public static float PlayerMovementSpeed = 5f;
    public static float ShootingSpeed = .1f;
    public static float BulletDamage = 2f;
    public static int RicochetLevel = 1;
    public static int TicketsCollected = 0;
    public static int PassengerCount = 5;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
