using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController: MonoBehaviour {
    //CONTROLS THE PLAYER MOVEMENT VIA RIGIDBODY
    //public vars
    public static PlayerController instance;
    public float moveDist = 0.5f;
    public float jumpStrength = 1f;
    public float speed = 5f;
    public float maxSpeed = 10f;

    //private vars
    private Rigidbody2D rb;
    private bool _grounded = true;

    //properties
    public bool Grounded {
        get {
            return _grounded;
        }
        set {
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
    }

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        //vertical, jumping
        if(CrossPlatformInputManager.GetButtonDown("Jump") && _grounded == true) {
            _grounded = false;
            rb.MovePosition(new Vector2(transform.position.x, transform.position.y + jumpStrength));
        }
    }

    private void FixedUpdate() {
        //horizontal axis
        rb.AddForce(CrossPlatformInputManager.GetAxis("Horizontal") * speed * Vector2.right, ForceMode2D.Impulse);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);

        //stopping motion if nothing is pressed
        if(CrossPlatformInputManager.GetAxis("Horizontal") == 0) {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}