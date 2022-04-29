using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

namespace TowerSystem
{
	public class TowerController : MonoBehaviour
	{
		private void OnEnable()
		{
			TouchSimulation.Enable();
		}

		private void Update ()
		{
			if (Touchscreen.current.primaryTouch.isInProgress == true)
			{
				Vector3 calculatedLookAtVector = Camera.main.ScreenToWorldPoint(Touchscreen.current.primaryTouch.position.ReadValue()) - transform.position;
				calculatedLookAtVector.z = 0;
				transform.up = calculatedLookAtVector;
			}
		}
	}
}