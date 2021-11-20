using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //KEN SEE IF YOU CAN DO THE UI BUTTONDOWN/ JOYSTICK IF NOT WE JUST USE MOVE POS

    //CONTROLS THE PLAYER MOVEMENT VIA RIGIDBODY
    //public vars
    public static PlayerController instance;
    public Button btnLeft;
    public Button btnRight;
    public Button btnJump;
    [HideInInspector] public float moveDist = 0.5f;
    [HideInInspector] public float jumpStrength = 1f;
    [HideInInspector] public float speed = 5f;
    [HideInInspector] public float maxSpeed = 10f;

    //private vars
    private Rigidbody2D rb;
    private bool _grounded = true;

    //properties
    public bool Grounded{ 
        get{
            return _grounded;
        }
        set{
            _grounded = value;
        }
    }

    private void Awake() {
        //singleton
        if(instance == null) {
            instance = this;
        }
        else if(instance != this) {
            Destroy(gameObject);
        }

        btnLeft.onClick.AddListener(left);
        btnRight.onClick.AddListener(right);
        btnJump.onClick.AddListener(jump);
    }

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    /*void FixedUpdate() {
        //controllerValue works in place of Input.GetAxis();
        //horizontal axis
        rb.AddForce(Input.GetAxis("Horizontal") * speed * Vector2.right, ForceMode2D.Impulse);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);

        //vertical, jumping
        if(_grounded == true && Input.GetKeyDown(Keycode.Space)) { //NOT WORKING, FIX
            _grounded = false;
            rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
        }
    }*/

    private void jump(){
        rb.MovePosition(new Vector2(transform.position.x, transform.position.y + jumpStrength));
    }

    private void left(){
        //moving the rb by 1 (value of moveDist) unit
        rb.MovePosition(new Vector2(transform.position.x - moveDist, transform.position.y));
    }

    private void right(){
        rb.MovePosition(new Vector2(transform.position.x + moveDist, transform.position.y));
    }
}