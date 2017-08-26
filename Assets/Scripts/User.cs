using System.Collections;
using System.Collections.Generic;
using HutongGames.PlayMaker;
using UnityEngine;
using UnityEngine.AI;

public class User : MonoBehaviour
{
    [SerializeField] private int _expirience;
    [SerializeField] private NavMeshAgent agent;
    private Monster Target;
    private MonsterSpawner currentMonsterSpawner;
    

    //private Fsm stateMachine;

    public int Expirience
    {
        get { return _expirience; }
        set
        {
            //_expirience = value;
            int expForNextLevel = Mathf.RoundToInt(Consts.EXPFORLEVEL * Consts.COEFFORLEVEL * (level + 1));
            if (value >= expForNextLevel)
            {
                _expirience = value - expForNextLevel;
                level++;
            }
        }
    }

    public void Awake()
    {
        //stateMachine = GetComponent<Fsm>();
    }
    
    public Vector3 GetRandomPointToWalk()
    {
        return GameManager.Instance.GetRandomPoint();
    }

    public MonsterSpawner TryToAssignToMonsterSpawner()
    {
        MonsterSpawner monsterSpawner = GameManager.Instance.GetFreeMonsterSpawn(this);
        if (monsterSpawner != null)
        {
            currentMonsterSpawner = monsterSpawner;
        }
        return monsterSpawner;
    }
    
    

    public void DealDamage(Monster target)
    {
        //stateMachine.Event("OnMonsterKilled");
    }

    [SerializeField] private int level;
    private int hitPoints;
    private int minDamage;
    private int maxDamage;
    
    
    
}