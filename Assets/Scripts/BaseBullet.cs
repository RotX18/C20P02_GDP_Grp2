using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public abstract class BaseBullet : MonoBehaviour
{
    //public vars
    [HideInInspector] public int bulletDamage;
    [HideInInspector] public int direction = 1;
    [HideInInspector] public float bulletSpeed = 3;

    //private vars
    private int bulletTime = 3;

    private void Start() {
        //setting the constantforce based on where the player is facing
        if(PlayerController.instance.FacingRight) {
            //facing right
            direction = 1;
        }
        if(!PlayerController.instance.FacingRight) {
            //facing left
            direction = -1;
        }
        Destroy(gameObject, bulletTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Enemy")) {

            //SUBTRACT HEALTH FROM THE ENEMY HERE
            //EDIT SO THAT THE ACTUAL CODE HAS AN IF TO CHECK ENEMY HP BEFORE DESTROYING
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}