using UnityEngine;

public class AirPlaneScript : MonoBehaviour
{
    [Header("Flight")]
    [SerializeField] private float speed = 10f;          // tốc độ bay thẳng (m/s)
    [SerializeField] private float rotationSpeed = 50f;  // tốc độ xoay

    [Header("Scoring")]
    [SerializeField] private float pointsPerMeter = 1f;  // 1 mét = 1 điểm
    private float pendingPoints = 0f;                    // tích lũy phần lẻ

    private Rigidbody rb;

    const string KEY_SPEED = "plane_speed";
    const string KEY_ROT = "plane_rot";

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = PlayerPrefs.GetFloat(KEY_SPEED, speed);
        rotationSpeed = PlayerPrefs.GetFloat(KEY_ROT, rotationSpeed);
        Debug.Log($"Speed: {speed}, Rot: {rotationSpeed}");
    }

    void FixedUpdate()
    {
        // Bay thẳng theo -forward
        rb.linearVelocity = -transform.forward * speed;

        // Điều khiển xoay
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.up * h * rotationSpeed * Time.deltaTime);
        transform.Rotate(Vector3.right * -v * rotationSpeed * Time.deltaTime);

        // ===== CỘNG ĐIỂM TỈ LỆ VỚI TỐC ĐỘ (quãng đường) =====
        // quãng đường đi trong tick vật lý:
        float deltaDist = rb.linearVelocity.magnitude * Time.fixedDeltaTime; // mét
        pendingPoints += deltaDist * pointsPerMeter;

        int whole = Mathf.FloorToInt(pendingPoints);
        if (whole > 0)
        {
            var gs = FindObjectOfType<GameSession>();
            if (gs != null) gs.AddToScore(whole);
            pendingPoints -= whole; // giữ lại phần lẻ cho lần sau
        }
    }

    // Cho Settings gọi để áp dụng realtime
    public void SetSpeed(float value)
    {
        speed = Mathf.Max(0f, value);
        PlayerPrefs.SetFloat(KEY_SPEED, speed);
        PlayerPrefs.Save();
    }

    public void SetRotationSpeed(float value)
    {
        rotationSpeed = Mathf.Max(0f, value);
        PlayerPrefs.SetFloat(KEY_ROT, rotationSpeed);
        PlayerPrefs.Save();
    }
}
