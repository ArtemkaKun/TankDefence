using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

namespace TowerSystem
{
	public class TowerController : MonoBehaviour
	{
		[field: SerializeField]
		private Animator TowerAnimator { get; set; }
		
		private static readonly int IS_FIRING = Animator.StringToHash("IsFiring");

		private void OnEnable()
		{
			TouchSimulation.Enable();
		}

		private void Update ()
		{
			bool isScreenTouched = Touchscreen.current.primaryTouch.isInProgress;
			
			if (isScreenTouched == true)
			{
				Vector3 calculatedLookAtVector = Camera.main.ScreenToWorldPoint(Touchscreen.current.primaryTouch.position.ReadValue()) - transform.position;
				calculatedLookAtVector.z = 0;
				transform.up = calculatedLookAtVector;
			}
			
			TowerAnimator.SetBool(IS_FIRING, isScreenTouched);
		}
	}
}