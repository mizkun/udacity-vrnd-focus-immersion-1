using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerStay(Collider col)
	{
		Rigidbody colRigidbody = col.GetComponent<Rigidbody>();
        colRigidbody.AddForce(30.0f* transform.forward, ForceMode.Acceleration);
	}
}
