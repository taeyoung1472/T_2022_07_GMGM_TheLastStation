using TMPro;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    public TextMeshProUGUI debugText;
    public void ShowText(string str)
    {
        debugText.text = str;
    }
}
