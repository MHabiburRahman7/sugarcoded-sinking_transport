using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCommand : MonoBehaviour
{
    public InputField directionField;
    public Scrollbar speed_ctrl;
    public Toggle isDivingToggle, isFollowing;
    public CameraFollow m_camFollow;
    public float speed;
    public float direction;
    public bool isOnSurface;

    private void Start()
    {
        speed_ctrl.onValueChanged.AddListener((float val) => SpeedTranslate(val));
        isDivingToggle.onValueChanged.AddListener((bool ans) => checkDiving(ans));
        directionField.onValueChanged.AddListener((string ans) => updateDirection(ans));
        isFollowing.onValueChanged.AddListener((bool ans) => chnageFollowToggle(ans));
    }
    private void Update()
    {
        //direction should be 
        //direction %= 360;
    }

    public void SpeedTranslate(float val)
    {
        //if(speed_ctrl.onValueChanged())
        if (val == 0f)
        {
            speed = 20f;
        }
        else if (val == 0.25f)
        {
            speed = 10f;
        }
        else if (val == 0.5f)
        {
            speed = 0f;
        }
        else if (val == 0.75f)
        {
            speed = -10f;
        }
        else if (val == 1f)
        {
            speed = -20f;
        }
    }

    public void checkDiving(bool ans)
    {
        isOnSurface = !ans;
    }

    public void updateDirection(string theAnswer)
    {
        if(theAnswer != null)
        {
            direction = int.Parse(theAnswer);
            direction %= 360;
        }
    }

    public void chnageFollowToggle(bool ans)
    {
        m_camFollow.isFollowing = ans;
    }
}
