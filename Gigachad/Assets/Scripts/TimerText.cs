/****************************************************************************
* File Name: TimerText.cs
* Author: Neha Sankarkumar
* DigiPen Email: neha.sankarkumar@digipen.edu
* Course: Game Projects
*
* Description: Manages the text in the UI which displays level timers.
*
****************************************************************************/
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerText : MonoBehaviour
{
    public TMP_Text visualCountdown; // the text
    private float levelCountdown = 50f; // time until zombies stop spawning
    private float ticketCountdown = 30f; // time until tickets stop spawning
    private int roundedCountdown = 50; // rounded (int) version of countdowns
    public static bool subwayDoorsOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        visualCountdown = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (levelCountdown >= 0) // if level's yet to end (zombies still spawning)
        {
            levelCountdown -= Time.deltaTime; // decrease timer
            roundedCountdown = Mathf.RoundToInt(levelCountdown); // round timer
            visualCountdown.text = "W4RD TH3M 0FF FOR " + roundedCountdown.ToString(); // display rounded value
        }
        else // if level ends (zombies STOP spawning)
        {
            if (PlayerStats.TicketsCollected < PlayerStats.TicketsNeeded) // if the player still needs tickets
            {
                ticketCountdown -= Time.deltaTime; //  decrease TICKET timer countdown
                roundedCountdown = Mathf.RoundToInt(ticketCountdown); // round countdown
                visualCountdown.color = Color.red; // the text is now RED!! URGENCY
                visualCountdown.text = "F1ND THEM F4ST!! " + roundedCountdown.ToString(); // show ticket countdown
                if (ticketCountdown <= 0) // if the ticket countdown is over (not all tix collected)
                {
                    visualCountdown.color = Color.white;
                    visualCountdown.text = "GET 0N TH3 TR41N!!!"; // stop displaying countdown---guiding msg instead
                    subwayDoorsOpen = true;
                }
            }
            else // if player has all tickets needed
            {
                visualCountdown.color = Color.green;
                visualCountdown.text = "GET 0N TH3 TR41N!!!"; // stop displaying countdown---guiding msg instead
                subwayDoorsOpen = true;
            }
            
        }
        
    }
}
