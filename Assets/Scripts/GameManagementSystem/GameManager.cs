using TankManagementSystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace PlayerSystem
{
	public class GameManager : MonoBehaviour
	{
		[field: SerializeField]
		private UIDocument GameOverScreen { get; set; }
		[field: SerializeField]
		private uint MaxTanksToPass { get; set; }
		[field: SerializeField]
		private TanksSpawner Spawner { get; set; }
		
		private PlayerData PlayerData { get; } = new PlayerData();

		private void Awake()
		{
			GameOverScreen.rootVisualElement.visible = false;
		}
		
		public void ReactOnTankWasPassed ()
		{
			PlayerData.TanksPassed += 1;

			if (PlayerData.TanksPassed == MaxTanksToPass)
			{
				GameOverScreen.rootVisualElement.visible = true;
			}
		}
		
		public void ReactOnTankWasDestroyed ()
		{
			PlayerData.TanksDestroyed += 1;
			Spawner.DecreaseSpawnInterval();
		}
	}
}