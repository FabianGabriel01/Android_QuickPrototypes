using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update


    public void OpenGame(int NumScene) 
    {
        SceneManager.LoadScene(NumScene);
    }

    public void CloseGame() 
    {
        Application.Quit();
    }
}
