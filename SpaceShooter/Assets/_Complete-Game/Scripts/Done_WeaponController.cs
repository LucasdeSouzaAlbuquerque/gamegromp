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
    public float waveRacer = 0;
    public float lastTime = 0;

	void Start ()
	{
		InvokeRepeating ("Fire", 0, fireRate);
	}

    void Update()
    {
        if(Time.time > lastTime + waveRacer)
        {
            fireRate += 0.1f;
            lastTime = Time.time;
        }
        Debug.Log(fireRate);
    }

    void Fire ()
	{
		GameObject shotCreated = Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		Renderer rend = shotCreated.GetComponent<Renderer> ();
		int value = (int)Random.Range (1, 5);
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
		GetComponent<AudioSource>().Play();
	}
}
