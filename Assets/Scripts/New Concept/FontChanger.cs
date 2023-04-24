using UnityEngine;
using TMPro;
public class FontChanger : MonoBehaviour
{
    public TMP_FontAsset font;
    void OnValidate()
    {
        foreach (var text in FindObjectsOfType<TextMeshProUGUI>())
        {
            text.font = this.font;
        }
    }
}