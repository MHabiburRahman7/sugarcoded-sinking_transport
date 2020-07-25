using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipBasicMove : MonoBehaviour
{
    public PlayerCommand m_pCommand;
    public Transform front_trans;
    public float accelSpeed, turningspeed, dive_surface_speed;
    public bool isOnSurface = true;

    private bool isMovingForward = false;
    private bool isAccelerate = false;
    public float diving_meter;

    private Rigidbody m_rigid;
    // Start is called before the first frame update
    void Awake()
    {
        if (!m_rigid)
        {
            m_rigid = gameObject.GetComponent<Rigidbody>();
        }
    }

    private void FixedUpdate()
    {
        checkHeading();
        checkDiveOrSurface();

        if (m_pCommand.speed > 0)
        {
            Vector3 v3Force = accelSpeed * front_trans.transform.up;
            m_rigid.AddForce(v3Force);
            
            isMovingForward = true;
            isAccelerate = true;
        }else if(m_pCommand.speed < 0)
        {
            Vector3 v3Force = -accelSpeed * front_trans.transform.up;
            m_rigid.AddForce(v3Force);

            isMovingForward = false;
            isAccelerate = true;
        }
        else
        {
            //isMovingForward = false;
            isAccelerate = false;
        }

        if (m_rigid.velocity.magnitude > m_pCommand.speed)
            m_rigid.velocity = m_rigid.velocity.normalized * m_pCommand.speed;

    }

    void checkDiveOrSurface()
    {
        if(m_pCommand.isOnSurface != isOnSurface)
        {
            if (isOnSurface && diving_meter <= 100)
            {
                diving_meter++;
            }
            else if (diving_meter >= 100)
            {
                isOnSurface = false;
                Debug.Log("ship is diving");
            }
                

            if (!isOnSurface && diving_meter > -1)
            {
                diving_meter--;
            }else if(diving_meter <= 0)
            {
                isOnSurface = true;
                Debug.Log("ship is on surface");
            }
        }
    }

    void checkHeading()
    {
        //if not moving dont rotate
        //if (Mathf.FloorToInt(gameObject.transform.localEulerAngles.z) != m_pCommand.direction && isAccelerate)
        if (Mathf.FloorToInt(gameObject.transform.localEulerAngles.z) != m_pCommand.direction)
        {
            //decide to turn left or right --> dont know how, but it is working ._.
            float heading = gameObject.transform.localEulerAngles.z;
            float newHead = m_pCommand.direction;

            if (heading < newHead) heading += 360;
            float left = heading - newHead;

            if(left > 180)
            {
                float tiltAroundZ = turningspeed;
                transform.Rotate(0, 0, tiltAroundZ * Time.deltaTime, Space.World);
            }
            else
            {
                float tiltAroundZ = -turningspeed;
                transform.Rotate(0, 0, tiltAroundZ * Time.deltaTime, Space.World);
            }
        }
    }
}
