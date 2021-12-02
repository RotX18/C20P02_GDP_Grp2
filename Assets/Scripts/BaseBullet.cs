using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public abstract class BaseBullet : MonoBehaviour
{
    //public vars
    [HideInInspector] public int bulletDamage;
    [HideInInspector] public int direction = 1;
    [HideInInspector] public float bulletSpeed = 5;

    //private vars
    private int bulletTime = 3;

    public virtual void Start() {
        Destroy(gameObject, bulletTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Enemy")) {
            //subtracting Enemy health
            collision.gameObject.GetComponent<Enemy>().Health -= bulletDamage;

            if(collision.gameObject.GetComponent<Enemy>().Health <= 0){
                //killing (destroying) enemy object if its health <= 0
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }
    }
}