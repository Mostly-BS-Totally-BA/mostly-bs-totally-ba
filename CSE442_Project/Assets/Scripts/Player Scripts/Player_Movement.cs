using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player_Movement : MonoBehaviour {

	//public float speed;
	private Animator animator;
	private Rigidbody2D player_rigid;
	public PolygonCollider2D swordCollider;
	public float attack_duration;
	private float counter;
	private bool moving;
	private bool isAttacking;
	private Vector2 lastMove;
    public bool canMove = true;
    [SerializeField]
    private PolygonCollider2D[] colliders;
    private int currentColliderIndex;
    private GameManager _gm = null;
	private float timer = 3.0f;
	private bool showGUI = false;
	private GUIStyle guiStyle = new GUIStyle();
    public bool isPoison;
    private float poisonCount = 1.5f;
    private int damageTime = 0;
    private float flashCount = .5f;
    private int flag = 0;
    private SpriteRenderer SpriteR;
	public GameObject arrow;
	private float ranged_CD = 0.0f;
    //public int currentHealth;

    void Start () {
		//Get the animator for the player
		animator = GetComponent<Animator> ();

		//Get players rigid2D Body
		player_rigid = GetComponent <Rigidbody2D> ();

		//Get swords collider object
		swordCollider.GetComponent<PolygonCollider2D> ();
        _gm = GameManager.Instance;
        //currentHealth = 6;

        SpriteR = GetComponent<SpriteRenderer>();
        isPoison = false;

    }
	
	// Update is called once per frame
	void Update () {

		//Check if not in the game over state
        if (_gm.gameState == GameState.Game)
        {
            MovePlayer();
            poisonOverTime();
        }

	}
    
    public void takeDamage(int amount)
    {   
        //_gm.LivesDecrease(amount);
/*        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            death();
        }*/
        _gm.LivesDecrease(amount);
    }
    public void death()
    {
        Destroy(gameObject);
        //_gm.endGame();
        
    }
    public void flashPurple()
    {
        flashCount -= Time.deltaTime;
        if(flashCount<=0&&flag==0)
        {
            this.SpriteR.color = new Color(.596f, .121f, .509f);
            flag = 1;
            flashCount = .5f;
        }
        if(flashCount<=0&&flag==1)
        {
            this.SpriteR.color = new Color(.909f, .270f, .792f);
            flag = 0;
            flashCount = .5f;
        }
        
    }
    public void poison(bool val)
    {
        isPoison = val;
    }
    public void poisonOverTime()
    {
        if (isPoison == true)
        {
            poisonCount -= Time.deltaTime;
            flashPurple();
            if (poisonCount<=0)
            {
                takeDamage(1);
               
                poisonCount = 1.5f;
                damageTime++;
            }
            if(damageTime==3)
            {
                damageTime = 0;
                isPoison = false;
                this.SpriteR.color = new Color(1f, 1f, 1f);
            }
        }
        

    }
    public void SetColliderForSprite(int spriteNum)
    {
        colliders[currentColliderIndex].enabled = false;
        currentColliderIndex = spriteNum;
        colliders[currentColliderIndex].enabled = true;
    }
    void MovePlayer(){

        if (!canMove)
        {
            return;
        }

		//Get horiztontal and vertical position of the player
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
		ranged_CD -= Time.deltaTime;

        moving = false;

        if (!isAttacking)
        {
			//moves left or right
            if (horizontal > 0.5f || horizontal < -0.5f)
            {
                transform.Translate(new Vector3(horizontal * _gm.playerSpeed * Time.deltaTime, 0f, 0f));
                moving = true;
                lastMove = new Vector2(horizontal, 0f);
            }

			//moves up or down
            if (vertical > 0.5f || vertical < -0.5f)
            {

                transform.Translate(new Vector3(0f, vertical * _gm.playerSpeed * Time.deltaTime, 0f));
                moving = true;
                lastMove = new Vector2(0f, vertical);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
				//On attack, enables sword colliders and set attack duration
                swordCollider.enabled = true;
                counter = attack_duration;
                isAttacking = true;
                player_rigid.velocity = Vector2.zero;
                animator.SetBool("isAttacking", true);
            }

			if (Input.GetKeyDown(KeyCode.Q))
			{
				//On attack, enables sword colliders and set attack duration
				_gm.use_potion();
				if (_gm.potionCount <= 0) {
					showGUI = true;
					StartCoroutine (Wait (timer));
				}
			}

			if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
			{
				if (ranged_CD <= 0 && _gm.arrowCount > 0) {
					spawnArrow (horizontal, vertical);
					_gm.use_arrow();
					Debug.Log ("Using Arrow: " + _gm.arrowCount + " left");
					ranged_CD = 3.0f;
				}
				else {
					Debug.Log ("Attack on CD");
				}
			}

        }

        if (counter > 0)
        {
            counter = counter - (Time.deltaTime * _gm.playerAttackSpeed);
        }

        else
        {
			//Player no longer attacking
            swordCollider.enabled = false;
            isAttacking = false;
            animator.SetBool("isAttacking", false);
        }

		//Used for animation transitions
        animator.SetFloat("x_movement", horizontal);
        animator.SetFloat("y_movement", vertical);
        animator.SetBool("moving", moving);
        animator.SetFloat("last_x_movement", lastMove.x);
        animator.SetFloat("last_y_movement", lastMove.y);
    }

	void spawnArrow(float horizontal,float vertical)
	{
		GameObject spawnArrow;

		if (horizontal > 0.5f || lastMove.Equals (new Vector2 (1, 0))) {
			spawnArrow = Instantiate (arrow, transform.position, Quaternion.Euler (0f, 0f, -225f));
		} else if (horizontal < -0.5f || lastMove.Equals (new Vector2 (-1, 0))) {
			spawnArrow = Instantiate (arrow, transform.position, Quaternion.Euler (0f, 0f, -45f));
		} else if (vertical > 0.5f || lastMove.Equals (new Vector2 (0, 1))) {
			spawnArrow = Instantiate (arrow, transform.position, Quaternion.Euler (0f, 0f, -135f));
			spawnArrow.GetComponent<Rigidbody2D>().constraints = ~RigidbodyConstraints2D.FreezePositionY;
			spawnArrow.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
		} else {
			spawnArrow = Instantiate (arrow, transform.position, Quaternion.Euler (0f, 0f, -315f));
			spawnArrow.GetComponent<Rigidbody2D>().constraints = ~RigidbodyConstraints2D.FreezePositionY;
			spawnArrow.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
		}

		spawnArrow.GetComponent <Rigidbody2D> ().AddRelativeForce (new Vector2 (0f, -200f));
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            player_rigid.velocity = Vector2.zero;
            //coll.rigidbody.isKinematic = true;
        }
        //coll.gameObject.SendMessage("ApplyDamage", 10);

    }
    
    void OnCollisionExit2D(Collision2D coll)
    {
        //coll.rigidbody.isKinematic = false;
    }

    public void ZeroVel()
    {
        player_rigid.velocity = Vector2.zero;
    }


	IEnumerator Wait(float timer)
	{
		yield return new WaitForSecondsRealtime(timer);        //Waits for seconds indicated by timer
		showGUI = false;                                     //removes text from screen
	}

	private void OnGUI()
	{
        if (showGUI == true)
        {
            guiStyle.fontSize = 20;                                            //change the font size
            guiStyle.normal.textColor = Color.white;
            GUI.Label(new Rect(10, 10, 500, 20), "Out of potions!", guiStyle);
        }//places text on screen
	}

    
}
