using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinovacBullet : BaseBullet 
{
    //private vars
    private Rigidbody2D rb;

    // Start is called before the first frame update
    public override void Start(){
        //setting the direction based on where the player is facing
        if(PlayerController.instance.FacingRight) {
            //facing right
            direction = 1;
        }
        if(!PlayerController.instance.FacingRight) {
            //facing left
            direction = -1;
        }

        //making the bullet face the correct direction
        transform.localScale = new Vector3(transform.localScale.x * -direction, transform.localScale.y);

        //getting the rigidbody and adding the propelling force
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(bulletSpeed * direction, 0), ForceMode2D.Impulse);

        //setting bullet attributes
        bulletDamage = 1;
        base.Start();
    }
}
