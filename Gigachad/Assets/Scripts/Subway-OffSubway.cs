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
    public bool hasDeleted = false;
    private int passengerDecrementer = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.name == "ToSubway" && TimerText.subwayDoorsOpen)
        {
            SceneManager.LoadScene("On Subway");
            TimerText.subwayDoorsOpen = false;
            PlayerStats.CurrentLevel += 1;
        }
    }

    void OnMouseDown()
    {
        if (gameObject.name == "ToStation1" && !PassengerClicked.clicked)
        {
            winText.gameObject.SetActive(false);
            if (PlayerStats.CurrentLevel == 2)
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
            hasDeleted = false;
        }
    }
    void Update()
    {
        if (gameObject.name == "ToStation1" && !hasDeleted)
        {
            if (PlayerStats.TicketsCollected < PlayerStats.PassengerCount)
            {
                for (int i = 0; i < PlayerStats.PassengerCount - PlayerStats.TicketsCollected; i++)
                {
                    Debug.Log("Passenger" + (i));
                    Debug.Log("Passenger Count: " + PlayerStats.PassengerCount);
                    Destroy(gameObjects[i]);
                    passengerDecrementer++;
                }
                PlayerStats.PassengerCount -= passengerDecrementer;
                hasDeleted = true;
            }
        }
    }
}
