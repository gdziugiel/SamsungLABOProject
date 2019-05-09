using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Cube : MonoBehaviour {
    public float spinForce;
    private Vector3 cubePosition;
    private Vector3 cubeScale;
    private float xposition;
    private float yposition;
    private float zposition;
    private float xscale;
    private float yscale;
    private float zscale;
    public GameObject Player;
    bool _isPlayerOnTrigger;
    // Use this for initialization
    void Start () {
        xposition = Player.transform.position.x;
        //xposition = Random.Range(-3, 3);
        yposition = Random.Range(1, 3);
        zposition = 10;
        xscale = Random.Range(1, 5);
        yscale = Random.Range(1, 5);
        zscale = Random.Range(1, 5);
        cubePosition = new Vector3(xposition, yposition, zposition);
        transform.position = cubePosition;
        cubeScale = new Vector3(xscale, yscale, zscale);
        transform.localScale = cubeScale;
        _isPlayerOnTrigger = false;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, 0, -spinForce * Time.deltaTime);
        zposition = transform.position.z;
        if(zposition < Player.transform.position.z)
        {
            if (!_isPlayerOnTrigger)
            {
                GameLogic.points++;
                _isPlayerOnTrigger = false;
                Debug.Log(GameLogic.points);
                spinForce += 0.1f;
                xposition = Player.transform.position.x;
                //xposition = Random.Range(-3, 3);
                yposition = Random.Range(1, 3);
                xscale = Random.Range(1, 5);
                yscale = Random.Range(1, 5);
                zscale = Random.Range(1, 5);
                cubePosition.x = xposition;
                cubePosition.y = yposition;
                transform.position = cubePosition;
                cubeScale.x = xscale;
                cubeScale.y = yscale;
                cubeScale.z = zscale;
                transform.localScale = cubeScale;
            }
            else
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("ok");
            _isPlayerOnTrigger = true;
        }
    }
}
