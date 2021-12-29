using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update


    public CharacterController2D controller;

    public Animator animator;

    float HorizontalMovement = 0f;
    public float runSpeed = 60f;

    bool jump = false;

    bool crouch = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(HorizontalMovement));

        if (Input.GetButton("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;

        }else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }



      void FixedUpdate()
    {
        controller.Move(HorizontalMovement * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
