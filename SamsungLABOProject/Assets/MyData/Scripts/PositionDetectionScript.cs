using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionDetectionScript : MonoBehaviour
{

    public GameObject Plane1;
    public GameObject Plane2;
    public GameObject Plane3;

    public GameObject MainCamera;

    private Vector3 _lastTransform;

	// Use this for initialization
	void Start () {
		_lastTransform = new Vector3(0,0,0);
	}
	
	// Update is called once per frame
	void Update () {
	    Vector3 [] currentTransforms = new Vector3[3];
        bool [] flags = new bool[3];

        if (Plane1.GetComponent<Renderer>().enabled)
	    {
            currentTransforms[0] -= _lastTransform;
	        currentTransforms[0] += Plane1.transform.InverseTransformPoint(transform.position);

	        flags[0] = true;
	    }
        else
        {
            flags[0] = false;
        }
        if (Plane2.GetComponent<Renderer>().enabled)
	    {        
	        currentTransforms[1] -= _lastTransform;
	        currentTransforms[1] += Plane2.transform.InverseTransformPoint(transform.position);

	        flags[1] = true;
	    }
        else
        {
            flags[1] = false;
        }
        if (Plane3.GetComponent<Renderer>().enabled)
	    {
	        currentTransforms[2] -= _lastTransform;
	        currentTransforms[2] += Plane3.transform.InverseTransformPoint(transform.position);

	        flags[2] = true;
	    }
        else
        {
            flags[2] = false;
        }

        float minMagnitude = float.NaN;
	    int minMagnitudeIndex = -1;
	    for (int i = 0; i < currentTransforms.Length; i++)
	    {
	        if (flags[i])
	        {
	            if (float.IsNaN(minMagnitude))
	            {
	                minMagnitude = currentTransforms[i].magnitude;
	                minMagnitudeIndex = i;
	            }
	            else if (currentTransforms[i].magnitude < minMagnitude)
	            {
	                minMagnitude = currentTransforms[i].magnitude;
	                minMagnitudeIndex = i;
	            }
	        }
	    }

	    if (minMagnitudeIndex != -1)
	    {
	        MainCamera.transform.position += currentTransforms[minMagnitudeIndex];
	        _lastTransform = currentTransforms[minMagnitudeIndex] + _lastTransform;
	    }

	}
}
