using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawn : MonoBehaviour {

    public Transform CubePrefab;
    public Transform BonusSpeedPreafab;
       
    public double defaultCubeSpawnTime;
    public double defaultBonusSpeedSpawnTime;
    private double cubeCountDown;
    private double bonusSpeedCountDown;

    // Use this for initialization
    void Start () {
        cubeCountDown = defaultCubeSpawnTime;
        bonusSpeedCountDown = defaultBonusSpeedSpawnTime;
	}
	
	// Update is called once per frame
	void Update () {
        cubeCountDown -= Time.deltaTime;
        bonusSpeedCountDown -= Time.deltaTime;

        if (cubeCountDown <= 0)
        {
            SpawnCube();
            cubeCountDown = defaultCubeSpawnTime;
        }
        if (bonusSpeedCountDown <= 0)
        {
            SpawnBonusSpeed();
            bonusSpeedCountDown = defaultBonusSpeedSpawnTime;
        }
    }

    private void SpawnCube()
    {
        Transform newTrans = CubePrefab.transform;
        newTrans.position = new Vector3(Random.Range(-9,9), 1.8f, Random.Range(-10, 10));
        Instantiate(CubePrefab);
    }

    private void SpawnBonusSpeed()
    {
        Transform newTrans = BonusSpeedPreafab.transform;
        newTrans.position = new Vector3(Random.Range(-9, 9), 1.8f, Random.Range(-10, 10));
        Instantiate(BonusSpeedPreafab);
    }


}
