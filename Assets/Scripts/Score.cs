using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    public Text speedBoostText;

    public int points = 0;
    public float SpeedBoost;
    private PlayerMove pm;

    void Start()
    {
        pm = GetComponent(typeof(PlayerMove)) as PlayerMove;
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Score")
        {
            points++;
        }
        else if (collisionInfo.collider.tag == "Point")
        {
            points += 2;
            pm.moveSpeed += SpeedBoost;
            speedBoostText.text = "SPEED BOOST!";
            StartCoroutine(ExecuteAfterTime(3));
        }
        Refresh();
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        pm.moveSpeed -= SpeedBoost;
        speedBoostText.text = "";
    }

    public void Refresh()
    {
        scoreText.text = points.ToString();
    }
    
    public void RefreshPoint()
    {
        PlayerPrefs.SetInt("Point", points);
    }
}
