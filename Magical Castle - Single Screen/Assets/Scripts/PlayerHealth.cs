using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 10;
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
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            TakeDamage(1);
        }
        if (collision.gameObject.CompareTag("BluePotion") || collision.gameObject.CompareTag("GreenPotion") || collision.gameObject.CompareTag("PurplePotion") || collision.gameObject.CompareTag("RedPotion") || collision.gameObject.CompareTag("YellowPotion"))
        {
            
            ScoreManager.instance.ChangeScore(1);
            Destroy(collision.gameObject);
            Heal(collision.gameObject.tag);
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

    public void Heal(string heal)
    {
        switch(heal)
        {
            case "BluePotion":
                {
                    currentHealth += 1;
                }
                break;
            case "GreenPotion":
                {
                    currentHealth += 3;
                }
                break;
            case "PurplePotion":
                {
                    currentHealth += 2;
                }
                break;
            case "RedPotion":
                {
                    currentHealth += 4;
                }
                break;
            case "YellowPotion":
                {
                    currentHealth += 1;
                }
                break;

        }


        if (currentHealth <= maxHealth)
        {
           
            healthBar.SetHealth(currentHealth);
            
        }
    }

   
    void Die()
    {
        Debug.Log("player died");
        animator.SetBool("isDead", true);

        GetComponent<Collider2D>().enabled = false;
       
       
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        this.enabled = false;

    }


   
}
