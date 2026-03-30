using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerText : MonoBehaviour
{
    public TMP_Text VisualCountdown;
    private float levelCountdown = 50f;
    private int roundedCountdown = 50;
    private float ticketCountdown = 30f;

    // Start is called before the first frame update
    void Start()
    {
        VisualCountdown = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (levelCountdown >= 0)
        {
            levelCountdown -= Time.deltaTime;
            roundedCountdown = Mathf.RoundToInt(levelCountdown);
            VisualCountdown.text = "W4RD TH3M 0FF FOR " + roundedCountdown.ToString();
        }
        else
        {
            ticketCountdown -= Time.deltaTime;
            roundedCountdown = Mathf.RoundToInt(ticketCountdown);
            VisualCountdown.color = Color.red;
            VisualCountdown.text = "F1ND THEM F4ST!! " + roundedCountdown.ToString();
        }
        
    }
}
