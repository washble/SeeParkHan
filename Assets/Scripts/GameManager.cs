using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                    Debug.Log("No Singleton obj");
            }
            return instance;
        }
    }

    void Awake()
    {
        if(instance == null)
            instance = this;
        else if(instance != this)
            Destroy(gameObject);
        // DontDestroyOnLoad(gameObject);   // If you wanna maintain gamemanager to next scene, delete comment out
    }

    // Write your code under the here!!
    void Update()
    {
        if (GameOverState && Input.GetKeyUp(KeyCode.Space))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public enum ObjectTag
    {
        Player,
        Obstacle,
        Foot,
        Destroy
    }

    public enum Floors
    {
        left,
        right
    }

    [SerializeField]
    private List<GameObject> heart = new List<GameObject>();

    private int playerHP = 3;
    public int PlayerHP
    {
        get { return playerHP; }
        set 
        {
            if(value >= 0)
            {
                playerHP = value;
                heart[value].SetActive(false);
                if(value == 0)
                {
                    GameOver();
                }
            }
        }
    }

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject gameOverNotice;
    [SerializeField]
    private GameObject reStartNotice;
    private void GameOver()
    {
        player.SetActive(false);
        gameOverNotice.SetActive(true);
        reStartNotice.SetActive(true);
        GameOverState = true;
    }

    private bool gameOverState = false;
    public bool GameOverState
    {
        get { return gameOverState; }
        set { gameOverState = value; }
    }

    [SerializeField]
    private Text score;
    
    private int playerScore = 0;
    public int PlayerScore
    {
        get { return playerScore; }
        set 
        { 
            playerScore = value;
            score.text = playerScore.ToString();
        }
    }

    private float movePower = 5f;
    public float MovePower
    {
        get { return movePower; }
    }

    private bool reachCameraLeft = false;
    public bool ReachCameraLeft
    {
        get { return reachCameraLeft; }
        set { reachCameraLeft = value; }
    }

    public Transform PlayerTransform
    {
        get { return player.transform; }
    }
}
