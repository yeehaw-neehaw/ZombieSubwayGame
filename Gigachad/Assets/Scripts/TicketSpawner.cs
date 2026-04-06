/****************************************************************************
* File Name: TicketSpawner
* Author: Neha Sankarkumar
* DigiPen Email: neha.sankarkumar@digipen.edu
* Course: Video Game Programming (Game Projects)
*
* Description: This code spawns a ticket after a set amount of time, randomly
* in one of eight set locations.
****************************************************************************/
using System;
using UnityEngine;

public class TicketSpawner : MonoBehaviour
{
    public GameObject TicketPrefab;
    public static bool TicketSpawned = false; // prevents tickets from spawning when one exists already
    private float CooldownMax = 3f; // TIMERMAX seconds elapse before a ticket will spawn
    private float SpawnCooldown = 0f; // the actual timer
    public static int TicketsCollected; // amt of tix player has collected
    public static int TicketsNeeded; // tickets needed for every passenger on train
    public int TicketsCreated; // how many tickets have already been made
    public GameObject winText; // !! need be removed

    [Header("Spawn Spots")] // 8 spawn points placed in unity editor
    [SerializeField] private Transform spawn1;
    [SerializeField] private Transform spawn2;
    [SerializeField] private Transform spawn3;
    [SerializeField] private Transform spawn4;
    [SerializeField] private Transform spawn5;
    [SerializeField] private Transform spawn6;
    [SerializeField] private Transform spawn7;
    [SerializeField] private Transform spawn8;

    void Start()
    {
        winText.gameObject.SetActive(false);
        PlayerStats.TicketsCollected = 0;
        TicketsCreated = 0;
        TicketsNeeded = PlayerStats.TicketsNeeded;
        TicketSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((SpawnCooldown < CooldownMax) && !TicketSpawned) // if the cooldown timer has not yet reached TIMERMAX seconds
        {
            SpawnCooldown += Time.deltaTime; // update timer
        }
        else if (!TicketSpawned && (SpawnCooldown >= CooldownMax)
            && TicketsCreated < PlayerStats.TicketsNeeded
            && !EnemySpawning.NoMoreTickets) 
            // if a ticket does not already exist + cooldown done
            // + player still needs tickets + round isnt terminated
        {
            SpawnCooldown = 0; // reset timer
            switch (UnityEngine.Random.Range(1, 9)) // randomly pick 1-8, instantiate a ticket in one of 8 spots
            {
                case 1:
                    Instantiate(TicketPrefab,spawn1.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(TicketPrefab, spawn2.position, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(TicketPrefab, spawn3.position, Quaternion.identity);
                    break;
                case 4:
                    Instantiate(TicketPrefab, spawn4.position, Quaternion.identity);
                    break;
                case 5:
                    Instantiate(TicketPrefab, spawn5.position, Quaternion.identity);
                    break;
                case 6:
                    Instantiate(TicketPrefab, spawn6.position, Quaternion.identity);
                    break;
                case 7:
                    Instantiate(TicketPrefab, spawn7.position, Quaternion.identity);
                    break;
                case 8:
                    Instantiate(TicketPrefab, spawn8.position, Quaternion.identity);
                    break;
            }
            TicketsCreated += 1; // more tix created
            TicketSpawned = true; // the current ticket HAS spawned -- prevents infinite cloning
        }

        if (PlayerStats.TicketsCollected >= PlayerStats.TicketsNeeded)
        {
            winText.gameObject.SetActive(true); // !! need be removed
        }
    }
}
