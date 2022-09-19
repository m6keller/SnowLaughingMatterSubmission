using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Snowball3 : MonoBehaviour
{
    Rigidbody2D snowball;
    void Start( )
    {
        snowball = GetComponent<Rigidbody2D>( );
    }

   void Update( )
   {
       if( transform.position.y <= -3f )
       {
           transform.position = new Vector2( -0.7f, -4f );
           snowball.isKinematic = true;
           Debug.Log( "passed" );
           Invoke( "ChangeScene", 2 );
       }
   }
   void ChangeScene( )
   {
       SceneManager.LoadSceneAsync( "Tic-Tac-Toe" );
   }
}
