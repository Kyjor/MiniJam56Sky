using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    bool movingRight = false; 
    private float fireTimer = 0f;
    [SerializeField] private float maxFireTime = 0.5f;
    [SerializeField] private float initialFiringDistance;
    [SerializeField] private float maxForwardDuringFireState = 1f;
    [SerializeField] private float maxBackwardDistanceTravel = 5f;
    public float speed;

    private bool active;
    private GameObject[] tankTargets;
    Transform currentTarget;
    EnemyAttack enemyAttack;
    Rigidbody2D rb2D;
    public enum State {forward, backward, firing};
    State lastState;
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
        if (currentState == State.forward)
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
            if (enemyAttack.target!=null && Vector3.Distance(transform.position, enemyAttack.target.position) <= initialFiringDistance)
            {
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
                if(lastState == State.backward)
                {
                    currentState = State.forward;
                }
                else if (lastState == State.forward)
                {
                    currentState = State.backward;
                }
            }
        }

        if (currentState == State.backward)
        {
            print("backward");
            Vector2 dir = new Vector2(0, 0);
            if (movingRight)
            {
                dir = Vector2.left;
            }
            else if (!movingRight)
            {
                dir = Vector2.right;
            }

            rb2D.AddForce(dir * speed * Time.deltaTime);

            if (enemyAttack.target!= null && Vector3.Distance(transform.position, enemyAttack.target.position) >= initialFiringDistance+maxBackwardDistanceTravel)
            {
                fireTimer = 0;

                ChangeToFireState(State.firing);
            }
        }
    }


   void ChangeToFireState(State nextState)
    {
        rb2D.velocity = Vector2.zero;
        lastState = currentState;
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
            print("collide");
            enemyAttack.target = collision.gameObject.transform;
         
        }
    }
}
