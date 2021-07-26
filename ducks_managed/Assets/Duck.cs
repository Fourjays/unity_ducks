using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    [HideInInspector]
    public int nextDirection = 0;

    [HideInInspector]
    public int nextLength = 0;
    
    [HideInInspector]
    public int lengthMoved = 0;
}
