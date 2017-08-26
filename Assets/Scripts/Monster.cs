using System.Collections;
using System.Collections.Generic;
using HutongGames.PlayMaker;
using UnityEngine;

public class Monster : MonoBehaviour
{
	private int hitPoints = 100;
	private int expForMonster = 5;
	private MonsterSpawner spawner;
	public User owner;
	public PlayMakerFSM fsm;

	public void SetSpawner(MonsterSpawner spawner)
	{
		this.spawner = spawner;
	}

	private void Awake()
	{
		owner = null;
	}

	public GameObject GetMonsterGO()
	{
		return this.gameObject;
	}

	public Vector3 GetRandomPoint()
	{
		return spawner.GetRandomPoint();
	}
	
	public void GetHit(int damage, User user)
	{
		fsm.SendEvent("GetHit");
		
		
		hitPoints -= damage;
		if (hitPoints <= 0)
		{
			user.OnMobKilled(this);
			OnDeath(user);
		}
	}

	public void AttackOwner()
	{
		//owner todo
	}
	
	public void OnDeath(User killer)
	{
		spawner.OnMonsterKilled(this);
		Destroy(gameObject);
	}

	//todo
	public void OnOutOfRange()
	{
		
	}
}
