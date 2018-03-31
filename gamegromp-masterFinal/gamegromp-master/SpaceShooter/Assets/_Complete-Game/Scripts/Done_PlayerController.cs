using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
	public GameObject shield;
	public Transform shieldSpawn;
	 
	private float nextFire;
	
	void Update ()
	{
	}

	void FixedUpdate ()
	{
	}

}
