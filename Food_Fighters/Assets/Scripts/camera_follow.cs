using UnityEngine;

public class camera_follow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;  // velocidad con que la camara sigue al jugador
    public Vector3 offset; // variable vector que nos ayudara a setear la camara a la distancia deseada

    [SerializeField]
    float leftLimit;

    [SerializeField]
    float RightLimit;

    [SerializeField]
    float BottomLimit;

    [SerializeField]
    float TopLimit;
 


    void LateUpdate() // usamos un fixupdate en lugar de update para que el jugador y la camara no estén compitiendo en el update todo el rato
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); //(Lerp) = el proceso de suavisar el movimiento de un punto a otro
        // (Lerp) = nos pide la posición a, la posición b y el tiempo, si el tiempo es 0 significa que está en la posición a y si es 1 está en la b, cualquier valor entre 1 y 0 será un intermedio, por eso ponemos el smooth speed
        transform.position = desiredPosition; // se crea el attach al jugador + el offset de la distancia de la camera(desiredPosition)

        transform.LookAt(target);

        transform.position = new Vector3
       (
           Mathf.Clamp(transform.position.x, leftLimit, RightLimit),
           Mathf.Clamp(transform.position.y, BottomLimit, TopLimit),
           transform.position.z
       ); // en este nuevo vector 3 estamos indicandole que respete los limites puestos en los serializable fields y que la camara no pase de ahí
          // (Clamp) es una herrmanieta para confinar un valor a un rango establecido 
    }
}
