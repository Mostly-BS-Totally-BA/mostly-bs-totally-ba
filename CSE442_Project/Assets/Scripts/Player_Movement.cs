using UnityEngine;

public class Player_Movement : MonoBehaviour {

	public float speed;
	private Animator animator;
	  
	private bool moving;
	private Vector2 lastMove;

	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
			
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");

		moving = false;
		if (horizontal > 0.5f || horizontal < -0.5f) {

			transform.Translate (new Vector3 (horizontal * speed * Time.deltaTime, 0f, 0f));
			moving = true;
			lastMove = new Vector2 (horizontal, 0f);
		}

		if (vertical > 0.5f || vertical < -0.5f) {

			transform.Translate (new Vector3 (0f, vertical * speed * Time.deltaTime, 0f));
			moving = true;
			lastMove = new Vector2 (0f, vertical);
		}

		animator.SetFloat ("x_movement", horizontal);
		animator.SetFloat ("y_movement", vertical);
		animator.SetBool ("moving", moving);
		animator.SetFloat ("last_x_movement", lastMove.x);
		animator.SetFloat ("last_y_movement", lastMove.y);
	}
}
