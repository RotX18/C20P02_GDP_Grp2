using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //CONTROLS THE PLAYER MOVEMENT VIA RIGIDBODY
    //public vars
    [HideInInspector] public float speed = 10f;
    [HideInInspector] public float jumpStrength = 5f;

    //private vars
    private Rigidbody2D rb;
    private float h;
    private float v;
    private bool grounded = true;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        //adding gravity
        rb.AddForce(Physics2D.gravity, ForceMode2D.Impulse);

        //input get axis, returns -1 < x < 1
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        //adding force based on the Input.GetAxis values
        //horizontal axis
        rb.AddForce(h * Vector2.right * speed, ForceMode2D.Impulse);

        //vertical, jumping
        rb.AddForce(v * Vector2.up * jumpStrength, ForceMode2D.Impulse);

        if(!Input.anyKey){ //stops movement when nothing is pressed down
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }
}
