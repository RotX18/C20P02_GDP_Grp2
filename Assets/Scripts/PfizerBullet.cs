using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PfizerBullet : BaseBullet
{
    //private vars
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start(){
        //setting the direction based on where the player is facing
        if(PlayerController.instance.FacingRight) {
            //facing right
            direction = 1;
        }
        if(!PlayerController.instance.FacingRight) {
            //facing left
            direction = -1;
        }

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(bulletSpeed * direction, 0), ForceMode2D.Impulse);

        //setting bulletDamage attribute
        bulletDamage = 3;
    }
}
