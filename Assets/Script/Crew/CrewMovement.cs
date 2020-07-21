using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CrewMovement : MonoBehaviour
{
    public AIPath m_aiPath;

    Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        faceVelocity();
    }

    void faceVelocity()
    {
        dir = m_aiPath.desiredVelocity;

        transform.right = dir;
    }
}
