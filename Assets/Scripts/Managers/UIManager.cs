using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Button button;
    [SerializeField]
    private GameObject panel;
    private List<Button> buttons = new();

    public void CreateButton(string text)
    {
        var instance =  Instantiate(button);
        instance.transform.SetParent(panel.transform);
        buttons.Add(instance);
        instance.GetComponentInChildren<TMP_Text>(false).SetText(text);
    }
}
