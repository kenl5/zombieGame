using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieSpawner : MonoBehaviour {

    public GameObject Prefab;
    public float spawnDelayMin;
    public float spawnDelayMax;

    private float spawnTimer;
    public Transform spawnPoint;

    private void Awake()
    {
        spawnTimer = Random.Range(spawnDelayMin, spawnDelayMax);
    }

	// Update is called once per frame
	void Update () {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            Instantiate(Prefab, spawnPoint.position, spawnPoint.rotation);

            spawnTimer = Random.Range(spawnDelayMin, spawnDelayMax);
        }
	}
}
