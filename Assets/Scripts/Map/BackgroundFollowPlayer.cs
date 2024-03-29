﻿using System.Collections;
using DG.Tweening;
using UnityEngine;

public class BackgroundFollowPlayer : MonoBehaviour {

	private Transform target;

	private CameraFollowPlayer cameraFollowPlayer;

	private PlayerController controller;
	// Start is called before the first frame update
	void Start() {
		target = GameObject.FindGameObjectWithTag("Player").transform;
		controller = target.GetComponent<PlayerController>();
		cameraFollowPlayer = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollowPlayer>();
	}

	// Update is called once per frame
	void Update() {
		if (cameraFollowPlayer.isMovingRight || cameraFollowPlayer.isMovingLeft) {
			transform.DOMoveX(transform.position.x + controller.velocity.x, 0.55f);
		}

	}
}
