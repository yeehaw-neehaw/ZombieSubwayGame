using System;
using UnityEngine;

public class TicketSpawner : MonoBehaviour
{
    public GameObject TicketPrefab;
    bool TicketSpawned = false;
    public float TimerMax = 5f;
    private float TimerCounter = 0f;

    // Update is called once per frame
    void Update()
    {
        if (TimerCounter < TimerMax)
        {
            TimerCounter += Time.deltaTime;
        }
        else if (!TicketSpawned && (TimerCounter >= TimerMax))
        {
            switch (UnityEngine.Random.Range(1, 9))
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
            TicketSpawned = true;
        }
        
        
    }
}
