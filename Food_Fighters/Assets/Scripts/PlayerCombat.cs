using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    public Transform attackpoint;
    public float attackRange = 0.5f;
    public LayerMask Enemy;
  
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
        Collider[] hitEnemies = Physics.OverlapSphere(attackpoint.position, attackRange, Enemy);
        foreach(Collider enemy in hitEnemies)
        {
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
