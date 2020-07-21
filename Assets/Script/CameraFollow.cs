﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform followTarget;
	public Vector3 targetPos;
	public float moveSpeed;

	public static bool cameraExist;

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
		targetPos = new Vector3(followTarget.position.x, followTarget.position.y, transform.position.z);
		transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
	}
}
