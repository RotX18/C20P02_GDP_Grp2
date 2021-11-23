using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController: MonoBehaviour{
    
    //CONTROLS THE PLAYER MOVEMENT VIA RIGIDBODY
    //PUBLIC
    //movement vars
    public static PlayerController instance;
    public float moveDist = 0.5f;
    public float jumpStrength = 1f;
    public float speed = 10f;
    public float maxSpeed = 20f;

    //attack vars
    public float meleeRange = 1f;
    public GameObject bulletPrefab;

    //PRIVATE
    //movement vars
    private Rigidbody2D rb;
    protected bool _grounded = true;

    //attack vars
    protected bool _powered = false;
    protected string _powerType = "";

    //properties
    public bool Grounded {
        get {
            return _grounded;
        }
        set {
            _grounded = value;
        }
    }

    public bool Powered{ 
        get{
            return _powered;
        }
        set{
            _powered = value;
        }
    }

    public string PowerType{ 
        get{
            return _powerType;
        }
        set{
            _powerType = value;
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

        //attack
        if(CrossPlatformInputManager.GetButtonDown("Attack")){
            Attack();
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

    private void Attack(){
        if(_powered == false){ //melee
            //cast ray to meleeRange units infront of the player
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + 1, transform.position.y), new Vector2(transform.position.x + meleeRange, transform.position.y));

            //PLAY MELEE ATTACK ANIM
            
            if(hit.collider.CompareTag("Enemy")) { //if ray hits enemy
                Destroy(hit.collider.gameObject);
            }
        }
    }
}