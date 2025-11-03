using UnityEngine;

public class AirPlaneScript : MonoBehaviour
{
    public float speed = 10f;       // toc do by thang
    public float rotationSpeed = 50f; // speed xoay

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    //private void OnColliderEnter(Collider other)
    //{
    //    if (other.CompareTag("GameController"))
    //    {

    //        Debug.Log("Player has entered the game area.");
    //    }
    //    else
    //    {
    //        Debug.Log(other.tag);
    //    }
    //}
    void FixedUpdate()
    {
        // Luôn bay về phía trước
        rb.linearVelocity = -transform.forward * speed;

        // Điều khiển xoay bằng phím
        float h = Input.GetAxis("Horizontal"); // A/D hoặc mũi tên trái/phải
        float v = Input.GetAxis("Vertical");   // W/S hoặc mũi tên lên/xuống

        // Quay máy bay
        transform.Rotate(Vector3.up * h * rotationSpeed * Time.deltaTime);
        transform.Rotate(Vector3.right * -v * rotationSpeed * Time.deltaTime);
    }
}

