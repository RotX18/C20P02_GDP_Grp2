using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinovacBullet : BaseBullet 
{
    //private vars
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() {
        //getting rigidbody2d component
        rb = GetComponent<Rigidbody2D>();

        //setting bullet attributes
        bulletSpeed = 5;
        bulletDamage = 1;
        bulletTime = 5;

        Destroy(gameObject, bulletTime);
    }

    private void FixedUpdate() {
        //making the bullet travel in a straight line
        rb.velocity = new Vector2(bulletSpeed, 0);
    }
}
