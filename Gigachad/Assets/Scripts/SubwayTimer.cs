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
            SceneManager.LoadScene("Level Designer Type Level 2");
        }    
    }
}
