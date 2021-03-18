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
    public AudioSource collectAudio;
    public AudioSource deathAudio;


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
            collectAudio.Play();
            ScoreManager.instance.ChangeScore(1);
            Destroy(collision.gameObject);
            Heal(collision.gameObject.tag);
            Debug.Log("I collided");
        }
    }

    public void TakeDamage(int damage)
    {

        currentHealth -= damage;
        deathAudio.Play();
        healthBar.SetHealth(currentHealth);


        if (currentHealth <= 0)
        {
            deathAudio.Play();
            animator.SetBool("isDead", true);
            Die();
        }
    }

    public void Heal(string heal)
    {
        Debug.Log("Before Switch");
        switch (heal)
        {
            case "BluePotion":
                {
                    currentHealth += 1;
                    Debug.Log("After Switch");
                }
                break;
            case "GreenPotion":
                {
                    currentHealth += 3;
                    Debug.Log("After Switch");
                }
                break;
            case "PurplePotion":
                {
                    currentHealth += 2;
                    Debug.Log("After Switch");
                }
                break;
            case "RedPotion":
                {
                    currentHealth += 4;
                    Debug.Log("After Switch");
                }
                break;
            case "YellowPotion":
                {
                    currentHealth += 1;
                    Debug.Log("After Switch");
                }
                break;

        }


        if (currentHealth <= maxHealth)
        {
           
            healthBar.SetHealth(currentHealth);
            
        }
    }

   
    public void Die()
    {
        Debug.Log("player died");
        deathAudio.Play();
        animator.SetBool("isDead", true);

        Invoke("ReturnMenu", 2f);

        GetComponent<Collider2D>().enabled = false;

    }
    

    public void ReturnMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
