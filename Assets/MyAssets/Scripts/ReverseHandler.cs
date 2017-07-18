using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter(Collider col)
	{
		Rigidbody colRigidbody = col.GetComponent<Rigidbody>();
        colRigidbody.velocity = -0.7f * colRigidbody.velocity;
	}
}
