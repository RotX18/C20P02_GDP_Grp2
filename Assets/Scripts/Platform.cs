using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    //NOT WORKING FOR NOW, NEED FIX
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Player"){
            PlayerController.instance.Grounded = true;
            Debug.Log("player grounded");
        }
    }
}
