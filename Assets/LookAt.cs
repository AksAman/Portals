using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

	public Transform player;
	public bool placed;

	void Start()
	{
		placed = false;
	}

	void Update()
	{
		if (!placed) {
			transform.LookAt (transform.position + player.transform.rotation * Vector3.forward, player.transform.rotation * Vector3.up);
		}
	}
}
