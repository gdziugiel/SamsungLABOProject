using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{

    public GameObject Plane1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Plane1.GetComponent<Renderer>().enabled)
	        GetComponent<Renderer>().enabled = true;
	    else
	    {
	        GetComponent<Renderer>().enabled = false;
	    }
	}
}
