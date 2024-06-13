using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject zombiePrefab; // 스폰할 좀비 프리팹
    public float spawnInterval = 5f; // 스폰 간격 (초 단위)
    public Transform[] spawnPoints; // 좀비가 스폰될 위치들
    public int i = 20;

    void Start()           
    {
        StartCoroutine(SpawnZombies());
       //Player playerScript = GetComponent<Player>();

      // if (playerScript.count == 2)
      //{
       //     spawnInterval -= 3f;
     // }
    }

    IEnumerator SpawnZombies() 
    {
        
        while (i >= 0) // 아 미쳤나 진짜 와 와 와오
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnZombie();
            i--;
        }// 문법 잘못했나 ,, ㅋㅎㅋㅎㅋㅎㅋㅎㅋㅋㅋㅎㅋㅎㅎㅋ
    }

    

    void SpawnZombie()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(zombiePrefab, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
    }

    
}
