using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSpector : MonoBehaviour
{
    public GameObject projectile;
    public float currentHealth;
    public float maxHealth;
    public float speed;
    public GameObject CloseEmeny;
    private GameObject Player;
    public GameObject[] Waypoints;
    public bool[] WaypointFlag;
    private Animator animator;
    private Transform target;
    private Rigidbody2D rb;
    private SpriteRenderer SpriteR;
    private bool attackS;
    private int countAtt;
    private float red;
    private float green;
    private float blue;
    //private Color mColor; Getting errors because of not being used
    public bool aggro;
    //private PolygonCollider2D polygonCol2D; Getting errors because of not being used
    public bool touchPlayer;
    public bool touchWeapon;
    //private PolygonCollider2D playerColl; Getting errors because of not being used
    public float timeCount;
    private int pick=-1;
    public Vector3 OffsetPosition = new Vector3(.1f,0, 0);


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

        //playerColl = GetComponent<PolygonCollider2D>();
        timeCount = .5f;
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
            //animator.SetBool("SmallRat", true);
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
        _gm.UpdateScore(10);
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
            touchPlayer = true;
            //coll.rigidbody.isKinematic = true;
            //rb.velocity = Vector2.zero;
            //rb.bodyType= RigidbodyType2D.Static;
            rb.velocity = Vector2.zero;
            Player.SendMessage("zeroVel");


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
        Player.SendMessage("zeroVel");
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
            if (Vector2.Distance(transform.position, target.position) <= 4)
            {
                aggro = true;
                if (CloseEmeny != null)
                {
                    CloseEmeny.SendMessage("onAggro");
                }


            }
        }



        if (aggro == true && target != null)
        {
            
            if(pick==-1|| Vector2.Distance(transform.position, Waypoints[pick].transform.position)<=.2)
            {
                for (int i = 0; i <= Waypoints.Length - 1; i++)
                {
                    GameObject bullet = Instantiate(projectile, transform.position+OffsetPosition, Quaternion.identity) as GameObject;
                    //bullet.SendMessage("targetLoc");
                    float Way_Player = Vector2.Distance(target.position, Waypoints[i].transform.position);
                    float Way_Spec = Vector2.Distance(transform.position, Waypoints[i].transform.position);
                    if (Way_Player <= Way_Spec)
                    {
                        WaypointFlag[i] = false;
                        if(Vector2.Distance(target.position, transform.position)<=2)
                        {
                            WaypointFlag[i] = true;
                        }
                    }
                    else
                    {

                        WaypointFlag[i] = true;
                        if(Way_Spec <= .2)
                        {
                            WaypointFlag[i] = false;
                        }
                    }
                }
                bool done = false;
                bool check = false;
                int count = 0;
                for (int i = 0; i <= WaypointFlag.Length - 1; i++)
                {
                    if(WaypointFlag[i]==false)
                    {
                        count++;
                    }
                }
                if(count==4)
                {
                    check = true;
                }

                    while (done != true)
                {
                    pick = Random.Range(0, 4);

                    if (WaypointFlag[pick] == true||check==true)
                    {
                        done = true;
                    }
                }
            }
           



            Vector2 direction = Waypoints[pick].transform.position - transform.position;
            Vector2 newvector = direction.normalized * speed * Time.deltaTime;

            if (rb.bodyType != RigidbodyType2D.Static)
            {
                rb.velocity = newvector;
            }
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
