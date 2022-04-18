using UnityEngine;

namespace Tank
{
	public class Tank : MonoBehaviour
	{
		[field: SerializeField]
		private float Speed { get; set; }

		private void Update ()
		{
			transform.Translate(Vector3.up * Speed * Time.deltaTime, Space.Self);
		}
	}
}
