/****************************************************************************
* File Name: SceneChanger
* Author: Neha Sankarkumar
* DigiPen Email: neha.sankarkumar@digipen.edu
* Course: Video Game Programming (Game Projects)
*
* Description: This code switches scenes upon a button being clicked. 
****************************************************************************/

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(string sceneName) // applies to the start button in the intro menu
    {
        AudioManager.Instance.SFX[13].Play();
        SceneManager.LoadScene(sceneName);
        if (sceneName == "Intro Screen")
        {
            PlayerStats.BulletDamage = 2;
            PlayerStats.PlayerCash = 0;
            PlayerStats.ReloadSpeed = 2.5f;
            PlayerStats.PlayerMovementSpeed = 5f;
            PlayerStats.ShootingSpeed = 0.3f;
            PlayerStats.RicochetLevel = 0;
            PlayerStats.TicketsCollected = 0;
            PlayerStats.TicketsNeeded = 6;
            PlayerStats.PassengerCount = 5;
            PlayerStats.CurrentLevel = 0;
        }
    }
    public void TryAgainChanger(string sceneName)
    {
        AudioManager.Instance.SFX[13].Play();
        SceneManager.LoadScene(sceneName + PlayerStats.CurrentLevel);
    }
    public void GameExit()
    {
        AudioManager.Instance.SFX[13].Play();
        Application.Quit();
    }
}
