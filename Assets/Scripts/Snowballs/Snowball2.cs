using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball2 : MonoBehaviour
{
    Rigidbody2D snowball;
    void Start( )
    {
        snowball = GetComponent<Rigidbody2D>( );
    }

   void Update( )
   {
       if( transform.position.y <= -4f )
       {
           transform.position = new Vector2( -0.7f, -6f );
           snowball.isKinematic = true;
           Debug.Log( "passed" );
       }
   }
}
