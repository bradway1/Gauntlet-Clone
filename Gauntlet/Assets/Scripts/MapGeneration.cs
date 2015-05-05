using UnityEngine;
using System.Collections;

public class MapGeneration : MonoBehaviour {
	public GameObject[] quadrents;
	public GameObject[] modules;
	public GameObject none;
	public Module mod;
	private Module buildBool;
	private float buildCount;
	private IEnumerator MapGen;
	private bool runCo;
	// Use this for initialization
	void Start() 
	{
		runCo = true;
		buildCount = 0;
		int start = Random.Range (0, quadrents.Length - 1);
		//GameObject start = quadrents[Random.Range(0,quadrents.Length-1)];
		GameObject entrance = Instantiate (modules[0], quadrents[start].transform.position, quadrents[start].transform.rotation) as GameObject;
		quadrents[start].GetComponent<Module> ().setBuild ();
		quadrents [start].GetComponent<Renderer> ().enabled = false;
		buildCount++;
		Exit ();
		MapGen = Build();
		StartCoroutine(MapGen);

	}
	void Exit()
	{
		int end = Random.Range(0,quadrents.Length-1);
		if (quadrents[end].GetComponent<Module>().getBuild () == true) 
		{
			Exit ();
		} 
		else 
		{
			GameObject stairs = Instantiate (modules[1], quadrents[end].transform.position, quadrents[end].transform.rotation) as GameObject;
			quadrents[end].GetComponent<Module>().setBuild();
			quadrents[end].GetComponent<Renderer> ().enabled = false;
			buildCount++;
		}
	}
	void NewLevel()
	{
		runCo = true;
		buildCount = 0;
		int start = Random.Range (0, quadrents.Length - 1);
		GameObject entrance = Instantiate (modules[0], quadrents[start].transform.position, quadrents[start].transform.rotation) as GameObject;
		quadrents[start].GetComponent<Module> ().setBuild ();
		quadrents[start].GetComponent<Renderer> ().enabled = false;
		buildCount++;
		Exit ();
		MapGen = Build();
		StartCoroutine(MapGen);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(runCo == true) 
		{
			if(buildCount == 9) {
				StopCoroutine(MapGen);
				runCo = false;
			}
		}
		
	}
	IEnumerator Build() 
	{
		for(int index = 0; index < quadrents.Length; index++)
		{
			if(quadrents[index].GetComponent<Module>().getBuild() == true) 
			{
				yield return new WaitForSeconds(.01f);
			}
			else
			{
				GameObject room = Instantiate(modules[Random.Range(2,modules.Length)], quadrents[index].transform.position, quadrents[index].transform.rotation) as GameObject;
				quadrents[index].GetComponent<Module>().getBuild();
				quadrents[index].GetComponent<Renderer> ().enabled = false;
				buildCount++;
				yield return new WaitForSeconds(.01f);
			}

		}
	}
}
