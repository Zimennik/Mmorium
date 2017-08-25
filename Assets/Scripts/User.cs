using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class User : MonoBehaviour
{
    [SerializeField] private int _expirience;
    [SerializeField] private NavMeshAgent agent;

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

    public Vector3 GetRandomPointToWalk()
    {
        return GameManager.Instance.GetRandomPoint();
    }

    [SerializeField] private int level;
    private int hitPoints;
    private int minDamage;
    private int maxDamage;
    
    
    
}