using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemiesManager : MonoBehaviour
{
    ObjectPooler objPooler;

    [SerializeField] private Vector3 spawnTopLeftCornerPosition;
    [SerializeField] private float distanceBetweenEnemies;
    [SerializeField] private int rows;
    [SerializeField] private int columns;

    [NonSerialized] public int enemiesKilled;


    [SerializeField] private List<float> spawnChances;
    [SerializeField] private float makeHarderBy;
    private void Awake()
    {
        objPooler = ObjectPooler.Instance;
    }
    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        distanceBetweenEnemies = Mathf.Abs(2 * spawnTopLeftCornerPosition.x / (columns - 1));
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                float rnd = UnityEngine.Random.value;
                Debug.Log(rnd);
                if (rnd > 1 - spawnChances[0])
                    objPooler.SpawnFromPool("Enemy", spawnTopLeftCornerPosition + new Vector3(j * distanceBetweenEnemies, 0, -i * distanceBetweenEnemies), Quaternion.identity);
                else if (rnd <= 1 - spawnChances[0] && rnd >= (1 - (spawnChances[0] + spawnChances[1])))
                    objPooler.SpawnFromPool("EnemyPurple", spawnTopLeftCornerPosition + new Vector3(j * distanceBetweenEnemies, 0, -i * distanceBetweenEnemies), Quaternion.identity);
                else
                    objPooler.SpawnFromPool("EnemyBlue", spawnTopLeftCornerPosition + new Vector3(j * distanceBetweenEnemies, 0, -i * distanceBetweenEnemies), Quaternion.identity);
            }
        }
    }

    public void IfAllEnemiesKilled()
    {
        if (enemiesKilled == rows * columns)
        {
            MakeLevelHarder(makeHarderBy);
            SpawnEnemies();
            enemiesKilled = 0;
        }
    }

    void MakeLevelHarder(float value) // increases chance of spawning stronger enemies
    {

        for (int i = 0; i < spawnChances.Count - 1; i++)
        {
            if (spawnChances[i] > 0)
            {
                if (spawnChances[i] >= value)
                {
                    spawnChances[i] -= value;
                    spawnChances[i + 1] += value;
                    break;
                }
                else
                {
                    spawnChances[i + 1] += value - spawnChances[i];
                    spawnChances[i] = 0;
                }
            }

        }

    }
}
