using UnityEngine;

public class Player_Movement : MonoBehaviour {

	public float speed;
	public Animator animator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");

		if (horizontal == 0.0f || vertical == 0.0f) {
			animator.SetBool ("move_down", false);
			animator.SetBool ("move_up", false);
			animator.SetBool ("move_left", false);
			animator.SetBool ("move_right", false);
		}
		//move right
		if(horizontal > 0.5f)
		{
			transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * speed * Time.deltaTime,0f,0f));
			animator.SetBool ("move_down", false);
			animator.SetBool ("move_up", false);
			animator.SetBool ("move_left", false);
			animator.SetBool ("move_right", true);
		}

		//move left
		if (horizontal < -0.5f) {
			transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * speed * Time.deltaTime,0f,0f));
			animator.SetBool ("move_down", false);
			animator.SetBool ("move_up", false);
			animator.SetBool ("move_left", true);
			animator.SetBool ("move_right", false);
		}

		//move up
		if(vertical > 0.5f)
		{
			transform.Translate (new Vector3 (0f,Input.GetAxisRaw ("Vertical") * speed * Time.deltaTime,0f));
			animator.SetBool ("move_down", false);
			animator.SetBool ("move_up", true);
			animator.SetBool ("move_left", false);
			animator.SetBool ("move_right", false);
		}

		//move down
		if (vertical < -0.5f) {
			transform.Translate (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * speed * Time.deltaTime, 0f));
			animator.SetBool ("move_down", true);
			animator.SetBool ("move_up", false);
			animator.SetBool ("move_left", false);
			animator.SetBool ("move_right", false);
		}

	}
}
