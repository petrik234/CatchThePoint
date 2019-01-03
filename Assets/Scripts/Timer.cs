using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text RemainingTime;

    public double RemainingSec;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        RemainingSec -= Time.deltaTime;

        if (RemainingSec > 0)
        {
            RemainingTime.text = RemainingSec.ToString("0");
        }
        else
        {

            GameObject.FindGameObjectWithTag("Player").GetComponent<Score>().RefreshPoint();
            SceneManager.LoadScene(0);
        }
    }
}
