using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private int capability = 5;
    [SerializeField] private Monster monsterPrefab;
    private List<Monster> Monsters;
    public List<User> AssignedUsers;                //Юзеры на этой зоне спавна


    public bool IsThereAFreeSpace()
    {
        return AssignedUsers.Count < capability;
    }

    public void Awake()
    {
        Monsters = new List<Monster>();
        AssignedUsers = new List<User>();
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
    
    public Vector3 GetRandomPoint()
    {
        Vector3 spawnPoint = transform.position;
        return spawnPoint + new Vector3(Random.Range(-10, 10), 0.5f, Random.Range(-10, 10));
    }

    public void SpawnNewMonster()
    {
        Monster monster = Instantiate(monsterPrefab,GetRandomPoint(),Quaternion.identity);
        monster.transform.parent = transform;
        monster.SetSpawner(this);
        Monsters.Add(monster);
    }

    public void OnUserAssign(User user)
    {
        AssignedUsers.Add(user);
    }

    public void OnUserDeasign(User user)
    {
        AssignedUsers.Remove(user);
    }
    
    public Monster GetFreeMonster(User toWhom)
    {
        Monster monster = Monsters.FirstOrDefault(x => x.owner == null);
        if (monster != null)
        {
            OnUserAssign(toWhom);
        }
        return monster;
    }
}