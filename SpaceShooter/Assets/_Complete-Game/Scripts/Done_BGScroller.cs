using UnityEngine;
using System.Collections;

public class Done_BGScroller : MonoBehaviour
{
	public float speed;
    public float swing;
    public bool up = false;

	private Vector3 startPosition;
    private Vector3 targetPosition;

    void Start ()
	{
		startPosition = transform.position;
        targetPosition = startPosition + (new Vector3(0,0,1) * swing);
	}

	void Update ()
	{
        Vector3 newPosition;
        if(up == false)
        {
            newPosition = Vector3.MoveTowards(transform.position, targetPosition, speed);
            transform.position = newPosition;
            if(transform.position == targetPosition) { up = true; }
        }
        else {
            newPosition = Vector3.MoveTowards(transform.position, startPosition, speed);
            transform.position = newPosition;
            if (transform.position == startPosition) { up = false; }
        }
	}
}