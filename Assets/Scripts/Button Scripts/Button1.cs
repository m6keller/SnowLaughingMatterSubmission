using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1 : MonoBehaviour
{
    public bool pressed = false;
    
    void OnTriggerEnter2D( Collider2D player )
    {
        pressed = true;
        Debug.Log( "hit" );
    }
    void OnTriggerExit2D( Collider2D player )
    {
        pressed = false;
        Debug.Log( "left" );
    }
    /*void Update( )
    {
        if( !OnCollision( ) )
            pressed = false;
    }*/
}
