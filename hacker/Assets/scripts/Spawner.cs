using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject zombiePrefab; // ������ ���� ������
    public float spawnInterval = 5f; // ���� ���� (�� ����)
    public Transform[] spawnPoints; // ���� ������ ��ġ��
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
        
        while (i >= 0) // �� ���Ƴ� ��¥ �� �� �Ϳ�
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnZombie();
            i--;
        }// ���� �߸��߳� ,, ��������������������������������
    }

    

    void SpawnZombie()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(zombiePrefab, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
    }

    
}
