using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string StartScene;

    public void LoadStart() {
        SceneManager.LoadScene(StartScene);
    }

    public void IsExit() {
        print("종료!");
        Application.Quit();
    }
    
}
