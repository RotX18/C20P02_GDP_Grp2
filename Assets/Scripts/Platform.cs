using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player")) {
            PlayerController.instance.Grounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player")){
            PlayerController.instance.Grounded = false;
        }
    }
}
