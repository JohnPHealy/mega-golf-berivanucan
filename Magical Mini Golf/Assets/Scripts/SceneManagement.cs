using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
   public void playGame() 
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void QuitGame () 
    {
        Application.Quit();
        Debug.Log("QUIT");
    }

    public void playAgain() 
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -5);
    }
}
