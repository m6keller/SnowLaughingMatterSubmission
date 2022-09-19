using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayCutscene(){
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

    public void LoadScene( )
    {
        SceneManager.LoadScene( "Level 1" );
    }

   public void QuitGame(){
       Debug.Log("QUIT!");
       Application.Quit();
   }
}
