using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LocalizedText : MonoBehaviour
{
    public string DictionaryKey;

    private void Start()
    {
        GetComponent<TextMeshProUGUI>().text = Locale.Get(DictionaryKey);
    }
}
