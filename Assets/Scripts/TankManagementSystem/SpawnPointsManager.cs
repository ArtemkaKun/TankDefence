using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TankManagementSystem
{
	[Serializable]
	public class SpawnPointsManager
	{
		[field: SerializeField]
		private List<Transform> SpawnPoints { get; set; }

		public Transform GetRandomSpawnPoint ()
		{
			return SpawnPoints[Random.Range(0, SpawnPoints.Count)];
		}
	}
}