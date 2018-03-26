using UnityEngine;
using System.Collections;

public class Done_WeaponController : MonoBehaviour
{
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float delay;
	public Material[] myMaterials = new Material[4];
	public string[] tags = {"Green", "Red", "Blue", "Yellow"};

	void Start ()
	{
		InvokeRepeating ("Fire", delay, fireRate);
	}

	void Fire ()
	{
		GameObject shotCreated = Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		Renderer rend = shotCreated.GetComponent<Renderer> ();
		int value = (int)Random.Range (1, 4);
		switch(value){	
		case 1:
			rend.material = myMaterials [0];
			shotCreated.tag = tags [0];
			break;
		case 2:
			rend.material = myMaterials [1];
			shotCreated.tag = tags [1];
			break;
		case 3:
			rend.material = myMaterials [2];
			shotCreated.tag = tags [2];
			break;
		case 4:
			rend.material = myMaterials [3];
			shotCreated.tag = tags [3];
			break;
		}
		Debug.Log (shotCreated.tag);
		GetComponent<AudioSource>().Play();
	}
}
