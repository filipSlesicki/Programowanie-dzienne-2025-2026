using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextTest : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI label;
    [SerializeField] Button button;
    [SerializeField] TMP_InputField inputField;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(string.IsNullOrEmpty(inputField.text))
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }
}
