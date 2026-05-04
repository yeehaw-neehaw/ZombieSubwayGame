/****************************************************************************
* File Name: CashDisplay.cs
* Author: Neha Sankarkumar
* DigiPen Email: neha.sankarkumar@digipen.edu
* Course: Game Projects
*
* Description: Updates the text elements that display the amount of cash the
* player currently has.
****************************************************************************/
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CashDisplay : MonoBehaviour
{
    public TMP_Text CashUI; // the textbox

    // Start is called before the first frame update
    void Start()
    {
        CashUI = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        CashUI.text = "$" + PlayerStats.PlayerCash;
    }
}
