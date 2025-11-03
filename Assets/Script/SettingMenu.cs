using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    [SerializeField] private Slider speedSlider;
    [SerializeField] private Slider rotSlider;
    [SerializeField] private TMP_Text speedText;
    [SerializeField] private TMP_Text rotText;

    const string KEY_SPEED = "plane_speed";
    const string KEY_ROT = "plane_rot";

    void Awake()
    {
        // 1) Load đã lưu (mặc định 10 và 50; sửa theo game bạn)
        float sp = PlayerPrefs.GetFloat(KEY_SPEED, 10f);
        float rot = PlayerPrefs.GetFloat(KEY_ROT, 50f);

        // 2) Set slider mà KHÔNG phát sự kiện
        speedSlider.SetValueWithoutNotify(sp);
        rotSlider.SetValueWithoutNotify(rot);

        // 3) Cập nhật label ban đầu
        speedText.text = $"Speed: {sp:0}";
        rotText.text = $"Rotation: {rot:0}";

        // 4) Gắn listener đúng slider → đúng hàm
        speedSlider.onValueChanged.AddListener(OnSpeedChanged);
        rotSlider.onValueChanged.AddListener(OnRotChanged);
    }

    void OnDestroy()
    {
        // Tháo listener để tránh leak
        speedSlider.onValueChanged.RemoveListener(OnSpeedChanged);
        rotSlider.onValueChanged.RemoveListener(OnRotChanged);
    }

    private void OnSpeedChanged(float v)
    {
        speedText.text = $"Speed: {v:0}";
        PlayerPrefs.SetFloat(KEY_SPEED, v);
        PlayerPrefs.Save();
    }

    private void OnRotChanged(float v)
    {
        rotText.text = $"Rotation: {v:0}";
        PlayerPrefs.SetFloat(KEY_ROT, v);
        PlayerPrefs.Save();
    }
}
