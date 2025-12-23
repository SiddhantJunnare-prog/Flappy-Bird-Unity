using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public GameObject gameOverScreen;
    public AudioSource PointAudioSource;
    public AudioClip PointAudioClip;
    public bool isMuted = false;
    public bool isGameOver = false;
    public Text gameOverScoreText;
    public AudioClip gameOverAudioClip;


    public void addScore(int scoreToAdd)
    {
        score = score + scoreToAdd;
        scoreText.text = score.ToString();
        PointAudioSource.PlayOneShot(PointAudioClip);   
    }

    public void restartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void gameOver()
    {
        if (isGameOver) 
        {
            return;
        }

        isGameOver = true;
        gameOverScoreText.text = "Score: " + score.ToString();
        gameOverScreen.SetActive(true);
        PointAudioSource.PlayOneShot(gameOverAudioClip);
    }

    public void GoToGameMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }

    //public void manageSound()
    //{
    //    if(isMuted)
    //    {

    //    }
    //}


}
