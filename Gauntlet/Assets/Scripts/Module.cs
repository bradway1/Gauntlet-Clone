using UnityEngine;
using System.Collections;

public class Module : MonoBehaviour {
	Vector3 pos;
	public GameObject Above;
	public GameObject Left;
	public GameObject Right;
	public GameObject Below;
	public bool build;
	// Use this for initialization
	void Awake () 
	{
		pos = this.transform.position;
		build = false;
	}
	public Vector3 getPos()
	{
		return pos;
	}
	public GameObject getAbove()
	{
		return Above;
	}
	public GameObject getLeft()
	{
		return Left;
	}
	public GameObject getRight()
	{
		return Right;
	}
	public GameObject getBelow()
	{
		return Below;
	}
	public void setAbove(GameObject obj)
	{
		Above = obj;
	}
	public void setLeft(GameObject obj)
	{
		Left = obj;
	}
	public void setRight(GameObject obj)
	{
		Right = obj;
	}
	public void setBelow(GameObject obj)
	{
		Below = obj;
	}

	public void setPos(float drop)
	{
		Vector3 newPos = pos;
		newPos.y -= drop;
		pos = newPos;
	}
	public void setBuild() 
	{
		build = true;
	}
	public bool getBuild() {
		return build;
	}

}
