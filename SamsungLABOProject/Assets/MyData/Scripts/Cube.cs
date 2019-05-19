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
    public Texture[] textures;
    public int currentTexture;
    Renderer rend;
    // Use this for initialization
    void Start () {
        xposition = Player.transform.position.x;
        //xposition = Random.Range(-3, 3);
        yposition = Player.transform.position.y - 1.5f + Random.Range(1, 3);
        zposition = Player.transform.position.z + 10;
        xscale = Random.Range(1, 4);
        yscale = Random.Range(1, 4);
        zscale = Random.Range(1, 4);
        cubePosition = new Vector3(xposition, yposition, zposition);
        transform.position = cubePosition;
        cubeScale = new Vector3(xscale, yscale, zscale);
        transform.localScale = cubeScale;
        _isPlayerOnTrigger = false;
        rend = GetComponent<Renderer>();
        currentTexture = Random.Range(0, 3);
        rend.material.mainTexture = textures[currentTexture];
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
                spinForce += 0.2f;
                xposition = Player.transform.position.x;
                //xposition = Random.Range(-3, 3);
                yposition = Random.Range(1, 3);
                xscale = Random.Range(1, 4);
                yscale = Random.Range(1, 4);
                zscale = Random.Range(1, 4);
                cubePosition.x = xposition;
                cubePosition.y = yposition;
                transform.position = cubePosition;
                cubeScale.x = xscale;
                cubeScale.y = yscale;
                cubeScale.z = zscale;
                transform.localScale = cubeScale;
                currentTexture = Random.Range(0, 3);
                rend.material.mainTexture = textures[currentTexture];
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
