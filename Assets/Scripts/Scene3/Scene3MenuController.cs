using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3MenuController : MonoBehaviour
{
    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 100 - 25, Screen.height / 2 - 25, 100, 50), "Roll-A-Ball"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Game scene 1 - Roll-a-ball");
        }
        if (GUI.Button(new Rect(Screen.width / 2 + 25, Screen.height / 2 - 25, 100, 50), "Space Shooter"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Game scene 2 - Your own game");
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 50, 100, 50), "Exit"))
        {
            Application.Quit();
        }
    }
}