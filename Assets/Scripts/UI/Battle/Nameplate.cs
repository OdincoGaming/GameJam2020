using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class Nameplate : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameLabel;
    [SerializeField] private TextMeshProUGUI levelLabel;

    [SerializeField] private Slider hpBar;

    [SerializeField] private Transform[] buffZones;
    private List<GameObject> buffs = new List<GameObject>();

    /// <summary>
    /// create serialize fields for bar handle alpha values
    /// [SerializeField] private Image hpHandle;
    /// hpAlpha = hpHandle.color(125,219,151, alphaValue) (r,g,b,a)
    /// </summary>

    private Character _fighter;

    public void Initialize(Character fighter)
    { 
        _fighter = fighter;
        Attributes attr = fighter.GetComponent<Attributes>();

        nameLabel.text = attr.Name;
        levelLabel.text = $"Level: {attr.Level.ToString()}";

        hpBar.maxValue = attr.stats.MaxHealth;
        hpBar.value = attr.stats.CurrentHealth;

    }

    public void Update()
    {
        UpdateStatBars();
    }
        
    private void UpdateStatBars()
    {
        Stats stats = _fighter.GetComponent<Stats>();
        hpBar.value = stats.CurrentHealth;   
    }
}