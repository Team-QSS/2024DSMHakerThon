using UnityEngine;

namespace Free_Pixel_Art_Forest.Demo
{
	public class MoveBackground : MonoBehaviour {



		public float speed;
		private float x;
		public float PontoDeDestino;
		public float PontoOriginal;




		// Use this for initialization
		private void Start () {
			//PontoOriginal = transform.position.x;
		}
	
		// Update is called once per frame
		private void Update() {


			x = transform.position.x;
			x += speed * Time.deltaTime;
			transform.position = new Vector3 (x, transform.position.y, transform.position.z);
			
			if (!(x <= PontoDeDestino)) return;
			Debug.Log("hhhh");
			x = PontoOriginal;
			transform.position = new Vector3 (x, transform.position.y, transform.position.z);
		}
	}
}
