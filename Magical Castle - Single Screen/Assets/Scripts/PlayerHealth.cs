using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hey I need to die artik!");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hey I need to die!");
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("player died");
        animator.SetBool("isDead", true);

        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 2);
        this.enabled = false;

    }


   
}
