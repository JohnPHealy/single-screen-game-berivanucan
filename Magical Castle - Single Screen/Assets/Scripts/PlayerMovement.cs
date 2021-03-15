using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public CharacterController2D controller;
	public Animator animator;
	public Rigidbody2D rb;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	bool canClimb = false;
	float climbForce = 10f;

	// Update is called once per frame
	void Update()
	{

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		}
		else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}
		/*if(canClimb && Input.GetButtonDown("ClimbUp"))
        {
			Debug.Log("I can climb");
			canClimb = true;
			animator.SetBool("canClimb", true);
		}
		if (canClimb && Input.GetButtonDown("ClimbDown"))
		{
			Debug.Log("I can climb");
			canClimb = true;
			animator.SetBool("canClimb", true);
		}
		*/
	}

	public void OnLanding()
    {
		animator.SetBool("IsJumping", false);
    }

	public void OnCrouching(bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}

	private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Potion"))
        {
			Destroy(other.gameObject);
        }
		/*if (other.gameObject.CompareTag("Ladder")  && (Input.GetButtonDown("ClimbUp") || Input.GetButtonDown("ClimbDown")))
		{
			Debug.Log("I collided");
			canClimb = true;
		}
		*/
	}
	
	/*

    private void OnTriggerExit2D(Collider2D other)
    {

		if (other.gameObject.CompareTag("Ladder")  && (Input.GetButtonDown("ClimbUp") || Input.GetButtonDown("ClimbDown")))
		{
			animator.SetBool("canClimb", false);
			canClimb = false;
		}
	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		// Stops the player from being affected by gravity while on ladder
		if (other.gameObject.CompareTag("Ladder"))
			rb.gravityScale = 0;
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if (!(other.gameObject.CompareTag("Ladder")))
			return;

		float y = Input.GetAxis("Vertical");
		animator.SetBool("canClimb", true);
		rb.transform.Translate(new Vector3(0, 1f, 0), 0);
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		// Stops the player from being affected by gravity while on ladder
		if (other.gameObject.CompareTag("Ladder"))
			rb.gravityScale = 3;
	}

	*/
	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, canClimb);
		jump = false;
	}
}