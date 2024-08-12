using UnityEngine;

namespace Free_Pixel_Art_Forest.Demo
{
	public class MoveBackground : MonoBehaviour {
		public float speed, destPoint, originalPoint;
	
		private void Update() {
			var x = transform.position.x + speed * Time.deltaTime;
			transform.position = new Vector3(x <= destPoint ? originalPoint : x, transform.position.y, transform.position.z);
		}
	}
}
