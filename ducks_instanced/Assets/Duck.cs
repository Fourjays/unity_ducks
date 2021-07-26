using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    [SerializeField]
    private float moveDelay = 1f;

    private float timeSinceMove = 0f;

    private int nextDirection = 0;

    private int nextLength = 0;
    
    private int lengthMoved = 0;


    void Start()
    {
        ChooseDirection();
        ChooseLength();
    }


    void Update()
    {
        timeSinceMove += Time.deltaTime;

        if (timeSinceMove > moveDelay) {
            timeSinceMove = 0;

            Vector2 velocity = Vector2.zero;

            if (nextDirection >= 0 && nextDirection < 25) {
                velocity.y += 1;
            }
            if (nextDirection >= 25 && nextDirection < 50) {
                velocity.y -= 1;
            }
            if (nextDirection >= 50 && nextDirection < 75) {
                velocity.x += 1;
            }
            if (nextDirection >= 75 && nextDirection < 100) {
                velocity.x -= 1;
            }

            if (velocity != Vector2.zero) {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, velocity, velocity.magnitude);

                //Debug.Log("Raycast from " + transform.position + " in direction "+ velocity + " with length " + velocity.magnitude + " hitting " + hit.collider);
                //Debug.DrawRay(transform.position, velocity, Color.cyan, 10f, false);

                if (hit.collider == null) {
                    transform.Translate(velocity, Space.World);
                    lengthMoved += 1;
                }
                else
                {
                    ChooseDirection();
                }
            }

            if (lengthMoved > nextLength)
            {
                ChooseDirection();
                ChooseLength();
            }
        }


    }


    public void ChooseDirection()
	{
        nextDirection = Random.Range(0, 100);
	}


    public void ChooseLength()
	{
        nextLength = Random.Range(0, 40);
	}
}
