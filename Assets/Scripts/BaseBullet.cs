using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public abstract class BaseBullet : MonoBehaviour
{
    //vars
    [HideInInspector] public float bulletSpeed;
    [HideInInspector] public int bulletDamage;
    [HideInInspector] public int bulletTime;

    public virtual void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Enemy")){

            //SUBTRACT HEALTH FROM THE ENEMY HERE
            //EDIT SO THAT THE ACTUAL CODE HAS AN IF TO CHECK ENEMY HP BEFORE DESTROYING
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}