using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bottle_flip : MonoBehaviour {
	public Rigidbody rb;

	int jumpHeight;
	bool canJump;
	float maxAccel;
	bool rotating;
	int points;
	float controlAccelY;
	public TextMesh scoreText;
	bool touched;
	bool fliped;

	// Use this for initialization
	void Start () {
		jumpHeight = 50;
		canJump = true;
		maxAccel = 0;
		points = 0;
		rotating = false;
		controlAccelY = 0;
		scoreText.text = "Score: " + points.ToString();
		touched = true;
		fliped = false;


		rb = GetComponent<Rigidbody>();
		rb.transform.rotation = Quaternion.Euler(-90, 0, 0);
		rb.transform.position = new Vector3((float).187, (float).1, (float)4.318);

	}

	// Update is called once per frame
	void Update () {
			jump ();
		if (Input.GetKey(KeyCode.Escape)){
			Application.Quit();
		}

	}


	void jump(){

		if(canJump == false){
			if(rb.transform.rotation.eulerAngles.x < 150){
				fliped = true;
			}
		}

		Debug.Log("fliped: " + fliped);


		controlAccelY = (GvrController.Accel.y-9.8f);


		if (GvrController.ClickButtonUp && canJump == true) {

			//rb.velocity = new Vector3 (0, 10, 0);


			rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);

			maxAccel =(float)(5*maxAccel);
			//Debug.Log (maxAccel);
			rb.AddTorque(0,0,maxAccel);
			canJump = false;
			touched = false;

		}

		if (GvrController.ClickButton) {
			//Debug.Log (controlAccelY);
			if (Mathf.Abs(controlAccelY) >= Mathf.Abs(maxAccel)) {
				maxAccel = controlAccelY;

			}
		} else {
			maxAccel = 0;
		}
	}


	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name == "floor") {
			if (touched==false){
				touched=true;
				StartCoroutine (waitToReset ());

			}

		}
	}


	IEnumerator waitToReset() {
		//print(Time.time);

		yield return new WaitForSecondsRealtime(1);
		if (fliped == true) {
			if (rb.transform.rotation.eulerAngles.z == 0) {
				addScore ();
			} else if (rb.transform.rotation.eulerAngles.z <= 36) {
				addScore ();
			} else if (rb.transform.rotation.eulerAngles.z >= 324) {
				addScore ();
			}
		}
		fliped = false;

		//rb.transform.rotation = Quaternion.identity;
		rb.transform.rotation = Quaternion.Euler(-90, 0, 0);
		rb.transform.position = new Vector3((float).187, (float).1, (float)4.318);
		canJump = true;


	}

	void addScore(){
		points++;
		scoreText.text = "Score: " + points.ToString();
		Debug.Log ("points: " + points);
	}


}
