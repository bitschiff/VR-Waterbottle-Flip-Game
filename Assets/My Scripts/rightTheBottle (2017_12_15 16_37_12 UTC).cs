using UnityEngine;
using System.Collections;

public class rightTheBottle : MonoBehaviour {
	public Rigidbody rb;
	bool canRight;

	// Use this for initialization
	void Start () {
		canRight = false;
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(canRight){

			//Debug.Log(rb.transform.rotation.eulerAngles);
			if (rb.transform.rotation.eulerAngles.x == 270) {
			}else if (rb.transform.rotation.eulerAngles.x >= (270-36) && rb.transform.rotation.eulerAngles.x <= (270+36)) {
				//rb.transform.rotation = Quaternion.Euler(270, 0, 0);
				//Debug.Log("good");
				rb.transform.rotation = Quaternion.Lerp(rb.rotation, Quaternion.Euler (270, 0, 0), Time.deltaTime * 10);
			} else if (rb.transform.rotation.eulerAngles.x <= (270+36)) {
				//rb.transform.rotation = Quaternion.Lerp(rb.rotation, Quaternion.Euler (-90, 0, 0), Time.deltaTime * 10);
			}
			


			/*else if (rb.transform.rotation.eulerAngles.z < 324 && rb.transform.rotation.eulerAngles.z <= 180) {
				rb.transform.rotation = Quaternion.Lerp(rb.rotation, Quaternion.Euler (0, 0, 90), Time.deltaTime * 10);
			}else if (rb.transform.rotation.eulerAngles.z > 36 && rb.transform.rotation.eulerAngles.z <= 180) {
				rb.transform.rotation = Quaternion.Lerp(rb.rotation, Quaternion.Euler (0, 0, 270), Time.deltaTime * 10);
			}*/
		}

	}



	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name == "floor") {
			canRight = true;
		}
	}


	void OnCollisionExit (Collision col)
	{
		if (col.gameObject.name == "floor") {
			canRight = false;
		}
	}
}
