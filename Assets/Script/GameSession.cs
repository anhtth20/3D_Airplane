using UnityEngine;

public class GameSession : MonoBehaviour
{
    public static GameSession I;              // <<< singleton toàn cục

    [SerializeField] private int score = 0;

    private void Awake()
    {
        // Singleton + sống xuyên scene
        if (I != null && I != this) { Destroy(gameObject); return; }
        I = this;
        DontDestroyOnLoad(gameObject);
    }

    public int GetScore() => score;
    public void AddToScore(int v) => score += v;

    public void ResetScore() => score = 0;    // chỉ reset điểm

    // Chỉ dùng khi muốn hủy hẳn phiên chơi (hiếm khi cần)
    public void ResetGame()
    {
        I = null;
        Destroy(gameObject);
    }
}
