using UnityEngine;
using UnityEngine.SceneManagement;

public class SubwayOffSubway : MonoBehaviour
{
    public GameObject winText;
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
        }
    }
}
