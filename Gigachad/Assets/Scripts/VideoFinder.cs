using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoFinder : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public VideoPlayer videoPlayer;
    Scene currentScene;
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Intro Screen")
        {
            videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "Gigachad_Title_Animation_Final.mp4");
        }
        else if (currentScene.name == "Game Over")
        {
            videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "Death Scene.mp4");
        }
        else if (currentScene.name == "On Subway")
        {
            videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "Gigachad_Subway_Interior_Placeholder_Animated.mp4");
        }
    }
}
