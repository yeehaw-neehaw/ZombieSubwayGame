/****************************************************************************
* File Name: SceneChanger
* Author: Neha Sankarkumar, Mikey Chiodo
* DigiPen Email: neha.sankarkumar@digipen.edu
* Course: Video Game Programming (Game Projects)
*
* Description: This code switches scenes upon a button being clicked. 
****************************************************************************/

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{   
    // applies to the start button in the intro menu
    public void ChangeScene(string sceneName) 
    {
        AudioManager.Instance.SFX[13].Play();
        SceneManager.LoadScene(sceneName);
        if (sceneName == "Intro Screen") // resets all stats if game is reset to main menu
        {
            EnemyManager.validLevel = false;
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

    // if the player dies and restarts level
    public void TryAgainChanger(string sceneName)
    {
        AudioManager.Instance.SFX[13].Play();
        SceneManager.LoadScene(sceneName + PlayerStats.CurrentLevel);
        EnemyManager.validLevel = true;
    }
    
    // game is closed
    public void GameExit()
    {
        AudioManager.Instance.SFX[13].Play();
        Application.Quit();
    }
}
