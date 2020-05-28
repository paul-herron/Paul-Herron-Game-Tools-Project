using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    bool gameWon = false;
    public GameObject gameOver;
    public GameObject gameWin;
    public AudioSource Dead;
    public AudioSource BGMusic;

    private void Start()
    {
        BGMusic.Play();
    }
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            BGMusic.Stop();
            Cursor.lockState = CursorLockMode.None;
            gameHasEnded = true;
            gameOver.SetActive(true);
            Dead.Play();
            Debug.Log("Game Over. Restarting...");
            Invoke("Restart", 2f);
        }
    }
    public void WinGame()
    {
        if (gameWon == false)
        {
            Cursor.lockState = CursorLockMode.None;
            gameWin.SetActive(true);
            Debug.Log("Congrats! You Win!");
            Invoke("ReturnToMenu", 2f);
        }
    }

    void Restart()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(0);

    }

    void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
