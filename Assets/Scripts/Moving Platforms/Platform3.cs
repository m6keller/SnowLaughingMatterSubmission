using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform3 : MonoBehaviour
{
   [SerializeField] Transform platform;
   [SerializeField] Transform start;
   [SerializeField] Transform end;
   [SerializeField] GameObject button;
   Button1 buttonScript;

   public float moveSpeed = 3f;
   bool moveUp = false;
   bool moveDown = false;

   void Start( )
   {
       buttonScript = button.GetComponent<Button1>();
   }

   void Update( )
   {

       if( buttonScript.pressed && platform.position.y > end.position.y ) moveDown = true;
       if( !buttonScript.pressed || platform.position.y < end.position.y ) moveDown = false;
       if( platform.position.y < start.position.y && !buttonScript.pressed ) moveUp = true;
       if( platform.position.y > start.position.y || buttonScript.pressed ) moveUp = false;

       if( moveUp )
       {
           platform.position = new Vector2( platform.position.x, platform.position.y + moveSpeed * Time.deltaTime );
       }
       else if( moveDown )
       {
           platform.position = new Vector2( platform.position.x, platform.position.y - moveSpeed * Time.deltaTime );
       }
       
   }
}