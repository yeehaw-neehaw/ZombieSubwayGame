/****************************************************************************
* File Name: PassengerClicked.c
* Author: Michael Chiodo
* DigiPen Email: michael.chiodo@digipen.edu
* Course: Game Projects
*
* Description: Handles any clicking interaction with the passengers, that being
* turning on and off the UI elements as well as incrementing/decrementing stat
* variables
* 
****************************************************************************/

using UnityEngine;
using UnityEngine.UI;

public class PassengerClicked : MonoBehaviour
{
    public GameObject Text1, Background1, Broke1;
    public Button Upgrader, xOut;
    public static bool clicked = false;
    void Start()
    {
        //Turning off all UI elements
        Upgrader.gameObject.SetActive(false);
        Text1.gameObject.SetActive(false);
        Background1.gameObject.SetActive(false);
        xOut.gameObject.SetActive(false);
        Broke1.gameObject.SetActive(false);
        //Adding function calls when the buttons are clicked
        Upgrader.onClick.AddListener(OnButtonClick);
        xOut.onClick.AddListener(OnXClick);
    }
    private void OnMouseDown()
    {
        //Checks for each different passenger in the case they are clicked
        if (gameObject.name == "Passenger1" && !clicked)
        {
            Upgrader.gameObject.SetActive(true);
            Text1.gameObject.SetActive(true);
            Background1.gameObject.SetActive(true);
            xOut.gameObject.SetActive(true);
            clicked = true;
        }
        if (gameObject.name == "Passenger2" && !clicked)
        {
            Upgrader.gameObject.SetActive(true);
            Text1.gameObject.SetActive(true);
            Background1.gameObject.SetActive(true);
            xOut.gameObject.SetActive(true);
            clicked = true;
        }
        if (gameObject.name == "Passenger3" && !clicked)
        {
            Upgrader.gameObject.SetActive(true);
            Text1.gameObject.SetActive(true);
            Background1.gameObject.SetActive(true);
            xOut.gameObject.SetActive(true);
            clicked = true;
        }
        if (gameObject.name == "Passenger4" && !clicked)
        {
            Upgrader.gameObject.SetActive(true);
            Text1.gameObject.SetActive(true);
            Background1.gameObject.SetActive(true);
            xOut.gameObject.SetActive(true);
            clicked = true;
        }
        if (gameObject.name == "Passenger5" && !clicked)
        {
            Upgrader.gameObject.SetActive(true);
            Text1.gameObject.SetActive(true);
            Background1.gameObject.SetActive(true);
            xOut.gameObject.SetActive(true);
            clicked = true;
        }
    }
    void OnButtonClick()
    {
        /*if (gameObject.name == "Passenger whatever")"
        {
            increment/decrement one of the upgrade variables
        }*/
        Debug.Log("You currently have money: " + PlayerStats.PlayerCash);
        if (PlayerStats.PlayerCash < 5)
        {
            Broke1.gameObject.SetActive(true);
        }
        if (gameObject.name == "Passenger1" && PlayerStats.PlayerCash > 5)
        {
            PlayerStats.BulletDamage += 1;
            PlayerStats.PlayerCash -= 5;
            Debug.Log("Current Damage: " + PlayerStats.BulletDamage);
        }
        if (gameObject.name == "Passenger2" && PlayerStats.PlayerCash > 5)
        {
            PlayerStats.ReloadSpeed -= 1;
            PlayerStats.PlayerCash -= 5;
        }
        if (gameObject.name == "Passenger3" && PlayerStats.PlayerCash > 5)
        {
            PlayerStats.PlayerMovementSpeed += 1;
            PlayerStats.PlayerCash -= 5;
        }
        if (gameObject.name == "Passenger4" && PlayerStats.PlayerCash > 5)
        {
            PlayerStats.ShootingSpeed += 1;
            PlayerStats.PlayerCash -= 5;
        }
        if (gameObject.name == "Passenger4" && PlayerStats.PlayerCash > 5)
        {
            PlayerStats.RicochetLevel += 1;
            PlayerStats.PlayerCash -= 5;
        }
    }
    void OnXClick()
    {
        //Closes the UI if the X button is pressed
        Upgrader.gameObject.SetActive(false);
        Text1.gameObject.SetActive(false);
        Background1.gameObject.SetActive(false);
        xOut.gameObject.SetActive(false);
        Broke1.gameObject.SetActive(false);
        clicked = false;
    }
}
