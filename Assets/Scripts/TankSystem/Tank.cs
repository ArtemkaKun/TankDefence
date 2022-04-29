using Cysharp.Threading.Tasks;
using ExplosionSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TankSystem
{
	public class Tank : MonoBehaviour
	{
		[field: SerializeField]
		private float Speed { get; set; }
		[field: SerializeField]
		private uint HP { get; set; }
		
		private float CurrentHP { get; set; }

		private void Awake ()
		{
			CurrentHP = HP;
		}

		private void Update ()
		{
			if (CurrentHP > 0)
			{
				if (Touchscreen.current.primaryTouch.isInProgress == true)
				{
					if (Vector2.Distance(Camera.main.ScreenToWorldPoint(Touchscreen.current.primaryTouch.position.ReadValue()), transform.position) < 0.1f)
					{
						CurrentHP -= 1;

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
		}
	}
}
