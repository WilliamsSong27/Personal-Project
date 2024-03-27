using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject smallEnemyPrefab;
    [SerializeField]
    private GameObject eliteEnemyPrefab;
    [SerializeField]
    private float smallEnemyInterval = 3.5f;
    [SerializeField]
    private float eliteEnemyInterval = 3.5f;

    void Start()
    {
        StartCoroutine(spawnEnemy(smallEnemyInterval, smallEnemyPrefab));
        StartCoroutine(spawnEnemy(eliteEnemyInterval, eliteEnemyPrefab));
    }

    void Update()
    {

    }

    private IEnumerator spawnEnemy (float interval, GameObject Enemies)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(Enemies, new Vector3(Random.Range(-5f,5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, Enemies));
    }




}
