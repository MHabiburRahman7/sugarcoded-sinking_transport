using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyShipCtrl : MonoBehaviour
{
    public Slider slider_notice_level;
    public int notice_level;

    public Transform front_trans;
    public float accelSpeed, turningspeed;
    public float maxSpeed;

    public List<Transform> patrol_checkpoint;
    private int checkpoint_itt = 0; 

    private bool isMovingForward = false;
    private bool isAccelerate = false;
    private bool detectPlayer = false;

    private Rigidbody m_rigid;

    // Start is called before the first frame update
    void Start()
    {
        m_rigid = GetComponent<Rigidbody>();
        slider_notice_level.maxValue = 100;
        slider_notice_level.minValue = 0;
    }

    private void Awake()
    {
        detectPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckMeter();
        PatrolMovement();
    }

    void PatrolMovement()
    {
        if(transform.position != patrol_checkpoint[checkpoint_itt].transform.position)
        {
            float step = maxSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, patrol_checkpoint[checkpoint_itt].position, step);
        }
        else
        {
            checkpoint_itt++;
            checkpoint_itt %= patrol_checkpoint.Count;
        }
    }

    void CheckMeter()
    {
        if (detectPlayer && notice_level <= 100)
            notice_level++;
        else if (!detectPlayer && notice_level >= 0)
            notice_level--;
        
        //update the scrollrect
        if(notice_level > 0)
        {
            slider_notice_level.gameObject.SetActive(true);
        }
        else
        {
            slider_notice_level.gameObject.SetActive(false);
        }

        slider_notice_level.value = notice_level;

        //detectPlayer = false;
        //Invoke("playerIsMissing", 2f);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<shipBasicMove>().isOnSurface)
                detectPlayer = true;
            else
                detectPlayer = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            detectPlayer = false;
        }
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    if(collision.gameObject.tag == "Player")
    //    {
    //        detectPlayer = true;
    //    }
    //}
}
