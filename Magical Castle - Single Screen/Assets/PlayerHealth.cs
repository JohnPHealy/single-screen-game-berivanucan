using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Q))
        {
            TakeDamage(1);
        }
        */
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("enemy collide");
        if(other.CompareTag("Enemy"))
        {
            Debug.Log("enemy tag");
            TakeDamage(1);
            Debug.Log("damage");
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
