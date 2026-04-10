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
    private float timer = 2.2f;
    private float countdown = 0f;
    private int spawnX;
    private float spawnY;
    public GameObject enemyPrefab;
    public float levelTimer = 50f;
    public float levelCountdown = 0f;
    private float TicketTimerMax = 30f; // TIMERMAX seconds elapse before a ticket will spawn
    private float TicketTimerCounter = 0f; // the actual timer for TicketTimerMax
    public static bool NoMoreTickets = false; // tickets cant spawn (all collected OR level ended)
    public static int EnemiesAlive;

    void Start()
    {
        EnemiesAlive = 0;
        NoMoreTickets = false;
    }
    // Update is called once per frame
    void Update()
    {
        levelCountdown += Time.deltaTime;
        if (Random.Range(1, 3) == 1 && PlayerStats.CurrentLevel != 5)
        {
            spawnX = Random.Range(-16, 17);
            spawnY = -5;
        }
        else
        {
            spawnY = Random.Range(-4, 9);
            if (Random.Range(1, 3) == 2)
            {
                spawnX = -16;
                
            }
            else
            {
                spawnX = 16;
            }
            
        }
        
        if (countdown >= timer && levelCountdown < levelTimer && EnemiesAlive <= 15)
        {
            //Instantiates a new enemy at a set y coordinate
            GameObject enemy = Instantiate(enemyPrefab, new Vector3(spawnX, spawnY, 0), Quaternion.Euler(0, 0, 0));
            countdown = 0f;
            EnemiesAlive++;
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
