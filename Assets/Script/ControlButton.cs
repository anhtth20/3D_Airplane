using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartGame()
    {
        SceneManager.LoadScene("LevelsScene");
    }
    public void FinishtGame()
    {
        SceneManager.LoadScene("FinishScene");
    }
    public void Backtomenu()
    {
        GameSession.I?.ResetScore();
        SceneManager.LoadScene("StartScene");
    }

    public void Level1()
    {
        SceneManager.LoadScene("SampleScene1");
    }
    public void Level2()
    {
        SceneManager.LoadScene("SampleScene2");
    }
    public void Level3()
    {
        SceneManager.LoadScene("SampleScene3");
    }
    public void Setting()
    {
        SceneManager.LoadScene("Setting");
    }
    public void AboutUs()
    {
        SceneManager.LoadScene("AboutUs");
    }

    // Update is called once per frame

    public void Restart()
    {
        GameSession.I?.ResetScore();
        Time.timeScale = 1f;

        var active = SceneManager.GetActiveScene();
        SceneManager.LoadScene(active.buildIndex);
    }
    void Update()
    {
        
    }
}
