using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionDetectionScript : MonoBehaviour
{

    public GameObject Plane1;
    public GameObject Plane2;
    public GameObject Plane3;
    public GameObject Plane4;
    public GameObject Plane5;
    public GameObject Plane6;
    public GameObject Plane7;
    public GameObject Plane8;
    public GameObject Plane9;


    public GameObject MainCamera;

    private Vector3 _lastTransform;

    private Vector3 beginingPosition;

    public Text tex;

	// Use this for initialization
	void Start () {
		_lastTransform = new Vector3(0,0,0);


        beginingPosition = MainCamera.transform.position;

    }
	
	// Update is called once per frame
	void Update () {
	    Vector3 [] currentTransforms = new Vector3[9];
        bool [] flags = new bool[9];


            if (Plane1.GetComponent<Renderer>().enabled)
            {
                currentTransforms[0] -= _lastTransform;
                Vector3 localCoord = Plane1.transform.InverseTransformPoint(transform.position);
                currentTransforms[0] += localCoord;
                flags[0] = true;
            }
            else
            {
                flags[0] = false;
            }

            if (Plane2.GetComponent<Renderer>().enabled)
            {
                currentTransforms[1] -= _lastTransform;
                Vector3 localCoord = Plane2.transform.InverseTransformPoint(transform.position);
                currentTransforms[1] += localCoord;
                flags[1] = true;
            }
            else
            {
                flags[1] = false;
            }

            if (Plane3.GetComponent<Renderer>().enabled)
            {
                currentTransforms[2] -= _lastTransform;
                Vector3 localCoord = Plane3.transform.InverseTransformPoint(transform.position);
                currentTransforms[2] += localCoord;
                flags[2] = true;
            }
            else
            {
                flags[2] = false;
            }

            if (Plane4.GetComponent<Renderer>().enabled)
            {
                currentTransforms[3] -= _lastTransform;
                Vector3 localCoord = Plane4.transform.InverseTransformPoint(transform.position);
                currentTransforms[3] += localCoord;
                flags[3] = true;
            }
            else
            {
                flags[3] = false;
            }

            if (Plane5.GetComponent<Renderer>().enabled)
            {
                currentTransforms[4] -= _lastTransform;
                Vector3 localCoord = Plane5.transform.InverseTransformPoint(transform.position);
                currentTransforms[4] += localCoord;
                flags[4] = true;
            }
            else
            {
                flags[4] = false;
            }

            if (Plane6.GetComponent<Renderer>().enabled)
            {
                currentTransforms[5] -= _lastTransform;
                Vector3 localCoord = Plane6.transform.InverseTransformPoint(transform.position);
                currentTransforms[5] += localCoord;
                flags[5] = true;
            }
            else
            {
                flags[5] = false;
            }

            if (Plane7.GetComponent<Renderer>().enabled)
            {
                currentTransforms[6] -= _lastTransform;
                Vector3 localCoord = Plane7.transform.InverseTransformPoint(transform.position);
                currentTransforms[6] += localCoord;
                flags[6] = true;
            }
            else
            {
                flags[6] = false;
            }

            if (Plane8.GetComponent<Renderer>().enabled)
            {
                currentTransforms[7] -= _lastTransform;
                Vector3 localCoord = Plane8.transform.InverseTransformPoint(transform.position);
                currentTransforms[7] += localCoord;
                flags[7] = true;
            }
            else
            {
                flags[7] = false;
            }

            if (Plane9.GetComponent<Renderer>().enabled)
            {
                currentTransforms[8] -= _lastTransform;
                Vector3 localCoord = Plane9.transform.InverseTransformPoint(transform.position);
                currentTransforms[8] += localCoord;
                flags[8] = true;
            }
            else
            {
                flags[8] = false;
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
	        MainCamera.transform.position = beginingPosition + currentTransforms[minMagnitudeIndex] + _lastTransform;
	        _lastTransform = currentTransforms[minMagnitudeIndex] + _lastTransform;
	    }

        tex.text = MainCamera.transform.position.ToString("0");

    }
}
