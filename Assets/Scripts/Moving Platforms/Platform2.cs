using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform2 : MonoBehaviour
{
   [SerializeField] Transform platform;
   [SerializeField] Transform start;
   [SerializeField] Transform end;
   [SerializeField] GameObject button;
   Button2 buttonScript;

   public float moveSpeed = 3f;
   bool moveLeft = false;
   bool moveRight = false;

   void Start( )
   {
       buttonScript = button.GetComponent<Button2>();
   }

   void Update( )
   {
       if( buttonScript.pressed && platform.position.x < end.position.x ) moveRight = true;
       if( !buttonScript.pressed || platform.position.x > end.position.x ) moveRight = false;
       if( platform.position.x > start.position.x && !buttonScript.pressed ) moveLeft = true;
       if( platform.position.x < start.position.x || buttonScript.pressed ) moveLeft = false;

       if( moveLeft )
       {
           platform.position = new Vector2( platform.position.x - moveSpeed * Time.deltaTime, platform.position.y );
       }
       else if( moveRight )
       {
           platform.position = new Vector2( platform.position.x + moveSpeed * Time.deltaTime, platform.position.y );
       }
       
   }
}