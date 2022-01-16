using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using unityEngine.UI;


public class MainMenu : MonoBehaviour
{
    
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /*public void NewGame() {
        dbManagement.createNewSave();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void loadGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }*/
}
