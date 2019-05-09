using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuLogic : MonoBehaviour {
    float time;
    public static int points;
    public Text pointsText;
    // Use this for initialization
    void Start()
    {
        time = 0;
        points = GameLogic.points;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        pointsText.text = points.ToString("0");
    }
}
