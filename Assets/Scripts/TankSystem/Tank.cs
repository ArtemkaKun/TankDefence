using Cysharp.Threading.Tasks;
using ExplosionSystem;
using PlayerSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TankSystem
{
	public class Tank : MonoBehaviour
	{
		[field: SerializeField]
		private float Speed { get; set; }
		[field: SerializeField]
		private float HPInSeconds { get; set; }
		
		private float CurrentHP { get; set; }

		private void Awake ()
		{
			CurrentHP = HPInSeconds;
		}

		private void Update ()
		{
			if (CurrentHP > 0)
			{
				if (Touchscreen.current.primaryTouch.isInProgress == true)
				{
					if (Vector2.Distance(Camera.main.ScreenToWorldPoint(Touchscreen.current.primaryTouch.position.ReadValue()), transform.position) < 0.5f)
					{
						CurrentHP -= Time.deltaTime;
						Debug.Log(CurrentHP);

						if (CurrentHP <= 0)
						{
							DestroyAfterDelay().Forget();
							return;
						}
					}
				}
			
				transform.Translate(Vector3.up * Speed * Time.deltaTime, Space.Self);
			}
		}

		private async UniTaskVoid DestroyAfterDelay ()
		{
			Destroy(gameObject);
			await FindObjectOfType<ExplosionEffectManager>().MakeExplosion(transform.position);
			FindObjectOfType<GameManager>().ReactOnTankWasDestroyed();
		}
	}
}
