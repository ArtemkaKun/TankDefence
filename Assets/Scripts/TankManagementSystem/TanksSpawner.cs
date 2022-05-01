using Cysharp.Threading.Tasks;
using UnityEngine;

namespace TankManagementSystem
{
	public class TanksSpawner : MonoBehaviour
	{
		[field: SerializeField]
		private GameObject TankPrefab { get; set; }
		[field: SerializeField]
		private int SpawnIntervalInMilliseconds { get; set; }
		[field: SerializeField]
		private int SpawnIntervalStep { get; set; }
		[field: SerializeField]
		private SpawnPointsManager SpawnPoints { get; set; }

		public void DecreaseSpawnInterval()
		{
			if (SpawnIntervalInMilliseconds > 2000)
			{
				SpawnIntervalInMilliseconds -= SpawnIntervalStep;
			}
		}
		
		private void Awake ()
		{
			StartSpawning();
		}

		private async void StartSpawning ()
		{
			while (true)
			{
				Instantiate(TankPrefab, SpawnPoints.GetRandomSpawnPoint());
				await UniTask.Delay(SpawnIntervalInMilliseconds);
			}
		}
	}
}