using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectiveText : MonoBehaviour
{
    public TMP_Text WrittenObjectives;

    // Start is called before the first frame update
    void Start()
    {
        WrittenObjectives = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        WrittenObjectives.text = "FIND " + (TicketSpawner.TicketsNeeded - TicketSpawner.TicketsCollected) + " TICK3TZ";
    }
}
