using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nose : MonoBehaviour
{
    void OnTriggerEnter2D( Collider2D collision )
    {
        this.gameObject.SetActive( false );
    }
}
