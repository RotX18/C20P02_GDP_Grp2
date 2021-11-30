using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PfizerBullet : BaseBullet
{
    //private vars
    private ConstantForce2D cf;

    // Start is called before the first frame update
    void Start(){
        cf = GetComponent<ConstantForce2D>();
        cf.force = new Vector2(bulletSpeed * direction, 0);

        //setting bulletDamage attribute
        bulletDamage = 3;
    }
}
