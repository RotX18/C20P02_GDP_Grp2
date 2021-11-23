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
    public GameObject bulletPrefabPfizer;
    public GameObject bulletPrefabModerna;
    public GameObject bulletPrefabSinovac;

    //PRIVATE
    //movement vars
    private Rigidbody2D rb;
    protected bool _grounded = true;
    protected bool _cannotJump = false;

    //attack vars
    protected bool _powered = false;
    protected char _powerType = 'n';

    //properties
    public bool Grounded {
        get {
            return _grounded;
        }
        set {
            _grounded = value;
        }
    }

    public bool CannotJump{ 
        get{
            return _cannotJump;
        }
        set{
            _cannotJump = value;
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

    public char PowerType{ 
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
        if(CrossPlatformInputManager.GetButtonDown("Jump") && _grounded && !_cannotJump) {
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
        else if(_powered == true){ 
            switch(_powerType){
                //instantiating bullet prefab based on type of vax
                //n = none (default), p = pfizer, m = moderna, s = sinovac
                case 'p':
                    Instantiate(bulletPrefabPfizer, new Vector2(transform.position.x + 1, transform.position.y), Quaternion.identity);
                    break;
                case 'm':
                    Instantiate(bulletPrefabModerna, new Vector2(transform.position.x + 1, transform.position.y), Quaternion.identity);
                    break;
                case 's':
                    Instantiate(bulletPrefabSinovac, new Vector2(transform.position.x + 1, transform.position.y), Quaternion.identity);
                    break;
            }
        }
    }
}