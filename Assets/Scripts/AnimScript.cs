using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class AnimScript : MonoBehaviour
{

    bool facingRight = true;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(h));


        if(CrossPlatformInputManager.GetButton("Jump"))
        {
            anim.SetBool("Jump", true);
        }
        

        if(h > 0 && !facingRight)
        {
            Flip();
        }

        if (h < 0 && facingRight)
        {
            Flip();
        }
    }

    private void LateUpdate()
    {
        if (CrossPlatformInputManager.GetButtonUp("Jump"))
        {
            anim.SetBool("Jump", false);
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
