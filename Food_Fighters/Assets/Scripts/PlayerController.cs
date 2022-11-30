using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody RB;
    public float moveSpeed, jumpForce;

    private Vector2 moveInp;
    //private bool isRightPressed = false;
    //private bool isLeftPressed = false;


    public LayerMask whatisGround; // sirve para decirle que layer queremos que sea el suelo
    public Transform groundPoint; // es un empty dentro del player que sirve para saber si est� tocando el suelo
    private bool isGrounded; // bool para activar animaciones cuando se toque o salga del suelo
   

    public Animator anim; 
    public SpriteRenderer SR;
   

    

    // Update is called once per frame
    void Update()
    {
        //isRightPressed = Input.GetKey(KeyCode.D);
        //isLeftPressed = Input.GetKey(KeyCode.A);
        moveInp.x = Input.GetAxis("Horizontal");
        moveInp.y = Input.GetAxis("Vertical");
        moveInp.Normalize(); // normalize smoothea cuando se mueve en las dos direcciones a la vez para que no agarre m�s velocidad
        RB.velocity = new Vector3(moveInp.x * moveSpeed, RB.velocity.y, 0); // se crea un movimiento en 3d, la x reacciona a la velocidad, la y al movimiento del rigidbody y la z est� apagada

        anim.SetFloat("Speed", RB.velocity.magnitude); //magnitud nos dice que tan rapido se mueve

        RaycastHit hit; 
        if(Physics.Raycast(groundPoint.position, Vector3.down, out hit, .1f, whatisGround)) //manda un rayo hacia el suelo para comprobar si est� o no est� saltando 
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

        anim.SetBool("ONGround", isGrounded); // le indica a la animaci�n de salto que hacer dependiendo del estado del "IsGrounded"




        Vector3 pos = transform.position;
        if (moveInp.x > 0.01) // sirve para que nuestro sprite mire a la direcci�n que caminamos
        {
            pos.x += moveSpeed * Time.deltaTime;
            transform.position = pos;
            SR.flipX = true;
        }
        if(moveInp.x < 0.01) // si el movimiento es contrario al del sprtite mandamos a que se invierta la x 
        {
            pos.x -= moveSpeed * Time.deltaTime;
            transform.position = pos;
            SR.flipX = false;
        }
    }

    // void FixedUpdate()
    //{
    //    Vector3 pos = transform.position;
    //    if (isRightPressed)
    //    {
    //        pos.x += moveSpeed * Time.deltaTime;
    //        transform.position = pos;
    //        SR.flipX = true;
    //    }
    //    if (isLeftPressed)
    //    {
    //        pos.x -= moveSpeed * Time.deltaTime;
    //        transform.position = pos;
    //        SR.flipX = false;
    //    }
    //}
}
