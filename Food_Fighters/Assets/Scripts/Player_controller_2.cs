using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller_2 : MonoBehaviour
{
    public float jumpForce;
    public float Speed;
    public Rigidbody RB;
    public Animator anim;

    public Transform groundPoint;
    private bool isGrounded;
    public float checkRadius;
    public LayerMask WhatIsGround;   

    private void Start()
    {
       // anim = GetComponent<Animator>();
       // RB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(groundPoint.position, Vector3.down, out hit, .1f, WhatIsGround)) //manda un rayo hacia el suelo para comprobar si está o no está saltando 
        {
            isGrounded = true; //si el player toca el suelo con la layer de "Ground" se enciende la variable

        }
        else
        {
            isGrounded = false; //Si el player deja de tocar el suelo se apaga la variable
        }

        if (Input.GetKeyDown("w") && isGrounded) //salto 
        {
            anim.SetTrigger("Jumping");
            //anim.SetBool("ONGround", isGrounded);
            RB.velocity += new Vector3(0f, jumpForce, 0f);
        }

        float moveinput = Input.GetAxisRaw("Horizontal");
        RB.velocity = new Vector3(moveinput * Speed, RB.velocity.y, 0);

        if(moveinput == 0)
        {
            anim.SetBool("Walking", false);
        }
        else
        {
            anim.SetBool("Walking", true);
        }

        if (moveinput > 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (moveinput < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }


    }



}
