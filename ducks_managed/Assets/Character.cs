using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    void Update()
    {
        Vector2 velocity = Vector2.zero;

        if (Input.GetKeyUp(KeyCode.UpArrow)) {
            velocity.y += 1;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow)) {
            velocity.y -= 1;
        }
         if (Input.GetKeyUp(KeyCode.RightArrow)) {
            velocity.x += 1;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow)) {
            velocity.x -= 1;
        }

        if (velocity != Vector2.zero) {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, velocity, velocity.magnitude);

            //Debug.Log("Raycast from " + transform.position + " in direction "+ velocity + " with length " + velocity.magnitude + " hitting " + hit.collider);
            //Debug.DrawRay(transform.position, velocity, Color.cyan, 10f, false);

            if (hit.collider == null) {
                transform.Translate(velocity, Space.World);
            }
        }
    }
}
