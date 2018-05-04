using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BHtrap : MonoBehaviour
{
    private Transform target;
    private GameObject Player;
    private GameManager _gm;
    private Rigidbody2D rb;
    private Vector2 newvector;
    private Vector2 direction;
    private float timeCount;
    private bool coolDownAttack;
    private bool created;
    private bool firstHit;
    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        _gm = GameManager.Instance;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {

            Player.SendMessage("takeDamage", 1);

        }
    }
}
