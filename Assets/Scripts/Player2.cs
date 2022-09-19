using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField] private LayerMask platformsLayerMask;
    private new Rigidbody2D rigidbody;
    private float jumpVelocity = 9f;
    private float moveSpeed = 5f;
    public BoxCollider2D boxCollider;

    void Awake( )
    {
        // get component looks at objects on unity
        rigidbody = GetComponent<Rigidbody2D>( ); 
        boxCollider = transform.GetComponent<BoxCollider2D>( );
    }

    void Update( ) // Update is called every frame
    {
        // if up arrow
        if( IsGrounded( ) && Input.GetKeyDown( KeyCode.W ) ) rigidbody.velocity = Vector2.up * jumpVelocity;
        HandleMovement( );
    }

    bool IsGrounded( )
    {
        RaycastHit2D platformCheck = Physics2D.BoxCast( boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask );
        return platformCheck.collider != null ;
    }

    void HandleMovement( )
    {
        if( Input.GetKey( KeyCode.A ) ) rigidbody.velocity = new Vector2( -moveSpeed, rigidbody.velocity.y );
        else if( Input.GetKey( KeyCode.D ) ) rigidbody.velocity = new Vector2( +moveSpeed, rigidbody.velocity.y );
        else rigidbody.velocity = new Vector2( 0, rigidbody.velocity.y );
    }

}
