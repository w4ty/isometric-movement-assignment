using System;
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
    [SerializeField]
    private InteractionManager interactionManager;
    private List<Button> buttons = new();
    public event Action<ISelectable> OnSelectable;

    public void CreateButton(string text, AllyCharacter character)
    {
        var instance = Instantiate(button);
        instance.transform.SetParent(panel.transform);
        buttons.Add(instance);
        instance.GetComponentInChildren<TMP_Text>(false).SetText(text);
        instance.onClick.AddListener(delegate { OnClick(character); });
    }

    private void OnClick(AllyCharacter character)
    {
        OnSelectable?.Invoke(character as ISelectable);
    }
}
