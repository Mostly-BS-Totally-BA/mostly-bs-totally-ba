using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trees : MonoBehaviour
{
    public GameObject portal;
    public GameObject summon;
    public GameObject summonCir;
    private GameObject sumCir;
    public GameObject Door;
    public float currentHealth;
    public float maxHealth;
    public float speed;
    public GameObject CloseEmeny;
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
    private float snapX;
    private float snapY;

    public bool aggro;

    public bool touchPlayer;
    public bool touchWeapon;

    public float timeCount;

    public Vector3 OffsetPosition;


    private GameManager _gm = null;

    // Use this for initialization
    void Start()
    {
        this.currentHealth = this.maxHealth;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Player = GameObject.FindWithTag("Player");

        
        rb = GetComponent<Rigidbody2D>();


        snapX = Player.transform.position.x;
        snapY = Player.transform.position.y;


        timeCount = 1f;
        SpriteR = GetComponent<SpriteRenderer>();
        red = 255f;
        blue = 255f;
        green = 255f;
        //mColor = new Color(red, green, blue);
        _gm = GameManager.Instance;
        attackS = false;
        countAtt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_gm.gameState == GameState.Game)
        {
            
            MoveEnemy();
            if (attackS == true)
            {
                attack();
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
        _gm.UpdateScore(50);
        if(gameObject.name == "boss")
        {
            portal.SetActive(true);
            _gm.UpdateScore(450);
        }
        //_gm.LivesDecrease(1);
        Player.SendMessage("addKill");
        Destroy(gameObject);

    }

    private void OnCollisionStay2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "Player")
        {
            rb.bodyType = RigidbodyType2D.Static;
            rb.velocity = Vector2.zero;

            //Invoke("colorChange", 1);
            //Invoke("defaultColor", 3);
            attackS = true;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            //touchPlayer = true;
            //coll.rigidbody.isKinematic = true;
            //rb.velocity = Vector2.zero;
            //rb.bodyType= RigidbodyType2D.Static;
            rb.velocity = Vector2.zero;


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
            countAtt++;
            if (countAtt == 2 && countAtt != 3)
            {
                Player.SendMessage("takeDamage", 1);
                
                //_gm.LivesDecrease(1);
            }
        }
        if (countAtt == 3)
        {
            //Player.SendMessage("takeDamage", 10);
            this.SpriteR.color = new Color(1, 1, 1);
            blue = 255;
            green = 255;
            countAtt = 0;
        }



    }
    public void onAggro()
    {
        aggro = true;
    }
    public void MoveEnemy()
    {

        if (aggro == false && target != null)
        {
            if (Door == null && Vector2.Distance(transform.position, target.position) <= 3.5)
            {
                aggro = true;
            }
            
        }
        if(aggro==true && target != null)
        {
            
            timeCount -= Time.deltaTime;
            if (timeCount <= 0)
            {
                
                countAtt++;
                timeCount = .5f;
                if (countAtt == 1)
                {
                    float nowX = Player.transform.position.x;
                    float nowY = Player.transform.position.y;
                    float resultX = snapX - nowX;
                    float resultY = snapY - nowY;

                    if (resultY==0)
                    {
                        if (resultX < 0)
                        {
                            OffsetPosition = new Vector3(resultX + 3f, resultY, 0);
                        }
                        else if (resultX > 0)
                        {
                            OffsetPosition = new Vector3(resultX - 3f, resultY, 0);
                        }
                        else
                        {
                            OffsetPosition = new Vector3(resultX, resultY, 0);
                        }

                    }
                    if (resultX == 0)
                    {
                        if (resultY < 0)
                        {
                            OffsetPosition = new Vector3(resultX, resultY+3f, 0);
                        }
                        else if (resultY > 0)
                        {
                            OffsetPosition = new Vector3(resultX , resultY-3f, 0);
                        }
                        else
                        {
                            OffsetPosition = new Vector3(resultX, resultY, 0);
                        }

                    }
                    sumCir=Instantiate(summon, target.position + OffsetPosition, Quaternion.identity)as GameObject;
                    Destroy(sumCir, 1.5f);
                }
                if (countAtt == 3)
                {
                    GameObject trap=Instantiate(summonCir, target.position + OffsetPosition, Quaternion.identity) as GameObject;
                    
                    countAtt = 0;
                    snapX = Player.transform.position.x;
                    snapY = Player.transform.position.y;
                    Instantiate(summonCir, target.position + OffsetPosition, Quaternion.identity);
                    //Instantiate(summon, Player.transform + OffsetPosition, Quaternion.identity);
                }
            }
            


        }
        if(target != null&&Vector2.Distance(transform.position, target.position) >= 5.5)
        {
            aggro = false;
        }
    }
}
