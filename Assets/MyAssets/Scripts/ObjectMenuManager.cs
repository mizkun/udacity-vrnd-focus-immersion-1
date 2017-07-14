using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ObjectMenuManager : MonoBehaviour {
    public List<GameObject> objectList;
    public List<GameObject> objectPrefabList;
    public List<int> objectLimits;
    public List<Text> lefts;
    public int currentObject = 0;

	// Use this for initialization
	void Start () {
        foreach (Transform child in transform)
        {
            objectList.Add(child.gameObject);
        }
        for (int i = 0; i < objectList.Count; i++)
        {
            lefts[i].text = objectLimits[i].ToString();
        }
    }
    public void MenuLeft()
    {
        if (HasObject())
        {
            objectList[currentObject].SetActive(false);
            do
            {
                currentObject--;
                if (currentObject < 0)
                {
                    currentObject = objectList.Count - 1;
                }
            }
            while (objectLimits[currentObject] == 0);
            objectList[currentObject].SetActive(true);
        }
    }

	public void MenuRight()
	{
        if (HasObject())
        {
			objectList[currentObject].SetActive(false);
			do
			{
				currentObject++;
				if (currentObject > objectList.Count - 1)
				{
					currentObject = 0;
				}
			}
			while (objectLimits[currentObject] == 0);
			objectList[currentObject].SetActive(true);
        }
	}
    public void SpawnCurrentObject()
    {
        if (objectLimits[currentObject] > 0) 
        {
			Instantiate(objectPrefabList[currentObject],
						objectList[currentObject].transform.position,
						objectList[currentObject].transform.rotation);
            objectLimits[currentObject]--;
            lefts[currentObject].text = objectLimits[currentObject].ToString();
		}    
	}
    public void SetActiveCurrentObject(bool active)
    {
        if (active)
        {
            if (objectLimits[currentObject] > 0)
            {
				objectList[currentObject].SetActive(active);
            }
            else if (HasObject())
            {
				do
				{
					currentObject++;
					if (currentObject > objectList.Count - 1)
					{
						currentObject = 0;
					}
				}
				while (objectLimits[currentObject] == 0);
				objectList[currentObject].SetActive(active);
            }
        }
        else
        {
            objectList[currentObject].SetActive(active);
        }
    }
    public bool HasObject () {
        return objectLimits.Sum() > 0;
    }
}
