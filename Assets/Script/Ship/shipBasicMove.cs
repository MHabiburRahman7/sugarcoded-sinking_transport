using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipBasicMove : MonoBehaviour
{
    public PlayerCommand m_pCommand;
    public Transform front_trans;
    public float accelSpeed, turningspeed;

    private bool isMovingForward = false;
    private bool isAccelerate = false;

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
        
        if(m_pCommand.speed > 0)
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

    void checkHeading()
    {
        //if not moving dont rotate
        //if (Mathf.FloorToInt(gameObject.transform.localEulerAngles.z) != m_pCommand.direction && isAccelerate)
        if (Mathf.FloorToInt(gameObject.transform.localEulerAngles.z) != m_pCommand.direction)
        {
            //decide to turn left or right --> still not working
            float delta = Mathf.Abs(m_pCommand.direction - gameObject.transform.localEulerAngles.z);
            if (delta <= 180)
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

        //this.transform.localEulerAngles = new Vector3(0, 0, angle);
        //Debug.Log("this is heading: "+ gameObject.transform.localEulerAngles.z);
        //Debug.Log("this is player heading: " + m_pCommand.direction);
        //if ()
    }
}
