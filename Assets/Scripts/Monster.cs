using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
	private int hitPoints;
	private int expForMonster = 5;
	private MonsterSpawner spawner;
	public User owner;

	public void SetSpawner(MonsterSpawner spawner)
	{
		this.spawner = spawner;
	}

	public Vector3 GetRandomPoint()
	{
		return spawner.GetRandomPoint();
	}
	
	public bool GetHit(int damage, User user)
	{
		bool isAlive = true;
		hitPoints -= damage;
		if (hitPoints <= 0)
		{
			isAlive = false;
			OnDeath(user);
		}
		return isAlive;
	}
	
	//todo
	public void OnDeath(User killer)
	{
		//killer.Expirience += expForMonster;
	}

	//todo
	public void OnOutOfRange()
	{
		
	}
}
