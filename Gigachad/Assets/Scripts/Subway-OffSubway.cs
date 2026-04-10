/****************************************************************************
* File Name: Subway-OffSubway.c
* Author: Michael Chiodo
* DigiPen Email: michael.chiodo@digipen.edu
* Course: Game Projects
*
* Description: If certain game objects are clicked, load certain scenes, as well
* as deleting passengers if the player did not collect all of the tickets.
* 
****************************************************************************/

using UnityEngine;
using UnityEngine.SceneManagement;

public class SubwayOffSubway : MonoBehaviour
{
    public GameObject winText;
    public GameObject[] gameObjects;
    public static bool hasDeleted = false;
    private int passengerDecrementer = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.name == "ToSubway" && TimerText.subwayDoorsOpen && collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("On Subway");
            PlayerStats.CurrentLevel += 1;
            TimerText.subwayDoorsOpen = false;
        }
    }

    void OnMouseDown()
    {
        if (gameObject.name == "ToStation1" && !PassengerClicked.clicked)
        {
            winText.gameObject.SetActive(false);
            TimerText.subwayDoorsOpen = false;
            TicketSpawner.TicketSpawned = false;
            EnemySpawning.NoMoreTickets = false;
            if (PlayerStats.CurrentLevel == 1)
            {
                SceneManager.LoadScene("Level Designer Type Level 1");
            }
            else if (PlayerStats.CurrentLevel == 2)
            {
                SceneManager.LoadScene("Level Designer Type Level 2");
            }
            else if (PlayerStats.CurrentLevel == 3)
            {
                SceneManager.LoadScene("Level Designer Type Level 3");
            }
            else if (PlayerStats.CurrentLevel == 4)
            {
                SceneManager.LoadScene("Level Designer Type Level 4");
            }
            else if (PlayerStats.CurrentLevel == 5)
            {
                SceneManager.LoadScene("Level Designer Type Level 5");
            }
        }
    }
    void Update()
    {
        if (gameObject.name == "ToStation1" && !hasDeleted && PlayerStats.CurrentLevel > 1)
        {
            if (PlayerStats.PassengerCount < 5)
            {
                Debug.Log("Passenger count is " + PlayerStats.PassengerCount);
                int amountOfPassengersToDelete = 5 - PlayerStats.PassengerCount;
                for (int j = 0; j < amountOfPassengersToDelete; j++) 
                {
                    Debug.Log("Passenger has been redeleted");
                    Destroy(gameObjects[j]);
                }
            }
            if ((PlayerStats.TicketsCollected - 1) < PlayerStats.PassengerCount)
            {
                for (int i = 0; i < 5 - (PlayerStats.TicketsCollected - 1); i++)
                {
                    Debug.Log("Passenger" + (i));
                    Destroy(gameObjects[i]);
                    passengerDecrementer++;
                }
                PlayerStats.PassengerCount -= passengerDecrementer;
                Debug.Log("Passenger Count: " + PlayerStats.PassengerCount);
                hasDeleted = true;
            }
        }
    }
}
