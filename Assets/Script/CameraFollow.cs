using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform followTarget;
	public Vector3 targetPos;
	public float moveSpeed;
	public bool isFollowing = true;

	public static bool cameraExist;

	private float zoom;

	// Use this for initialization
	void Start()
	{
		if (cameraExist)
		{
			Destroy(gameObject);
		}
		else
		{
			cameraExist = true;
			//DontDestroyOnLoad (transform.gameObject);
		}

		
	}

	// Update is called once per frame
	void Update()
	{
		if (isFollowing)
			HandleFollow();
		HandleDrag();
		HandleZoom();
	}

	void HandleZoom()
	{
		float zoomChangeAmount = 80f;
		if (Input.GetKey(KeyCode.KeypadPlus) || Input.mouseScrollDelta.y < 0)
		{
			//zoom -= zoomChangeAmount * Time.deltaTime;
			GetComponent<Camera>().fieldOfView--;
			//Debug.LogError("KeypadPlus");
		}
		if (Input.GetKey(KeyCode.KeypadMinus) || Input.mouseScrollDelta.y > 0)
		{
			//zoom += zoomChangeAmount * Time.deltaTime;
			GetComponent<Camera>().fieldOfView++;
		}
	}
	void HandleDrag()
	{
		//if (isFollowing)
		//	isFollowing = false;
	}

	void HandleFollow()
	{
		targetPos = new Vector3(followTarget.position.x, followTarget.position.y, transform.position.z);
		transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
	}
}
