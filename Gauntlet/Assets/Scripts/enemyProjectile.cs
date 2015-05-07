using UnityEngine;
using System.Collections;

public class enemyProjectile : MonoBehaviour {
	private float speed;
	private float attack;
	// Use this for initialization
	void Start () {
		speed = 0;
		attack = 0;
	}
	
	public float getSpeed(){
		return speed;
	}
	
	public void setSpeed(float s){
		speed = s;
	}
	
	public float getAttack(){
		return attack;
	}
	
	public void setAttack(float a){
		attack = a;
	}
	
	
}
