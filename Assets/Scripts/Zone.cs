using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using HutongGames.PlayMaker;
using UnityEngine;
using UnityEngine.AI;

public class Zone : MonoBehaviour {

	public Vector3 GetRandomPoint(float radiusFromCenter)
	{
		Vector2 randomDirection = Random.insideUnitCircle * radiusFromCenter;
		NavMeshHit hit;
		NavMesh.SamplePosition(randomDirection, out hit, radiusFromCenter, 1);
		return hit.position;
	}
}
