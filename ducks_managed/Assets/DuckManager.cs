using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckManager : MonoBehaviour
{
    [SerializeField]
    private GameObject duck;

    [SerializeField]
    private Vector2[] spawnPoints;

    [SerializeField]
    private int totalDucks = 10;

    [SerializeField]
    private float moveDelay = 1f;

    private float timeSinceMove = 0f;

    private List<GameObject> allDucks = new List<GameObject>();

    void Start()
    {
        Application.targetFrameRate = 600;

        for (int i = 0; i <= totalDucks; i++) {
            Vector2 position = GetRandomSpawn();
            GameObject gameObject = Instantiate(duck, position, Quaternion.identity);

            gameObject.GetComponent<Duck>().nextDirection = ChooseDirection();
            gameObject.GetComponent<Duck>().nextLength = ChooseLength();

            allDucks.Add(gameObject);
        }
    }


    private Vector2 GetRandomSpawn()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        return spawnPoints[spawnIndex];
    }


    void Update()
    {
        timeSinceMove += Time.deltaTime;

        if (timeSinceMove > moveDelay)
        {
            timeSinceMove = 0;

            foreach (GameObject duck in allDucks)
			{
                MoveDuck(duck);
			}
        }
    }


    private void MoveDuck(GameObject gameObject)
	{
        Duck duck = gameObject.GetComponent<Duck>();
        Vector2 velocity = Vector2.zero;

        if (duck.nextDirection >= 0 && duck.nextDirection < 25)
        {
            velocity.y += 1;
        }
        if (duck.nextDirection >= 25 && duck.nextDirection < 50)
        {
            velocity.y -= 1;
        }
        if (duck.nextDirection >= 50 && duck.nextDirection < 75)
        {
            velocity.x += 1;
        }
        if (duck.nextDirection >= 75 && duck.nextDirection < 100)
        {
            velocity.x -= 1;
        }

        if (velocity != Vector2.zero)
        {
            RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, velocity, velocity.magnitude);

            //Debug.Log("Raycast from " + transform.position + " in direction "+ velocity + " with length " + velocity.magnitude + " hitting " + hit.collider);
            //Debug.DrawRay(gameObject.transform.position, velocity, Color.cyan, 10f, false);

            if (hit.collider == null)
            {
                gameObject.transform.Translate(velocity, Space.World);
                duck.lengthMoved += 1;
            }
            else
            {
                ChooseDirection();
            }
        }

        if (duck.lengthMoved > duck.nextLength)
        {
            duck.nextDirection = ChooseDirection();
            duck.nextLength = ChooseLength();
        }
    }


    public int ChooseDirection()
    {
        return Random.Range(0, 100);
    }


    public int ChooseLength()
    {
        return Random.Range(0, 40);
    }
}
