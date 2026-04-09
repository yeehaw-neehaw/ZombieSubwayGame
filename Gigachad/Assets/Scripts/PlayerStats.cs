/****************************************************************************
* File Name: PlayerStats.c
* Author: Michael Chiodo & Neha Sankarkumar
* DigiPen Email: michael.chiodo@digipen.edu, neha.sankarkumar@digipen.edu
* Course: Game Projects
*
* Description: Manages and maintains all of the upgrade variables across 
* scenes.
* 
****************************************************************************/

using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;
    public static int PlayerCash = 0;
    public static float ReloadSpeed = 2.5f;
    public static float PlayerMovementSpeed = 5f;
    public static float ShootingSpeed = 0.3f;
    public static float BulletDamage = 2f;
    public static int RicochetLevel = 0;
    public static int TicketsCollected = 0;
    public static int TicketsNeeded = 6;
    public static int PassengerCount = 5;
    public static int CurrentLevel = 0;

    private void Awake()
    {
        //Makes sure there aren't duplicates as well as telling the game to not destroy this object
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
