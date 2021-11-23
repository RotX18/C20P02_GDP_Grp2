using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public abstract class BaseBullet : MonoBehaviour
{
    //vars
    public float bulletSpeed;
    public float bulletMaxSpeed;
    public int bulletDamage;
    public int bulletTime;

    public virtual void ShootBullet(){
        //bullet should continue to fly for bulletTime seconds before being destroyed
        Destroy(gameObject, bulletTime);
    }

}