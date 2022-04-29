using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ExplosionSystem
{
	public class ExplosionEffectManager : MonoBehaviour
	{
		[field: SerializeField]
		private GameObject ExplosionPrefab { get; set; }
		[field: SerializeField]
		private AnimationClip ExplosionAnimationClip { get; set; }
		
		private static readonly int EXPLODE = Animator.StringToHash("EXPLODE");

		public async UniTask MakeExplosion (Vector3 position)
		{
			GameObject newExplosion = Instantiate(ExplosionPrefab, position, Quaternion.identity);
			newExplosion.GetComponent<Animator>().SetTrigger(EXPLODE);

			await UniTask.Delay(TimeSpan.FromSeconds(ExplosionAnimationClip.length));
			
			Destroy(newExplosion);
		}
	}
}