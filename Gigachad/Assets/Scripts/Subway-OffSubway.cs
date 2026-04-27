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
    //private int passengerDecrementer = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.name == "ToSubway" && TimerText.subwayDoorsOpen && collision.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < 5; i++)
            {
                if (PlayerStats.CurrentLevel - 1 == i)
                {
                    AudioManager.Instance.Music[i].Stop();
                }
            }
            AudioManager.Instance.Music[0].Stop();
            if (PlayerStats.CurrentLevel == 5)
            {
                SceneManager.LoadScene("WinScreen");
            }
            else
            {
                SceneManager.LoadScene("On Subway");
                PlayerStats.CurrentLevel += 1;
                TimerText.subwayDoorsOpen = false;
                AudioManager.Instance.Music[6].Play();
            }
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
                AudioManager.Instance.Music[6].Stop();
                SceneManager.LoadScene("Level Designer Type Level 1");
                AudioManager.Instance.Music[0].Play();
            }
            else if (PlayerStats.CurrentLevel == 2)
            {
                AudioManager.Instance.Music[6].Stop();
                SceneManager.LoadScene("Level Designer Type Level 2");
                AudioManager.Instance.Music[1].Play();
            }
            else if (PlayerStats.CurrentLevel == 3)
            {
                AudioManager.Instance.Music[6].Stop();
                SceneManager.LoadScene("Level Designer Type Level 3");
                AudioManager.Instance.Music[2].Play();
            }
            else if (PlayerStats.CurrentLevel == 4)
            {
                AudioManager.Instance.Music[6].Stop();
                SceneManager.LoadScene("Level Designer Type Level 4");
                AudioManager.Instance.Music[3].Play();
            }
            else if (PlayerStats.CurrentLevel == 5)
            {
                AudioManager.Instance.Music[6].Stop();
                SceneManager.LoadScene("Level Designer Type Level 5");
                AudioManager.Instance.Music[4].Play();
            }
        }
    }
    void Update()
    {
        /*
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
        */
        if (gameObject.name == "ToStation1" && !hasDeleted && PlayerStats.CurrentLevel > 1)
        {
            PlayerStats.PassengerCount = PlayerStats.TicketsCollected - 1;
            Debug.Log("Passenger count is " + PlayerStats.PassengerCount);
            for (int j = 0; j < 5 - PlayerStats.PassengerCount; j++)
            {
                Destroy(gameObjects[j]);
            }
            hasDeleted = true;
        }
    }
}
