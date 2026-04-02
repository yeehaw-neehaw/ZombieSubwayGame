/****************************************************************************
* File Name: EnemySpawning.c
* Author: Michael Chiodo
* DigiPen Email: michael.chiodo@digipen.edu
* Course: Game Projects
*
* Description: Spawns enemies at a set y coordinate, with a random x coordinate.
* Must be adjusted when we have the actual y coordinate for the barricades.
* 
* Also manages the timer to stop the spawn of tickets.
****************************************************************************/

using System.Net.Sockets;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public float timer = 1f;
    private float countdown = 1f;
    private int spawnX;
    private float spawnY;
    public GameObject enemyPrefab;
    public float levelTimer = 50f;
    public float levelCountdown = 0f;
    private float TicketTimerMax = 30f; // TIMERMAX seconds elapse before a ticket will spawn
    private float TicketTimerCounter = 0f; // the actual timer for TicketTimerMax
    public static bool NoMoreTickets = false; // tickets cant spawn (all collected OR level ended)

    // Update is called once per frame
    void Update()
    {
        levelCountdown += Time.deltaTime;
        spawnX = Random.Range(-10, 10);
        spawnY = Random.Range(-5, 9);
        if (countdown >= timer && levelCountdown < levelTimer)
        {
            //Instantiates a new enemy at a set y coordinate
            GameObject enemy = Instantiate(enemyPrefab, new Vector3(spawnX, spawnY, 0), Quaternion.Euler(0, 0, 0));
            countdown = 0f;
        }
        else if (countdown < timer)
        {
            countdown += Time.deltaTime;
        }

        if (levelCountdown >= levelTimer) // if the level timer ends (enemies stop spawning)
        {
            if (TicketTimerCounter < TicketTimerMax)
            {
                TicketTimerCounter += Time.deltaTime; // ticket despawn timer will start running if not at its limit
            }
            else
            {
                NoMoreTickets = true;
            }
        }
    }
}
