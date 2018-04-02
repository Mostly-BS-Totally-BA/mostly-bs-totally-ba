using UnityEngine;

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
    //public int currentHealth;
    public int KillCount;
    public bool hasKilled;

    void Start () {
		//Get the animator for the player
		animator = GetComponent<Animator> ();

		//Get players rigid2D Body
		player_rigid = GetComponent <Rigidbody2D> ();

		//Get swords collider object
		swordCollider.GetComponent<PolygonCollider2D> ();
        _gm = GameManager.Instance;
        //currentHealth = 6;
        KillCount = 0;
        hasKilled = false;

    }
	
	// Update is called once per frame
	void Update () {

		//Check if not in the game over state
        if (_gm.gameState == GameState.Game)
        {
            MovePlayer();
            checkKills();
        }

	}
    public void addKill()
    {
		//Add kill to kill counter
        KillCount++;
        hasKilled = true;
    }
    public void checkKills()
    {
		//If it has been 5 kills add 1 health to player
        if(KillCount%5==0&&hasKilled==true)
        {
            _gm.LivesIncrease(1);
            hasKilled = false;
            //currentHealth++;
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
    
}
