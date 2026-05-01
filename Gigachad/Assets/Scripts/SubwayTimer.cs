/****************************************************************************
* File Name: SubwayTimer.c
* Author: Michael Chiodo
* DigiPen Email: michael.chiodo@digipen.edu
* Course: Game Projects
*
* Description: Controls the timer for getting on and off the subway.
*
****************************************************************************/

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubwayTimer : MonoBehaviour
{
    public TMP_Text visualCountdown;
    private float subwayCountdown = 50f;
    private int roundedCountdown = 50;

    // Update is called once per frame
    void Update()
    {
        if (subwayCountdown >= 0)
        {
            subwayCountdown -= Time.deltaTime;
            roundedCountdown = Mathf.RoundToInt(subwayCountdown);
            visualCountdown.text = "Y0U H4V3 " + roundedCountdown.ToString() + "s L3FT 1N TH3 SUBW4Y";
        }
        else
        {
            TicketSpawner.TicketsCreated = 0;
            TimerText.subwayDoorsOpen = false;
            TicketSpawner.TicketSpawned = false;
            EnemySpawning.NoMoreTickets = false;
            EnemyManager.validLevel = true;
            if (PlayerStats.CurrentLevel == 1)
            {
                AudioManager.Instance.Music[6].Stop();
                SceneManager.LoadScene("Level Designer Type Level 1");
                AudioManager.Instance.Music[0].Play();
            }
            else if (PlayerStats.CurrentLevel == 2)
            {
                AudioManager.Instance.Music[6].Stop();
                SceneManager.LoadScene("Level Designer Type Level 2");
                AudioManager.Instance.Music[1].Play();
            }
            else if (PlayerStats.CurrentLevel == 3)
            {
                AudioManager.Instance.Music[6].Stop();
                SceneManager.LoadScene("Level Designer Type Level 3");
                AudioManager.Instance.Music[2].Play();
            }
            else if (PlayerStats.CurrentLevel == 4)
            {
                AudioManager.Instance.Music[6].Stop();
                SceneManager.LoadScene("Level Designer Type Level 4");
                AudioManager.Instance.Music[3].Play();
            }
            else if (PlayerStats.CurrentLevel == 5)
            {
                AudioManager.Instance.Music[6].Stop();
                SceneManager.LoadScene("Level Designer Type Level 5");
                AudioManager.Instance.Music[4].Play();
            }
        }    
    }
}
