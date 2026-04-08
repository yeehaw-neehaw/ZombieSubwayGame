/****************************************************************************
* File Name: TimerText.cs
* Author: Neha Sankarkumar
* DigiPen Email: neha.sankarkumar@digipen.edu
* Course: Game Projects
*
* Description: Manages the text in the UI which displays level timers.
* A certain amount of time elapses until zombies stop spawning, and then
* a seperate amount of time elapses until tickets stop spawning.
*
****************************************************************************/
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerText : MonoBehaviour
{
    public TMP_Text visualCountdown; // the textbox
    private float levelCountdown = 50f; // time until zombies stop spawning
    private float ticketCountdown = 30f; // time until tickets stop spawning
    private int roundedCountdown = 50; // rounded (int) version of countdowns
    public static bool subwayDoorsOpen = false; // whether or not player can enter train

    // Start is called before the first frame update
    void Start()
    {
        visualCountdown = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (levelCountdown >= 0) // if level timer is yet to end (zombies should still be spawning)
        {
            levelCountdown -= Time.deltaTime; // decrease zombie timer
            roundedCountdown = Mathf.RoundToInt(levelCountdown); // round that timer
            visualCountdown.text = "W4RD TH3M 0FF FOR " + roundedCountdown.ToString(); // VISUALLY display the rounded value
        }
        else // if level ends (zombies STOP spawning)
        {
            if (PlayerStats.TicketsCollected < PlayerStats.TicketsNeeded) // if the player still needs tickets
            {
                ticketCountdown -= Time.deltaTime; //  decrease ticket timer
                roundedCountdown = Mathf.RoundToInt(ticketCountdown); // round that countdown
                visualCountdown.color = Color.red; // the text is now RED!! URGENCY RAGHHHHH
                visualCountdown.text = "F1ND THEM F4ST!! " + roundedCountdown.ToString(); // VISUALLY display the rounded value
                if (ticketCountdown <= 0) // if the ticket countdown is over (not all tix collected)
                {
                    visualCountdown.color = Color.white;
                    visualCountdown.text = "GET 0N TH3 TR41N!!!"; // stop displaying countdown
                    subwayDoorsOpen = true; // player can enter train
                }
            }
            else // if player has all tickets needed
            {
                visualCountdown.color = Color.green; 
                visualCountdown.text = "GET 0N TH3 TR41N!!!"; // stop displaying countdown
                subwayDoorsOpen = true; // player can enter train
            }
            
        }
        
    }
}
