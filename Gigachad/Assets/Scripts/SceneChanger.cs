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
    public void StartGame(string sceneName) // applies to the start button in the intro menu
    {
        SceneManager.LoadScene(sceneName);
    }
}
