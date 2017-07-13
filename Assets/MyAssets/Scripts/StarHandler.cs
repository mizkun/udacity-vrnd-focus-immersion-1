using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarHandler : MonoBehaviour {
    public GameObject[] Stars;
    int score;

	// Use this for initialization
	void Start () {
        score = 0;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ReStart ()
    {
        foreach (GameObject star in Stars)
        {
            star.SetActive(true);
        }
        score = 0;
    }

    public void AddScore () 
    {
        score++;
        Debug.Log(score);
    }

    public bool IsCompleted () 
    {
        return score == Stars.Length;
    }


}
