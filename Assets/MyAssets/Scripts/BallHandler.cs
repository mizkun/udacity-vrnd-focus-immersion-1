using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHandler : MonoBehaviour
{
    public StarHandler starHandler;
    public bool isInPlayArea;
    public Canvas alert;
    public GameObject startInstruction;
    public string NextScene;

    // Use this for initialization
    void Start()
    {
		isInPlayArea = true;
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
                SteamVR_LoadLevel.Begin(NextScene);
            }
            else 
            {
                ReStart();
            }
        }
        else if (col.gameObject.CompareTag("StartLevel"))
        {
            ReStart();
            startInstruction.SetActive(false);
        }
        else if (col.gameObject.CompareTag("PlayArea"))
        {
            isInPlayArea = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
		if (col.gameObject.CompareTag("PlayArea"))
		{
            isInPlayArea = false;
		}
    }

    public bool IsInPlayArea () 
    {
        return isInPlayArea;
    }

    public void ReStart () {
        transform.SetParent(null);
		transform.position = new Vector3(0, 1.15f, -2.6f);
		Rigidbody rigidBody = transform.GetComponent<Rigidbody>();
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
		rigidBody.isKinematic = false;
		starHandler.ReStart();
        isInPlayArea = true;
    }
}