using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

	public Transform otherPortal;

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			other.transform.position = otherPortal.position + transform.forward * 2f;
			Debug.Log (transform.name + " Detected the player ");
		}
	}
}
