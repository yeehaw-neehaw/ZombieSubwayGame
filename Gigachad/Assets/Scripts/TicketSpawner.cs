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
    public static bool TicketSpawned = false;
    private float TimerMax = 3f; // TIMERMAX seconds elapse before a ticket will spawn
    private float TimerCounter = 0f; // the actual timer
    public static int TicketsCollected = 0;
    public int TicketsNeeded = 5;
    public int TicketsCreated = 0;

    // Update is called once per frame
    void Update()
    {
        if ((TimerCounter < TimerMax) && !TicketSpawned) // if the timer has not yet reached TIMERMAX seconds
        {
            TimerCounter += Time.deltaTime; // update timer
        }
        else if (!TicketSpawned && (TimerCounter >= TimerMax) && TicketsCreated < TicketsNeeded) // if the timer has reached TIMERMAX and a ticket does not already exist
        {
            TimerCounter = 0; // reset timer
            switch (UnityEngine.Random.Range(1, 9)) // randomly pick 1-8, instantiate a ticket in one of 8 spots
            {
                case 1:
                    Instantiate(TicketPrefab, new Vector3(9, 3, 0), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(TicketPrefab, new Vector3(4, 3, 0), Quaternion.identity);
                    break;
                case 3:
                    Instantiate(TicketPrefab, new Vector3(-4, 3, 0), Quaternion.identity);
                    break;
                case 4:
                    Instantiate(TicketPrefab, new Vector3(-9, 3, 0), Quaternion.identity);
                    break;
                case 5:
                    Instantiate(TicketPrefab, new Vector3(-9, -3, 0), Quaternion.identity);
                    break;
                case 6:
                    Instantiate(TicketPrefab, new Vector3(-4, -3, 0), Quaternion.identity);
                    break;
                case 7:
                    Instantiate(TicketPrefab, new Vector3(4, -3, 0), Quaternion.identity);
                    break;
                case 8:
                    Instantiate(TicketPrefab, new Vector3(4, -3, 0), Quaternion.identity);
                    break;
            }
            TicketsCreated += 1;

            TicketSpawned = true; // the current ticket HAS spawned -- prevents infinite cloning
        }
        
        
    }

    void SpawnTicket()
    {
        switch (UnityEngine.Random.Range(1, 9)) // randomly pick 1-8, instantiate a ticket in one of 8 spots
        {
            case 1:
                Instantiate(TicketPrefab, new Vector3(9, 3, 0), Quaternion.identity);
                break;
            case 2:
                Instantiate(TicketPrefab, new Vector3(4, 3, 0), Quaternion.identity);
                break;
            case 3:
                Instantiate(TicketPrefab, new Vector3(-4, 3, 0), Quaternion.identity);
                break;
            case 4:
                Instantiate(TicketPrefab, new Vector3(-9, 3, 0), Quaternion.identity);
                break;
            case 5:
                Instantiate(TicketPrefab, new Vector3(-9, -3, 0), Quaternion.identity);
                break;
            case 6:
                Instantiate(TicketPrefab, new Vector3(-4, -3, 0), Quaternion.identity);
                break;
            case 7:
                Instantiate(TicketPrefab, new Vector3(4, -3, 0), Quaternion.identity);
                break;
            case 8:
                Instantiate(TicketPrefab, new Vector3(4, -3, 0), Quaternion.identity);
                break;
        }
    }
}
