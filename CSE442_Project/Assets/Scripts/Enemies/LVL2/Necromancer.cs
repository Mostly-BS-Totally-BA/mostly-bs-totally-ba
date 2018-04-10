using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necromancer : MonoBehaviour
{
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

        //polygonCol2D = GetComponent<PolygonCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        //Player = GameObject.FindWithTag("Player");

        //playerColl = GetComponent<PolygonCollider2D>();
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
            if(Door==null&& Vector2.Distance(transform.position, target.position) <= 5.5)
            {
                aggro = true;
            }
            else if (Door.active==false)
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
            timeCount -= Time.deltaTime;
            //Debug.Log("time: " + timeCount);
            if (timeCount <= 0)
            {

                blue = blue - 85;
                red = red - 85;
                red = red / 255;
                blue = blue / 255;
                green = green / 255;
                this.SpriteR.color = new Color(red, green, blue);
                red = red * 255;
                blue = blue * 255;
                green = green * 255;

                timeCount = 1f;
                countAtt++;
                
            }
            if(countAtt==2)
            {
                
                this.SpriteR.color = new Color(.043f, .878f, .85f);
               
            }
            if(countAtt==3)
            {
                 sumCir = Instantiate(summonCir, transform.position+OffsetPosition, Quaternion.identity) as GameObject;
                this.SpriteR.color = new Color(1, 1, 1);
                Destroy(sumCir, 1);
            }
            if(countAtt==4)
            {
                this.SpriteR.color = new Color(.878f, .349f, .043f);
                
            }
            if (countAtt == 5)
            {
                //this.SpriteR.color = new Color(.878f, .349f, .043f);
                //Player.SendMessage("takeDamage", 10);
                GameObject zomb = Instantiate(summon,  transform.position+OffsetPosition, Quaternion.identity) as GameObject;
                //GameObject sumCir = Instantiate(summonCir, OffsetPosition, Quaternion.identity) as GameObject;
                zomb.SendMessage("onAggro");
                Destroy(sumCir);
                this.SpriteR.color = new Color(1, 1, 1);
                blue = 255;
                green = 255;
                countAtt = 0;
            }




        }
    }
}
