using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float rayLength;
	Ray ray;
	RaycastHit hit;
	public Camera cam;
	public LayerMask mask;
	public Transform[] portals;

	void Update()
	{
		ray = cam.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2, 0));
//		if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
		if(Physics.Raycast(ray, out hit, Mathf.Infinity,mask))
		{
			Debug.DrawRay (cam.ScreenToWorldPoint(new Vector3 (Screen.width / 2, Screen.height / 2, 0)), ray.direction * hit.distance, Color.white);
			Debug.Log (hit.transform.name);
			Debug.DrawRay (hit.point, hit.normal * 20f, Color.black);

			if(Input.GetMouseButton(0) || Input.GetMouseButton(1))
			{
				int currentIndex = Input.GetMouseButton (0) ? 0 : 1;
				portals[currentIndex].position = new Vector3(hit.point.x, hit.point.y + 1f, hit.point.z);
			}
		}
		else{
			Debug.DrawRay (transform.position, transform.TransformDirection(Vector3.forward) * 1000f, Color.white);
		}

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Portals")) {
			transform.position = portals [1].position;
		}
	}
}
