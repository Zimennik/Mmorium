using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<MonsterSpawner> MonsterSpawners;

    void Awake()
    {
        //Check if instance already exists
        if (Instance == null)

            //if not, set instance to this
            Instance = this;

        //If instance already exists and it's not this:
        else if (Instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
    }
    
    public Vector3 GetRandomPoint()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 30;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, 30, 1);
        return hit.position;
    }

    public MonsterSpawner GetFreeMonsterSpawn(User user)
    {
        MonsterSpawner monsterSpawner = MonsterSpawners.FirstOrDefault(x => x.IsThereAFreeSpace());
        if (monsterSpawner != null)
        {
            monsterSpawner.OnUserAssign(user);
        }
        
        return monsterSpawner;
    }
    
    
}