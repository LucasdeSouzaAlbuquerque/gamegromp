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
		GameObject shota = Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		int value = (int)Random.Range (1, 4);
		switch(value){	
		case 1:
			shota.GetComponent<Renderer>().material = myMaterials [0];
			shota.tag = tags [0];
			break;
		case 2:
			shota.GetComponent<Renderer>().material = myMaterials [1];
			shota.tag = tags [1];
			break;
		case 3:
			shota.GetComponent<Renderer>().material = myMaterials [2];
			shota.tag = tags [2];
			break;
		case 4:
			shota.GetComponent<Renderer>().material = myMaterials [3];
			shota.tag = tags [3];
			break;
		}
		GetComponent<AudioSource>().Play();
	}
}
