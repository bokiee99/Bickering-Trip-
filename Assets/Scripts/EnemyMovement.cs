using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Vector2 moveSpeed = new Vector2(5f, 0f);
    public float moveTime = 0f;
    public float startTime = 0f;
    Rigidbody2D myRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = moveSpeed;
        moveTime -= Time.deltaTime;
        if (moveTime <= 0)
        {
            moveSpeed = -moveSpeed;
            FlipEnemyFacing();
            moveTime = startTime;
        }
    }


    void FlipEnemyFacing()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody.velocity.x)), 1f);
    }
}
