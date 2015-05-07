using UnityEngine;
using System.Collections;

public class PlayerParent : MonoBehaviour {
	public float maxHealth;
	public float currentHealth;
	public float mAttack;
	public float rAttack;
	public float speed;
	public float fireRate;
	public bool active;
	public Vector3 deadZone;
	public float potions;
	public bool hasKey;
	public GameObject meleeHitbox;
	public GameObject projectileHitbox;
	protected GameObject valueModder;
	void OnCollisionEnter(Collision Col){
		GameObject other = Col.gameObject;
		if(other.tag.Equals ("Enemy")){
			//modify tag for the specific enemies
			//deal damage to the player
			//get attack power of enemy and save into variable
			//subtract said variable from health
			currentHealth -= other.GetComponent<EnemyParent>().getAttack();
		}
		if(other.tag.Equals ("enemyprojectile")){
			//modify tag for the specific enemies
			//deal damage to the player
			//get attack power of enemy and save into variable
			//subtract said variable from health
			currentHealth -= other.GetComponent<enemyProjectile>().getAttack();
		}
		if (other.tag.Equals ("Food")) {
			currentHealth = maxHealth;
		}
		if (other.tag.Equals ("Key")){
			hasKey = true;
		}
		if( other.tag.Equals ("Door")){
			if(hasKey){
				Destroy(other.gameObject);
				hasKey = false;
				Destroy(other.gameObject);
			}
		}
	}
}
