using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float rayLength;
	Ray ray;
	public float offset;
	RaycastHit hit;
	public Camera cam;
	public LayerMask mask;
	public Transform[] portals;
	public float angleBetweenTarget;
	public float angleBetweenPlayer;

	void Update()
	{
		ray = cam.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2, 0));
//		if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
		if(Physics.Raycast(ray, out hit, Mathf.Infinity,mask))
		{
			Debug.DrawRay (cam.ScreenToWorldPoint (new Vector3 (Screen.width / 2, Screen.height / 2, 0)), ray.direction * hit.distance, Color.white);
			Debug.DrawRay (hit.point, hit.normal * 10f, Color.black);
			Debug.DrawRay (portals[0].GetChild(0).position, portals[0].GetChild(0).forward * 10f, Color.red);

			if(Input.GetMouseButton(0) || Input.GetMouseButton(1))
			{
				int currentIndex = Input.GetMouseButton (0) ? 0 : 1;
//				float offset = currentIndex == 0 ? 0.2f : 1f;

				portals[currentIndex].position = new Vector3(hit.point.x, hit.point.y+offset, hit.point.z);
				Quaternion angleToSurface = Quaternion.LookRotation (hit.normal);
				portals [currentIndex].rotation = angleToSurface;
			}

			if(Input.GetKeyDown(KeyCode.R))
			{
				portals [0].GetComponent<LookAt> ().placed = false;

			}
			offset += Input.GetAxis ("Mouse ScrollWheel");
		}
		else
		{
			Debug.DrawRay (transform.position, transform.TransformDirection(Vector3.forward) * 1000f, Color.white);
		}
		Debug.DrawRay (portals[0].GetChild(0).position, portals[0].GetChild(0).forward * 10f, Color.red);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Portals")) {
			transform.position = portals [1].position;
		}

		Debug.Log (other.tag);
	}
}
