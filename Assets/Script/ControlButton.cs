using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void FinishtGame()
    {
        SceneManager.LoadScene("FinishScreen");
    }
    public void Backtomenu()
    {
        SceneManager.LoadScene("StartScreen");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
