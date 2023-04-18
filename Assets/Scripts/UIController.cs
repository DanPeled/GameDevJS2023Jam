using UnityEngine;
using TMPro;
public class UIController : MonoBehaviour
{
    public GameObject debugParent;
    public TextMeshProUGUI fpsText;
    public bool debugMode;
    public int fps;
    private float deltaTime;

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        fpsText.text = $"{fps}";
    }
    void Awake()
    {
        debugParent.SetActive(debugMode);
    }
    public void FixedUpdate()
    {
        fps = GetFPS();


        if (Input.GetKeyDown(KeyCode.F3))
        {
            debugMode = !debugMode;
            debugParent.SetActive(debugMode);
        }

    }
    public int GetFPS()
    {
        return Mathf.RoundToInt(1.0f / deltaTime);
    }
}