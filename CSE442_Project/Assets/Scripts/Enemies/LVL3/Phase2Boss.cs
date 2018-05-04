using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase2Boss : MonoBehaviour
{
    public GameObject Arena;
    public GameObject portal;
    public GameObject summon;
    public GameObject Phase2;
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
    private int splitPhaseFlag;
    public bool aggro;
    public GameObject[] LeftSpike;
    public GameObject[] RightSpike;
    public GameObject[] CenterSpike;

    public bool touchPlayer;
    public bool touchWeapon;
    public Vector3 BHellStart;
    public Vector3 BHellStart2;
    public Vector3 BHellStart3;
    public float timeCount;
    private float growTree;
    public int cycles = 0;
    public int cycles2 = 0;
    public int cycles3 = 0;

    public Vector3 OffsetPosition;
    private bool secondwave = false;
    private bool thridwave = false;

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
        
        growTree = .4f;
        timeCount = 1f;
        SpriteR = GetComponent<SpriteRenderer>();
        red = 255f;
        blue = 255f;
        green = 255f;
        //mColor = new Color(red, green, blue);
        _gm = GameManager.Instance;
        attackS = false;
        countAtt = 0;
        splitPhaseFlag = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (_gm.gameState == GameState.Game)
        {

            MoveEnemy();
           
            Splitphase();
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
        if (gameObject.name == "bossphase2")
        {
            portal.SetActive(true);
            _gm.UpdateScore(450);
            Arena.SetActive(false);
        }
        //_gm.LivesDecrease(1);
        Player.SendMessage("addKill");
        Destroy(gameObject);

    }



    private void Splitphase()
    {
        if (splitPhaseFlag == 1)
        {
            Arena.SetActive(true);
            growTree -= Time.deltaTime;
            if(growTree<=0)
            {
                transform.Rotate(Vector3.right, 2f);
                if(transform.rotation.x>=0f)
                {
                    splitPhaseFlag = 0;
                }
                growTree = .1f;
            }
        }
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Arena.SetActive(true);
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

   



    
    public void onAggro()
    {
        aggro = true;
    }
    public void MoveEnemy()
    {

        if (aggro == false && target != null)
        {
            if (Door == null && Vector2.Distance(transform.position, target.position) <= 5.5)
            {
                aggro = true;
            }

        }
        if (aggro == true && target != null)
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
                    BHellStart = new Vector3(-11.49f, BHellStart.y + 1, 0f);
                    for (int i=0; i<LeftSpike.Length; i++)
                    {
                        GameObject hell=Instantiate(LeftSpike[i], BHellStart, Quaternion.identity)as GameObject;
                        BHellStart = new Vector3(BHellStart.x + 1f, BHellStart.y, BHellStart.z);
                        Destroy(hell, 1f);
                    }
                    cycles++;
                    if(cycles>=13)
                    {
                        cycles = 0;
                        BHellStart = new Vector3(-11.49f, -29.49f, 0f);
                    }

                    if(cycles==10)
                    {
                        secondwave = true;   
                    }
                    if(cycles2==10)
                    {
                        thridwave = true;
                    }
                    if(secondwave==true)
                    {
                        BHellStart2 = new Vector3(-11.49f, BHellStart2.y + 1, 0f);
                        for (int i = 0; i < RightSpike.Length; i++)
                        {
                            GameObject hell = Instantiate(RightSpike[i], BHellStart2, Quaternion.identity) as GameObject;
                            BHellStart2 = new Vector3(BHellStart2.x + 1f, BHellStart2.y, BHellStart2.z);
                            Destroy(hell, 1f);
                        }
                        cycles2++;
                    }
                    if (cycles2 >= 13)
                    {
                        cycles2 = 0;
                        BHellStart2 = new Vector3(-11.49f, -29.49f, 0f);
                    }
                    if (thridwave==true)
                    {
                        BHellStart3 = new Vector3(-11.49f, BHellStart3.y + 1, 0f);
                        for (int i = 0; i < LeftSpike.Length; i++)
                        {
                            GameObject hell = Instantiate(LeftSpike[i], BHellStart3, Quaternion.identity) as GameObject;
                            BHellStart3 = new Vector3(BHellStart3.x + 1f, BHellStart3.y, BHellStart3.z);
                            Destroy(hell, 1f);
                        }
                        cycles3++;
                    }
                    if (cycles3 >= 13)
                    {
                        cycles3 = 0;
                        BHellStart3 = new Vector3(-11.49f, -29.49f, 0f);
                    }


                }
                if (countAtt == 3)
                {
                    BHellStart = new Vector3(-11.49f, BHellStart.y+1, 0f);
                    for (int i = 0; i < RightSpike.Length; i++)
                    {
                        GameObject hell = Instantiate(RightSpike[i], BHellStart, Quaternion.identity) as GameObject;
                        BHellStart = new Vector3(BHellStart.x + 1f, BHellStart.y, BHellStart.z);
                        Destroy(hell, 1f);
                    }
                    cycles++;
                    if (cycles >= 13)
                    {
                        cycles = 0;
                        BHellStart = new Vector3(-11.49f, -29.49f, 0f);
                    }
                    
                    if (cycles3 >= 13)
                    {
                        cycles3 = 0;
                        BHellStart3 = new Vector3(-11.49f, -29.49f, 0f);
                    }
                    if (cycles == 10)
                    {
                        secondwave = true;

                    }
                    if (cycles2 == 10)
                    {
                        thridwave = true;

                    }
                    if (secondwave == true)
                    {
                        BHellStart2 = new Vector3(-11.49f, BHellStart2.y + 1, 0f);
                        for (int i = 0; i < LeftSpike.Length; i++)
                        {
                            GameObject hell = Instantiate(LeftSpike[i], BHellStart2, Quaternion.identity) as GameObject;
                            BHellStart2 = new Vector3(BHellStart2.x + 1f, BHellStart2.y, BHellStart2.z);
                            Destroy(hell, 1f);
                        }
                        cycles2++;
                    }
                    if (cycles2 >= 13)
                    {
                        cycles2 = 0;
                        BHellStart2 = new Vector3(-11.49f, -29.49f, 0f);
                    }
                    if (thridwave == true)
                    {
                        BHellStart3 = new Vector3(-11.49f, BHellStart3.y + 1, 0f);
                        for (int i = 0; i < RightSpike.Length; i++)
                        {
                            GameObject hell = Instantiate(RightSpike[i], BHellStart3, Quaternion.identity) as GameObject;
                            BHellStart3 = new Vector3(BHellStart3.x + 1f, BHellStart3.y, BHellStart3.z);
                            Destroy(hell, 1f);
                        }
                        cycles3++;
                    }


                    //Instantiate(summon, Player.transform + OffsetPosition, Quaternion.identity);
                }
                if(countAtt==4)
                {
                    countAtt = 0;
                }
            }



        }
        if (target != null && Vector2.Distance(transform.position, target.position) >= 20.5)
        {
            aggro = false;
        }
    }
}
