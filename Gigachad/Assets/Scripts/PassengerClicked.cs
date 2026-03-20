using UnityEngine;

public class PassengerClicked : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("You clicked on: " + gameObject.name);
    }
}
