using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    public AudioSource Audio;
    
    public Transform attackpoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 120;

  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Attack();
        }
        
    }

    void Attack()
    {
        animator.SetTrigger("Attack");  //Despliega la animación del attaque
        Audio.Play();
        
        Collider[] hitEnemies = Physics.OverlapSphere(attackpoint.position, attackRange, enemyLayers); //revisa cada uno de los elementos que golpea el ataque
        foreach(Collider enemy in hitEnemies) //se activa cuando el ataque entra contra un collider dentro de un enemy
        {
            enemy.GetComponent<Enemy_Health>().ReceiveDamage(attackDamage); //se accesa la salud del enemigo y se le resta el daño hecho 
            Debug.Log("We hit + enemy.name"); // debug para comprobar que si funcionara :p 
        }

        
    }

    private void OnDrawGizmosSelected() // draw gizmo para ubicar donde se encuentra el punto de referencia de attaque
    {
        if (attackpoint == null)
            return;
        Gizmos.DrawSphere(attackpoint.position, attackRange);
    }
}
