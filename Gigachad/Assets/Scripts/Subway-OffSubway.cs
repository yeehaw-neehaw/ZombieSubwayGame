using UnityEngine;
using UnityEngine.SceneManagement;

public class SubwayOffSubway : MonoBehaviour
{

    void OnMouseDown()
    {
        if (gameObject.name == "ToSubway")
        {
            SceneManager.LoadScene("On Subway");
        }
        if (gameObject.name == "ToStation")
        {
            SceneManager.LoadScene("Level Designer Type Level 1");
        }
    }
}
