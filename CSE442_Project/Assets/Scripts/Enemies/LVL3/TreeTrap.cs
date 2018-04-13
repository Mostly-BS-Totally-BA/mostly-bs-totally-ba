using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TreeTrap : MonoBehaviour
{
    private Transform target;
    private GameObject Player;
    private GameManager _gm;
    public float speed;
    private Rigidbody2D rb;
    private Vector2 newvector;
    private Vector2 direction;
    private float timeCount;
    private bool coolDownAttack;
    private bool created;
    private bool firstHit;
    private int destroyTime=0;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Player = GameObject.FindWithTag("Player");
        _gm = GameManager.Instance;
        
        timeCount = .1f;
        coolDownAttack = false;
        created = false;
        firstHit = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (_gm.gameState == GameState.Game)
        {
            attack();
        }



    }

    public void targetLoc()
    {
        direction = target.position - transform.position;
        newvector = direction.normalized * speed * Time.deltaTime;
        rb.velocity = newvector;
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (created == true)
        {
            //Debug.Log("Collision Detected " + coll.gameObject.name);
            if (coll.gameObject.tag == "Player")
            {

                //coll.rigidbody.isKinematic = true;
                //rb.velocity = Vector2.zero;
                //rb.bodyType= RigidbodyType2D.Static;
                if (firstHit == false)
                {
                    Player.SendMessage("takeDamage", 1);
                    firstHit = true;
                }

                
                delete();



            }
            

        }

        //Destroy(gameObject);
        //coll.gameObject.SendMessage("ApplyDamage", 10);

    }
    public void delete()
    {
        Destroy(gameObject);
    }
    public void attack()
    {

        timeCount -= Time.deltaTime;
        //Debug.Log("time: " + timeCount);
        if (timeCount <= 0)
        {
            if(destroyTime==10)
            {
                delete();
            }
            if (coolDownAttack == false)
            {

                timeCount = .1f;

                //coolDownAttack++;
                if (target != null)
                {
                    //Player.SendMessage("takeDamage", 10);
                    
                    coolDownAttack = true;
                    created = true;


                }
            }
            else
            {
                destroyTime++;
                timeCount = .1f;

            }
        }
    }
}
