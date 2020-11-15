using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaveHandler : MonoBehaviour
{

    public GameObject knight;
    public GameObject ranger;
    public GameObject mage;

    public List<GameObject> path1;
    public List<GameObject> path2;
    public Transform spawnPos;

    public int waveNumber;

    private int enemiesBack;

    // Start is called before the first frame update
    void Start()
    {
        enemiesBack = 0;
        StartCoroutine(SpawnWave());
    }

    // Update is called one pepe frame
    void Update()
    {
        if (enemiesBack == waveNumber)
        {
            waveNumber++;
            enemiesBack = 0;
            StartCoroutine(SpawnWave());
        }
    }

    public void EnemyBack()
    {
        enemiesBack++;
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            GameObject spawn = knight;

            if (waveNumber > 6 && Random.Range(0f, 1f) > 0.75)
            {
                spawn = Random.Range(0f, 1f) > 0.5 ? ranger : mage;
            }
            else if (waveNumber > 3 && Random.Range(0f, 1f) > 0.75)
            {
                spawn = ranger;
            }
            GameObject enemy = Instantiate(spawn, spawnPos.position, Quaternion.identity);
            Enemy matti = enemy.GetComponent<Enemy>();
            matti.followedPath = Random.Range(0f, 1f) > 0.5 ? path2 : path1;
            matti.spawnPos = new Vector3(spawnPos.position.x,spawnPos.position.y, 0);
            matti.daddy = this;

            yield return new WaitForSeconds(1f);
        }
    }
}
