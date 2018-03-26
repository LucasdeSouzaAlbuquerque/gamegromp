using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Done_GameController : MonoBehaviour
{
	public float startWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	
	private bool gameOver;
	private bool restart;
	private int score;
    public GameObject shield;
    private GameObject myShield;
    public Transform shieldSpawn;
    public Material[] myMaterials = new Material[4];
    public string[] tags = { "Green", "Red", "Blue", "Yellow" };
    public int anyActive = -1;

    public GameObject[] invisicubes = new GameObject[4];

    public float shieldDelay;
    public float lastTime;

    void Start ()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
	}
	
	void Update ()
	{

        checkStuffYo();

        if (gameOver)
        {
            restartText.text = "Press 'R' for Restart";
            restart = true;
        }
        if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}

        if(anyActive != -1 && shieldSpawn != null)
        {
            spawnShield(anyActive);
        }

        /*if (Input.GetKeyDown(KeyCode.Z))
        {
            spawnShield(0);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            spawnShield(1);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            spawnShield(2);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            spawnShield(3);
        }*/
    }

    void checkStuffYo()
    {
        anyActive = -1;
        for (int i = 0; i < 4; i++)
        {
            if (invisicubes[i].activeSelf)
            {
                anyActive = i;
                break;
            }
        }
    }

    void spawnShield(int materialInd)
    {
        if (Time.time > lastTime + shieldDelay)
        {
            if (myShield != null)
            {
                Destroy(myShield.gameObject);
            }
            myShield = Instantiate(shield, shieldSpawn.position, shieldSpawn.rotation);
            Renderer rend = myShield.GetComponent<Renderer>();
            rend.material = myMaterials[materialInd];
            myShield.tag = tags[materialInd];
            lastTime = Time.time;
        }

    }

    public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}
	
	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}