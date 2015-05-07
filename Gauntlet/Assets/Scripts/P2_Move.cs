using UnityEngine;
using System.Collections;

public class P2_Move : PlayerParent {
	private Vector3 temp;
	
	
	void Start () {
		speed = 0.5f;
		maxHealth = currentHealth = 0;
		attack = 0;
		//TODO modify values
	}
	
	
	void Update () {
		Move();
	}
	
	//Gets Controller Input and reacts accordingly
	void Move(){
		if (Input.GetAxis ("L_XAxis_2") > 0.2) {
			//move character right
			temp = this.transform.position;
			temp.x += speed;
			this.transform.position = temp;
		}
		if (Input.GetAxis ("L_XAxis_2") < -0.2) {
			//move character left
			temp = this.transform.position;
			temp.x -= speed;
			this.transform.position = temp;
		}
		if (Input.GetAxis ("L_YAxis_2") < -0.2) {
			//move character up
			temp = this.transform.position;
			temp.z += speed;
			this.transform.position = temp;
		}
		if (Input.GetAxis ("L_YAxis_2") > 0.2) {
			//move character down
			temp = this.transform.position;
			temp.z -= speed;
			this.transform.position = temp;
		}
		if (Input.GetKeyDown ("X_2")) {
			//attacks
		}
	}
}