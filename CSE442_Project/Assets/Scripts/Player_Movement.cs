using UnityEngine;

public class Player_Movement : MonoBehaviour {

	public float speed;
	private Animator animator;
	private Rigidbody2D player_rigid;
	public PolygonCollider2D swordCollider;
	public float attack_duration;
	private float counter;
	private bool moving;
	private bool isAttacking;
	private Vector2 lastMove;

	void Start () {
		animator = GetComponent<Animator> ();
		player_rigid = GetComponent <Rigidbody2D> ();
		swordCollider.GetComponent<PolygonCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
			
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");

		moving = false;

		if (!isAttacking) {
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

			if (Input.GetKeyDown (KeyCode.Space)) {

				swordCollider.enabled = true;
				counter = attack_duration;
				isAttacking = true;
				player_rigid.velocity = Vector2.zero;
				animator.SetBool ("isAttacking", true);
			}
				
		}

		if (counter > 0) {
			counter = counter - Time.deltaTime;
		}

		else{

			swordCollider.enabled = false;
			isAttacking = false;
			animator.SetBool ("isAttacking", false);
		}

		animator.SetFloat ("x_movement", horizontal);
		animator.SetFloat ("y_movement", vertical);
		animator.SetBool ("moving", moving);
		animator.SetFloat ("last_x_movement", lastMove.x);
		animator.SetFloat ("last_y_movement", lastMove.y);
	}
}
