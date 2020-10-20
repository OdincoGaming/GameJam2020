using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BattleUI : MonoBehaviour
{
    [SerializeField] private Nameplate playerNameplate;
    [SerializeField] private Nameplate enemyNameplate;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private GameObject PauseScreen;

    public void Initialize(Character player, Character enemy)
    {
        InitializeChar(player, enemy);
    }

    public void SetDialogText(string text)
    {
        dialogText.text = text;
    }

    public void ShowPauseMenu()
    {
        PauseScreen.SetActive(true);
    }

    public void HidePauseMenu()
    {
        PauseScreen.SetActive(false);
    }

    private void InitializeChar(Character player, Character enemy)
    {
        playerNameplate.Initialize(player);
        enemyNameplate.Initialize(enemy);

    }
}
