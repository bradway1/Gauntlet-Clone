using UnityEngine;
using System.Collections;

public class P1_Move : PlayerParent {
	private Vector3 temp;


	void Start () {
		active = false;
		speed = 0.5f;
		maxHealth = currentHealth = 0;
		mAttack = 2;
		rAttack = 1;
		hasKey = false;
		potions = 0;
		deadZone.x = 1000;
		deadZone.y = 5;
		deadZone.z = 1000;
		//TODO modify values
	}
	

	void Update () {
		if (!active) {
			if(Input.GetKeyDown ("Start_1")){
				//find an active player and spawn on them
				this.gameObject.transform.position = GameObject.FindGameObjectWithTag ("activeplayer").transform.position;
				//set state to active
				this.gameObject.tag = "activeplayer";
				active = true;
				//set hp to max
				currentHealth = maxHealth;
			}
		}
		Move();
		if (currentHealth < 0) {
			this.gameObject.transform.position = deadZone;
			//set state to deactive
			this.gameObject.tag = "notactiveplayer";
			active = false;
		}
	}

	//Gets Controller Input and reacts accordingly
	void Move(){
		if (Input.GetAxis ("L_XAxis_1") > 0.2) {
			//move character right
			temp = this.transform.position;
			temp.x += speed;
			this.transform.position = temp;
		}
		if (Input.GetAxis ("L_XAxis_1") < -0.2) {
			//move character left
			temp = this.transform.position;
			temp.x -= speed;
			this.transform.position = temp;
		}
		if (Input.GetAxis ("L_YAxis_1") < -0.2) {
			//move character up
			temp = this.transform.position;
			temp.z += speed;
			this.transform.position = temp;
		}
		if (Input.GetAxis ("L_YAxis_1") > 0.2) {
			//move character down
			temp = this.transform.position;
			temp.z -= speed;
			this.transform.position = temp;
		}
		if (Input.GetAxis ("TriggersR_1") > 0.2) {
			//melee attacks
			valueModder = Instantiate(meleeHitbox);//TODO modify damage of hitbox
			valueModder.GetComponent<playerMelee>().setAttack(mAttack);
		}
		if (Input.GetAxis ("TriggersL_1") > 0.2) {
			//ranged attacks
			valueModder = Instantiate(projectileHitbox);//TODO modify damage of hitbox
			valueModder.GetComponent<playerProjectiles>().setAttack(rAttack);
			valueModder.GetComponent<playerProjectiles>().setSpeed(speed+2f);
			//uses speed of player + 2 for projectile
		}
		if (Input.GetKeyDown ("B_1")) {
			//check if player has potions to use
			if(potions>0){
				potions --;
				//apply potion effect
			}
		}
	}
}
