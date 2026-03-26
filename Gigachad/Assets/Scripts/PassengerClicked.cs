using UnityEngine;
using UnityEngine.UI;

public class PassengerClicked : MonoBehaviour
{
    public GameObject Text1, Background1;
    public Button Upgrader, xOut;
    private static bool clicked = false;
    void Start()
    {
        Upgrader.gameObject.SetActive(false);
        Text1.gameObject.SetActive(false);
        Background1.gameObject.SetActive(false);
        xOut.gameObject.SetActive(false);
        Upgrader.onClick.AddListener(OnButtonClick);
        xOut.onClick.AddListener(OnXClick);
    }
    private void OnMouseDown()
    {
        if (gameObject.name == "Passenger1" && !clicked)
        {
            Upgrader.gameObject.SetActive(true);
            Text1.gameObject.SetActive(true);
            Background1.gameObject.SetActive(true);
            xOut.gameObject.SetActive(true);
            clicked = true;
        }
        if (gameObject.name == "Passenger2" && !clicked)
        {
            Upgrader.gameObject.SetActive(true);
            Text1.gameObject.SetActive(true);
            Background1.gameObject.SetActive(true);
            xOut.gameObject.SetActive(true);
            clicked = true;
        }
        if (gameObject.name == "Passenger3" && !clicked)
        {
            Upgrader.gameObject.SetActive(true);
            Text1.gameObject.SetActive(true);
            Background1.gameObject.SetActive(true);
            xOut.gameObject.SetActive(true);
            clicked = true;
        }
        if (gameObject.name == "Passenger4" && !clicked)
        {
            Upgrader.gameObject.SetActive(true);
            Text1.gameObject.SetActive(true);
            Background1.gameObject.SetActive(true);
            xOut.gameObject.SetActive(true);
            clicked = true;
        }
        if (gameObject.name == "Passenger5" && !clicked)
        {
            Upgrader.gameObject.SetActive(true);
            Text1.gameObject.SetActive(true);
            Background1.gameObject.SetActive(true);
            xOut.gameObject.SetActive(true);
            clicked = true;
        }
        if (gameObject.name == "Passenger6" && !clicked)
        {
            Upgrader.gameObject.SetActive(true);
            Text1.gameObject.SetActive(true);
            Background1.gameObject.SetActive(true);
            xOut.gameObject.SetActive(true);
            clicked = true;
        }
        if (gameObject.name == "Passenger7" && !clicked)
        {
            Upgrader.gameObject.SetActive(true);
            Text1.gameObject.SetActive(true);
            Background1.gameObject.SetActive(true);
            xOut.gameObject.SetActive(true);
            clicked = true;
        }
    }
    void OnButtonClick()
    {
        /*if (gameObject.name == "Passenger whatever")"
        {
            increment/decrement one of the upgrade variables
        }*/
        if (gameObject.name == "Passenger1")
        {
            Debug.Log("You just upgraded your passenger 1 power!");
        }
    }
    void OnXClick()
    {
        Upgrader.gameObject.SetActive(false);
        Text1.gameObject.SetActive(false);
        Background1.gameObject.SetActive(false);
        xOut.gameObject.SetActive(false);
        clicked = false;
    }
}
