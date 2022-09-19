using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    public Text TextField;

    public void SetText( string text )
    {
        TextField.text = text;
    }

    public void WhenPressed()
    {
        SceneManager.LoadSceneAsync( "OptionsScene" );
    }
}
