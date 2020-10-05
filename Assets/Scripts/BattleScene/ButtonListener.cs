using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonListener : MonoBehaviour
{
    public BattleController controller;

    public Button attackButton;
    public Button defendButton;

    public GameObject selectionArea;

    void Start()
    {
        //attackButton.onClick.AddListener(controller.OnAttackButton);
       //defendButton.onClick.AddListener(controller.OnDefendButton);
    }

    public void ChangeButtonText(Button btn, string text)
    {
        TextMeshProUGUI child = btn.GetComponentInChildren<TextMeshProUGUI>();
        child.text = text;
    }

    public void ResetSelectionArea()
    {
        selectionArea.SetActive(true);
    }
}
