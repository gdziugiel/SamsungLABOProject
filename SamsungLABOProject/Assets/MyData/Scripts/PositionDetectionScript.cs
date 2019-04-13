using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionDetectionScript : MonoBehaviour
{

    public GameObject Plane1;

    public GameObject MainCamera;

    private Vector3 _lastTransform;

	// Use this for initialization
	void Start () {
		_lastTransform = new Vector3(0,0,0);
	}
	
	// Update is called once per frame
	void Update () {
	    if (Plane1.GetComponent<Renderer>().enabled)
	    {
	        Vector3 currentTransform = new Vector3(0, 0, 0);
	        currentTransform -= _lastTransform;
	        _lastTransform = Plane1.transform.InverseTransformPoint(transform.position);
	        currentTransform += _lastTransform;
	        MainCamera.transform.position += currentTransform;
	    }
	}
}
