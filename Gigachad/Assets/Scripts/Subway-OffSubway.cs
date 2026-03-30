using UnityEngine;
using UnityEngine.SceneManagement;

public class SubwayOffSubway : MonoBehaviour
{
    public GameObject winText;
    public GameObject[] gameObjects;
    public bool hasDeleted = false;
    private int passengerDecrementer = 0;
    void OnMouseDown()
    {
        if (gameObject.name == "ToSubway")
        {
            SceneManager.LoadScene("On Subway");
        }
        if (gameObject.name == "ToStation" && !PassengerClicked.clicked)
        {
            winText.gameObject.SetActive(false);
            SceneManager.LoadScene("Level Designer Type Level 1");
            hasDeleted = false;
        }
    }
    void Update()
    {
        if (gameObject.name == "ToStation" && !hasDeleted)
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
