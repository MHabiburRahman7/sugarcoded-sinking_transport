using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommand : MonoBehaviour
{
    public float speed;
    public float direction;
    public bool isOnSurface;

    private void Update()
    {
        //direction should be 
        direction %= 360;
    }

}
