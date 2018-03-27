using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL1Boss : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public float speed;
    public GameObject smallrat;
    private GameObject Player;
    private Animator animator;
    private Transform target;
    private Rigidbody2D rb;
    private SpriteRenderer SpriteR;
    private bool attackS;
    private int countAtt;
    private float red;
    private float green;
    private float blue;
    public bool aggro;
    //private PolygonCollider2D polygonCol2D; Getting errors because of not being used
    public bool touchPlayer;
    public bool touchWeapon;
    //private PolygonCollider2D playerColl; Getting errors because of not being used
    public float timeCount;
    public bool coolDownAttack;
    public GameObject key;


    private GameManager _gm = null;

    // Use this for initialization
    void Start()
    {
        this.currentHealth = this.maxHealth;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Player = GameObject.FindWithTag("Player");
        //polygonCol2D = GetComponent<PolygonCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        //Player = GameObject.FindWithTag("Player");
        smallrat = GameObject.FindWithTag("Enemy");
        //playerColl = GetComponent<PolygonCollider2D>();
        timeCount = .5f;
        SpriteR = GetComponent<SpriteRenderer>();
        red = 255f;
        blue = 255f;
        green = 255f;
        _gm = GameManager.Instance;
        attackS = false;
        countAtt = 0;
        coolDownAttack = false;
        key.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_gm.gameState == GameState.Game)
        {
            MoveEnemy();
            //animator.SetBool("SmallRat", true);
            if (attackS == true)
            {
                
            }
        }
    }

    public void takeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            death();
        }
    }

    public void death()
    {
        _gm = GameManager.Instance;
        _gm.ScoreIncrease(10);
        //_gm.LivesDecrease(1);
        Destroy(gameObject);
        key.SetActive(true);
        //Destroy(gameObject);
    }
    private void send_damage()
    {
        Player.SendMessage("takeDamage", 2);
    }
    private void OnCollisionStay2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "Player")
        {
            rb.bodyType = RigidbodyType2D.Static;
            rb.velocity = Vector2.zero;
            Invoke("send_damage", 3);
            //_gm.LivesDecrease(1);
            //Invoke("colorChange", 1);
            //Invoke("defaultColor", 3);
            attackS = true;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            touchPlayer = true;
            //coll.rigidbody.isKinematic = true;
            //rb.velocity = Vector2.zero;
            //rb.bodyType= RigidbodyType2D.Static;
            rb.velocity = Vector2.zero;
            Player.SendMessage("takeDamage", 2);
            //_gm.LivesDecrease(2);


        }
        if (coll.gameObject.tag == "Weapon")
        {
            touchWeapon = true;
        }
        //coll.gameObject.SendMessage("ApplyDamage", 10);

    }
    void OnCollisionExit2D(Collision2D coll)
    {
        //coll.rigidbody.isKinematic = false;
        rb.bodyType = RigidbodyType2D.Dynamic;
        touchPlayer = false;
        attackS = false;
        this.SpriteR.color = new Color(1, 1, 1);
        blue = 255;
        green = 255;
    }

    public void defaultColor()
    {
        this.SpriteR.color = new Color(1, 1, 1);
        blue = 255;
        green = 255;
    }
    public void colorChange()
    {
        blue = blue - 50;
        green = green - 50;
        red = red / 255;
        blue = blue / 255;
        green = green / 255;
        this.SpriteR.color = new Color(red, green, blue);
        red = red * 255;
        blue = blue * 255;
        green = green * 255;
        Debug.Log("Blue: " + blue + "Green: " + green);
        Debug.Log("Sprite:" + SpriteR.color.ToString());
    }

    public void attack()
    {

        timeCount -= Time.deltaTime;
        //Debug.Log("time: " + timeCount);
        if (timeCount <= 0)
        {
            countAtt++;
            if(coolDownAttack==false)
            {
                blue = blue - 85;
                green = green - 85;
                red = red / 255;
                blue = blue / 255;
                green = green / 255;
                this.SpriteR.color = new Color(red, green, blue);
                red = red * 255;
                blue = blue * 255;
                green = green * 255;
                Debug.Log("Blue: " + blue + "Green: " + green);
                Debug.Log("Sprite:" + SpriteR.color.ToString());
                timeCount = .5f;

                //coolDownAttack++;
                if (countAtt == 3 && countAtt != 4&&target != null)
                {
                    //Player.SendMessage("takeDamage", 10);
                    Vector2 direction = target.position - transform.position;
                    Vector2 newvector = direction.normalized * speed * Time.deltaTime;
                    rb.velocity = newvector;
                    coolDownAttack = true;

                }
            }
            else
            {
                timeCount=.5f;

            }
        }
        if (countAtt == 4)
        {
            //Player.SendMessage("takeDamage", 10);
            this.SpriteR.color = new Color(1, 1, 1);
            blue = 255;
            green = 255;
            //countAtt = 0;
        }
        //cooldown for each attack
        if(countAtt==6)
        {
            countAtt = 0;
            coolDownAttack=false;
        }



    }

    public void MoveEnemy()
    {
        if (aggro == false && target != null)
        {
            if (Vector2.Distance(transform.position, target.position) <= 3)
            {
                aggro = true;
            }
        }



        if (aggro == true)
        {
            //Vector2 direction = target.position - transform.position;
            //Vector2 newvector = direction.normalized * speed * Time.deltaTime;

            attack();
            /*
            if (rb.bodyType != RigidbodyType2D.Static)
            {
                rb.velocity = newvector;
            }
            */
            //rb.position

            //transform.Translate(new Vector3(rb.position.x-newvector.x, rb.position.y-newvector.y, 0f));
            //Vector3 vect = Vector3.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
            //transform.Translate(vect.x * speed * Time.deltaTime, vect.y * speed * Time.deltaTime, 0f)
            if (touchPlayer == true)
            {
                // attack();
            }
            /*
            if (Vector2.Distance(transform.position, target.position) >= 4.5 || touchPlayer == true)
            {
                aggro = false;
                if (rb.bodyType != RigidbodyType2D.Static)
                {
                    rb.velocity = Vector2.zero;
                }
            }
            */
        }
    }
}
