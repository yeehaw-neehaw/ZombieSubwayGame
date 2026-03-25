using UnityEngine;

public class PassengerClicked : MonoBehaviour
{
    public GameObject Upgrade1, Text1, Background1;
    private bool clicked1 = false;
    void Start()
    {
        Upgrade1.gameObject.SetActive(false);
        Text1.gameObject.SetActive(false);
        Background1.gameObject.SetActive(false);
    }
    private void OnMouseDown()
    {
        if (gameObject.name == "Passenger1" && !clicked1)
        {
            Upgrade1.gameObject.SetActive(true);
            Text1.gameObject.SetActive(true);
            Background1.gameObject.SetActive(true);
            clicked1 = true;
        }
        else if (gameObject.name == "Passenger1" && clicked1)
        {
            Upgrade1.gameObject.SetActive(false);
            Text1.gameObject.SetActive(false);
            Background1.gameObject.SetActive(false);
            clicked1 = false;
        }
        Debug.Log("You clicked on: " + gameObject.name);
    }
}
