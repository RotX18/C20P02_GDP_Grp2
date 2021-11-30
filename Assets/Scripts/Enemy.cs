using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //CONTROLLING THE ENEMY PREFABS BASED ON RIGIDBODIES
    //public vars
    public float displacement = 0;
    public float moveStrength = 10;
    public float maxSpeed = 3;
    
    //private vars
    private Rigidbody2D rb;
    private Vector2 originalPos;
    private int direction = 1;

    //protected vars
    protected float _health = 3;

    //properties
    public float Health{ 
        get{
            return _health;
        }
        set{
            _health = value;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalPos = transform.position;
    }

    private void Update() {
        if(transform.position.x > (originalPos.x + displacement)){
            //if enemy has reached the max allowed x pos, flip the travel direction
            direction *= -1;
        }
        if(transform.position.x < (originalPos.x - displacement)){
            //if enemy has reached the min allowed x pos, flip the travel direction
            direction *= -1;
        }
    }

    private void FixedUpdate() {
        //move the enemy
        rb.AddForce(new Vector2(moveStrength, 0) * direction, ForceMode2D.Impulse);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity,maxSpeed);
    }
}
