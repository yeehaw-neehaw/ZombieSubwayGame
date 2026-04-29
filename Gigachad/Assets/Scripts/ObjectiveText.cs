// Updates the part of the objectives bar that says how many tickets are left.

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
        WrittenObjectives.text = "- f1nd " + (PlayerStats.TicketsNeeded - PlayerStats.TicketsCollected) + " t1ck3ts!!!";
    }
}
