using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 1.5f;
    public float minXDistance = 1.0f;
    public int maxEnemies = 5;
    public Transform playerTransform;
    private float timer;
    private List<GameObject> activeEnemies = new List<GameObject>();

    public GameObject playerObject;
    private int points = 0;
 

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && activeEnemies.Count < maxEnemies)
        {
            GenerateEnemy();
            timer = spawnInterval;
        }

        CheckPassedEnemies();
    }

    void GenerateEnemy()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(playerTransform.position.x + minXDistance, 180f), -7.9f, 0f);

        if (IsFarEnough(spawnPosition))
        {

            GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            activeEnemies.Add(newEnemy);
        }
    }

    bool IsFarEnough(Vector3 position)
    {
        foreach (GameObject enemy in activeEnemies)
        {
            if (enemy != null && Vector3.Distance(enemy.transform.position, position) < minXDistance)
            {
                return false;
            }
        }
        return true;
    }

    public void RemoveEnemy(GameObject enemy)
    {
        if (enemy != null && activeEnemies.Contains(enemy))
        {
            activeEnemies.Remove(enemy);
            Destroy(enemy);
        }
    }

    public void CheckPassedEnemies()
    {
        if (playerObject == null) return;

        List<GameObject> enemiesToRemove = new List<GameObject>();

        foreach (GameObject enemy in activeEnemies)
        {
            if (enemy != null && playerObject.transform.position.x > enemy.transform.position.x)
            {
                points += 1;
                GameObject.Find("Score").GetComponent<TMP_Text>().text = points.ToString();

                Debug.Log(points);
                enemiesToRemove.Add(enemy); 
            }
        }

        foreach (GameObject enemyToRemove in enemiesToRemove)
        {
            RemoveEnemy(enemyToRemove);
        }
    }


}
