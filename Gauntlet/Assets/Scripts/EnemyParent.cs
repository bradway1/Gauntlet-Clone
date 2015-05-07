using UnityEngine;
using System.Collections;

public class EnemyParent : MonoBehaviour {
	public float attack;
	public float speed;
	public float health;
	
	// Update is called once per frame
	void Update () {
		if (health < 0)
			Destroy (this.gameObject);

	}

	public float getAttack(){
		return attack;
	}

	void OnCollisionEnter(Collision col){
		GameObject tempGO = col.gameObject;
		if (tempGO.tag.Equals ("playerprojectile")) {
			health -= tempGO.GetComponent<playerProjectiles>().getAttack();
		}
		if (tempGO.tag.Equals ("playermelee")) {
			health -= tempGO.GetComponent<playerMelee>().getAttack();
		}
	
	}
}
