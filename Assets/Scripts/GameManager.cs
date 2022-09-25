using UnityEngine;
using UnityEngine.UI; 
public class GameManager : MonoBehaviour
{
    [SerializeField] private int score;
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public Sprite deadPlayer;
    private void Awake()
    {
        // Make the game run only on 60fps :
        Application.targetFrameRate = 60;
        // Pause the game at start :
        Pause();
    }
    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
        playButton.SetActive(false);
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;
        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }
    public void GameOver()
    {
        gameObject.SetActive(true);
        playButton.SetActive(true);
        Pause();
        player.GetComponent<SpriteRenderer>().sprite = deadPlayer;
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
