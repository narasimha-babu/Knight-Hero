using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{

    public CharacterController2D controller;

    public Animator Animator;

    
    public float runSpeed = 60f;
    float HorizontalMovement = 0f;


    bool jump = false;
    bool crouch = false;
    


    // Start is called before the first frame update
    void Start( )
    {
        
    }

    // Update is called once per frame
    void Update( )
    {
        HorizontalMovement = Input.GetAxisRaw("Horizontal") * runSpeed;

        Animator.SetFloat("Speed", Mathf.Abs(HorizontalMovement));
       

        if (Input.GetButton("Jump"))
        {
            jump  = true;
            Animator.SetBool("IsJumping", true);
        }
       

    }

    public void OnLanding( )
    {

        Animator.SetBool("IsJumping", false);
    }

  

    void FixedUpdate( )
    {
        controller.Move(HorizontalMovement * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}


