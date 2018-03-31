using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Done_GameController : MonoBehaviour
{
	public float startWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

    public Camera myCamera;

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
        if (myCamera == null)
            myCamera = Camera.main;

        myCamera.gameObject.transform.eulerAngles = new Vector3(90, 0, 0);
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
#if UNITY_IPHONE
            restartText.text = "Tap the phone to restart";
#else
            restartText.text = "Press 'R' for Restart";
#endif
            restart = true;
        }
        if (restart)
		{
#if UNITY_IPHONE
            if (Input.GetTouch(i).phase == TouchPhase.Began){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
#else
            if (Input.GetKeyDown (KeyCode.R))
			{
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
#endif
        }
#if UNITY_IPHONE
        if(anyActive != -1 && shieldSpawn != null)
        {
            spawnShield(anyActive);
        }
#else
        if (Input.GetKeyDown(KeyCode.Z))
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
        }
#endif
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