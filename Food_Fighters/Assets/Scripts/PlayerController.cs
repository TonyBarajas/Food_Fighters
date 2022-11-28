using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody RB;
    public float moveSpeed, jumpForce;

    private Vector2 moveInp;


    public LayerMask whatisGround; // sirve para decirle que layer queremos que sea el suelo
    public Transform groundPoint; // es un empty dentro del player que sirve para saber si está tocando el suelo
    private bool isGrounded; // bool para activar animaciones cuando se toque o salga del suelo
    

    public Animator anim; 
    public SpriteRenderer SR;
    


    // Update is called once per frame
    void Update()
    {
        moveInp.x = Input.GetAxis("Horizontal");
        //moveInp.y = Input.GetAxis("Vertical");
        moveInp.Normalize(); // normalize smoothea cuando se mueve en las dos direcciones a la vez para que no agarre más velocidad

        RB.velocity = new Vector3(moveInp.x * moveSpeed, RB.velocity.y, 0); // se crea un movimiento en 3d, la x reacciona a la velocidad, la y al movimiento del rigidbody y la z está apagada

        anim.SetFloat("Speed", RB.velocity.magnitude); //magnitud nos dice que tan rapido se mueve

        RaycastHit hit; 
        if(Physics.Raycast(groundPoint.position, Vector3.down, out hit, .1f, whatisGround)) //manda un rayo hacia el suelo para comprobar si está o no está saltando 
        {
            isGrounded = true; //si el player toca el suelo con la layer de "Ground" se enciende la variable
        }else
        {
            isGrounded = false; //Si el player deja de tocar el suelo se apaga la variable
        }

        

        if(Input.GetKeyDown("w") && isGrounded) //salto 
        {

            RB.velocity += new Vector3(0f, jumpForce, 0f);
        }

        anim.SetBool("ONGround", isGrounded); // le indica a la animación de salto que hacer dependiendo del estado del "IsGrounded"

       

       

        if (!SR.flipX && moveInp.x > 0.01) // sirve para que nuestro sprite mire a la dirección que caminamos
        {
            SR.flipX = true;
        }else if(SR.flipX && moveInp.x < 0.01) // si el movimiento es contrario al del sprtite mandamos a que se invierta la x 
        {
            SR.flipX = false;
        }
    }
}
