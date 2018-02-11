using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width - 20 - 100, Screen.height - 20 - 50, 100, 50), "Menu"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Game scene 3 - Selection Menu");
        }
    }
}