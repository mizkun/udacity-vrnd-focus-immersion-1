using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHandler : MonoBehaviour
{
    public StarHandler starHandler;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            ReStart();
        }
        else if (col.gameObject.CompareTag("Star"))
        {
            col.gameObject.SetActive(false);
            starHandler.AddScore();
        }
        else if (col.gameObject.CompareTag("Goal"))
        {
            if (starHandler.IsCompleted())
            {
                SteamVR_LoadLevel.Begin("ExampleScene");
            }
            else 
            {
                ReStart();
            }
        }
    }

    void ReStart () {
		transform.position = new Vector3(0, 1.15f, -2.6f);
		Rigidbody rigidBody = transform.GetComponent<Rigidbody>();
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
		rigidBody.isKinematic = false;
		starHandler.ReStart();
    }
}