using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_movement : MonoBehaviour {
    public float currentHealth;
    public float maxHealth;
    public float speed;
    public GameObject smallrat;
    private Animator animator;
    private Transform target;
    private Rigidbody2D rb;

    public bool aggro;
    //private PolygonCollider2D polygonCol2D;
   
    // Use this for initialization
    void Start () {
        this.currentHealth = this.maxHealth;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        //polygonCol2D = GetComponent<PolygonCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        //Player = GameObject.FindWithTag("Player");
        smallrat = GameObject.FindWithTag("Enemy");

    }
	
	// Update is called once per frame
	void Update () {
        MoveEnemy();
        //animator.SetBool("SmallRat", true);


    }
    public void takeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth<=0)
        {
            death();
        }
    }

    public void death()
    {
        Destroy(gameObject);
    }

    
    public void MoveEnemy()
    {
        if(aggro==false)
        {
            if (Vector2.Distance(transform.position,target.position)<=2)
            {
                aggro = true;
            }
            
        }

        if (aggro == true)
        {
            Vector2 direction = target.position - transform.position;
            Vector2 newvector = direction.normalized * speed *Time.deltaTime;
            rb.velocity = newvector;
            //Vector3 vect = Vector3.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
            //transform.Translate(vect.x * speed * Time.deltaTime, vect.y * speed * Time.deltaTime, 0f);
            if (Vector2.Distance(transform.position, target.position) >= 4.5)
            {
                aggro = false;
            }
            
        }
        
        

    }



}
