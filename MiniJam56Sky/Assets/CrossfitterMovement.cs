using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossfitterMovement : MonoBehaviour
{
    bool movingRight = false; 
    private float fireTimer = 0f;
    [SerializeField] private float maxFireTime = 0.5f;
    
    public float speed;

    private bool active;
    EnemyAttack enemyAttack;
    Rigidbody2D rb2D;
    public enum State {forward, firing};
    State currentState;

    // Start is called before the first frame update
    void Start()
    {
        enemyAttack = GetComponent<EnemyAttack>();

        currentState = State.forward;
        rb2D = GetComponent<Rigidbody2D>();
        if(transform.position.x > Vector2.zero.x)
        {
            movingRight = false;
            Vector3 flipPlayerScale = transform.localScale;
            flipPlayerScale.x *= -1;
            transform.localScale = flipPlayerScale;
        }
        else if(transform.position.x < Vector2.zero.x)
        {
            movingRight = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
         Vector2 dir = new Vector2(0,0);
            if (movingRight)
            {
                dir = Vector2.right;
            }
               else if(!movingRight)
            {
                dir = Vector2.left;
            }

            rb2D.AddForce(dir * speed *Time.deltaTime);
        if (currentState == State.forward)
        {
           
            print(enemyAttack.target.name);
            print(Vector3.Distance(transform.position, enemyAttack.target.position));
            if (enemyAttack.target!=null && Vector3.Distance(transform.position, enemyAttack.target.position) <= 4.5f)
            {
                print("crossfitterfiring");
                fireTimer = 0;
                ChangeToFireState(State.firing);
            }
        }

        if(currentState == State.firing)
        {
           
            if(fireTimer < maxFireTime)
            {
                fireTimer += Time.deltaTime;
                enemyAttack.attack = true;
            }
            else if(fireTimer >= maxFireTime)
            {
                enemyAttack.attack = false;
                currentState = State.forward;
               
            }
        }

        
    }


   void ChangeToFireState(State nextState)
    {
        rb2D.velocity = Vector2.zero;
        currentState = nextState;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Base"))
        {
            print("CollidedWith Base");
            enemyAttack.target = collision.gameObject.transform;
         
        }
    }
}
