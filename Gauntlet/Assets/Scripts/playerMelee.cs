using UnityEngine;
using System.Collections;

public class playerMelee : MonoBehaviour {
	private float attack;
	// Use this for initialization
	void Start () {

		attack = 0;
	}

	public float getAttack(){
		return attack;
	}
	
	public void setAttack(float a){
		attack = a;
	}
	
	
}