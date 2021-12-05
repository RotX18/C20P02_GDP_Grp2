using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController: MonoBehaviour{
    
    //CONTROLS THE PLAYER MOVEMENT VIA RIGIDBODY
    //PUBLIC
    public static PlayerController instance;

    //movement vars
    public float moveDist = 0.5f;
    public float jumpStrength = 3f;
    public float speed = 10f;
    public float maxSpeed = 15f;

    //attack vars
    public float meleeRange = 1f;
    public GameObject bulletPrefabPfizer;
    public GameObject bulletPrefabModerna;
    public GameObject bulletPrefabSinovac;
    public enum PowerType {
        none,
        pfizer,
        moderna,
        sinovac
    }

    //PRIVATE
    //movement vars
    private Rigidbody2D rb;

    //PROTECTED
    //movement vars
    protected bool _facingRight = true;
    protected bool _grounded = true;
    protected bool _cannotJump = false;

    //attack vars
    protected bool _powered = false;
    protected PowerType _currentPower = PowerType.none;
    protected float _powerUpDuration = 0;
    protected int _health = 3;

    //ken's test
    GameManager kills;

    ///
    //PROPERTIES
    //movement properties
    public bool FacingRight{ 
        get{
            return _facingRight;
        }
        set{
            _facingRight = value;
        }
    }

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

    //attack properties
    public bool Powered{ 
        get{
            return _powered;
        }
        set{
            _powered = value;
        }
    }

    public PowerType CurrentPower{ 
        get{
            return _currentPower;
        }
        set{
            _currentPower = value;
        }
    }

    public float PowerUpDuration{ 
        get{
            return _powerUpDuration;
        }
        set{
            _powerUpDuration = value;
        }
    }

    public int Health{ 
        get{
            return _health;
        }
        set{
            _health = value;
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

        //facing
        if(gameObject.transform.localScale.x <= 0){
            //facing left
            _facingRight = false;
        }
        if(gameObject.transform.localScale.x >= 0) {
            //facing right
            _facingRight = true;
        }

        //-1 for every second
        if(_powerUpDuration > 0){
            _powerUpDuration -= Time.deltaTime;
        }
    }

    private void FixedUpdate() {
        //horizontal axis
        rb.AddForce(CrossPlatformInputManager.GetAxis("Horizontal") * speed * Vector2.right, ForceMode2D.Impulse);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);

        //mitigates"air run" (uncomment if we want to apply the mitigation)
        rb.velocity = new Vector2(rb.velocity.x, Physics2D.gravity.y);

        //stopping motion if nothing is pressed
        if(CrossPlatformInputManager.GetAxis("Horizontal") == 0) {
            rb.velocity = new Vector2(0, Physics2D.gravity.y);
        }
    }

    private void Attack(){
        if(_powered == false){ //melee
            //cast ray to meleeRange units infront of the player
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + 1, transform.position.y), new Vector2(transform.position.x + meleeRange, transform.position.y));

            //PLAY MELEE ATTACK ANIM
            
            if(hit.collider.CompareTag("Enemy")) { //if ray hits enemy
                
                Destroy(hit.collider.gameObject);
                GameManager.i.totalKills++;
            }
        }
        else if(_powered == true){ 
            switch(_currentPower){
                //instantiating bullet prefab based on type of vax
                case PowerType.pfizer:
                    if(_facingRight){ 
                        Instantiate(bulletPrefabPfizer, new Vector2(transform.position.x + 1, transform.position.y), Quaternion.identity);
                    }
                    else{
                        Instantiate(bulletPrefabPfizer, new Vector2(transform.position.x - 1, transform.position.y), Quaternion.identity);
                    }
                    break;
                case PowerType.moderna:
                    if(_facingRight) {
                        Instantiate(bulletPrefabModerna, new Vector2(transform.position.x + 1, transform.position.y), Quaternion.identity);
                    }
                    else{
                        Instantiate(bulletPrefabModerna, new Vector2(transform.position.x - 1, transform.position.y), Quaternion.identity);
                    }
                    break;
                case PowerType.sinovac:
                    if(_facingRight) {
                        Instantiate(bulletPrefabSinovac, new Vector2(transform.position.x + 1, transform.position.y), Quaternion.identity);
                    }
                    else{
                        Instantiate(bulletPrefabSinovac, new Vector2(transform.position.x - 1, transform.position.y), Quaternion.identity);
                    }
                    break;
            }
        }
    }

    public void GameOver(){
        //GameOver method, add code for ui later
        Debug.Log("GAME OVER!");
        Time.timeScale = 0;
    }
}