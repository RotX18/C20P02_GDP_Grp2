using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class AnimScript : MonoBehaviour
{
    public Sprite sprite;
    bool facingRight = true;
    Animator anim;
    SpriteRenderer spriteRenderer;
    PlayerController.PowerType _currentPower;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(h));
        _currentPower = PlayerController.instance.CurrentPower;

        if(CrossPlatformInputManager.GetButton("Jump"))
        {
            anim.SetBool("Jump", true);
        }

        if (CrossPlatformInputManager.GetButton("Attack"))
        {
            anim.SetBool("Punch", true);
        }

        if (h > 0 && !facingRight)
        {
            Flip();
        }

        if (h < 0 && facingRight)
        {
            Flip();
        }

        switch (_currentPower) {
            case PlayerController.PowerType.none:
                anim.SetBool("Moderna",false);
                anim.SetBool("Pfizer",false);
                anim.SetBool("Sinovac",false);
                break;
            case PlayerController.PowerType.moderna:
                anim.SetBool("Moderna", true);
                break;
            case PlayerController.PowerType.pfizer:
                anim.SetBool("Jump", false);
                anim.SetBool("Pfizer", true);
                break;
            case PlayerController.PowerType.sinovac:
                anim.SetBool("Sinovac", true);
                break;
        }

        if (PlayerController.instance.Health == 0)
        {
            anim.enabled = false;
            spriteRenderer.sprite = sprite;
        }
    }

    private void LateUpdate()
    {
        if (CrossPlatformInputManager.GetButtonUp("Jump"))
        {
            anim.SetBool("Jump", false);
        }
        if (CrossPlatformInputManager.GetButtonUp("Attack"))
        {
            anim.SetBool("Punch", false);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 transformScale = transform.localScale;
        transformScale.x *= -1;
        transform.localScale = transformScale;
    }

}
