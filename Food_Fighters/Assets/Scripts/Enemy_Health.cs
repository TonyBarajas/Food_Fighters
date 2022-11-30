using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Enemy_Health : MonoBehaviour
{
    [SerializeField] public int _health = 100;
    public int _currentHealth = 100;
    [SerializeField] private UnityEvent _onDeath = new();

    // Start is called before the first frame update
    void OnEnable()
    {
        _currentHealth = _health;
    }

    public void ReceiveDamage(int damage)
    {
        _currentHealth -= damage; //Shortcut para irle restando el Daño
        //play hurt animation

        if (_currentHealth <= 0)
        {
          
            if (_currentHealth <= 0)
                _onDeath?.Invoke();
            /*Die();*/ // si llega a ser menos de 0(muerto) se manda a llamar al DIe
        }
    }

    //void Die()
    //{
    //    Debug.Log("Enemy died!");
    //    // Die animation
    //    // disable the enemy
    //}
}
