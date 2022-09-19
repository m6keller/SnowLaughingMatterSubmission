using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball1 : MonoBehaviour
{
    Rigidbody2D snowball;
    void Start( )

    {
        snowball = GetComponent<Rigidbody2D>( );
    }

   void Update( )
   {
       if( transform.position.x <= -0.7f )
       {
           transform.position = new Vector2( -0.7f, transform.position.y );
           snowball.isKinematic = true;
           Debug.Log( "passed" );
       }
   }
}
