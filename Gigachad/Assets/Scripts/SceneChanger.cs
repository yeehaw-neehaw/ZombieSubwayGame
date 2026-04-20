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
