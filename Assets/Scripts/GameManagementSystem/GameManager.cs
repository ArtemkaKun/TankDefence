using UnityEngine;

namespace PlayerSystem
{
	public class GameManager : MonoBehaviour
	{
		[field: SerializeField]
		private uint MaxTanksToPass { get; set; }

		private PlayerData PlayerData { get; } = new PlayerData();

		public void ReactOnTankWasPassed ()
		{
			PlayerData.TanksPassed += 1;
		}
		
		public void ReactOnTankWasDestroyed ()
		{
			PlayerData.TanksDestroyed += 1;
		}
	}
}