using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickerManager : MonoBehaviour
{
    [Header("Game Stats")]
    public int money;
    public int moneyForTap = 5;
    public int upgradeLevel = 1;
    public int upgradeCost = 20;

    [Header("Settings")]

    public float muliplier = 1.15f;
    public float moneySpeed = 1;

    [Header("Links")]
    public TMP_Text moneyCounterText;
    public TMP_Text upgradeLevelText;    
    public TMP_Text upgradeCostText;
    public TMP_Text tapButtonText;
    public Button upgradeButton; 
    public GameObject moneyPrefub;

    private void Start() {
        UpdateText();
    }

    private void Update() {
        UpgradeButtonDisable();
    }

    private void UpdateText() {
        moneyCounterText.text = money.ToString();
        upgradeLevelText.text = "LVL " + upgradeLevel.ToString();
        upgradeCostText.text = "UPGRADE " + upgradeCost;
        tapButtonText.text = "+" + moneyForTap * upgradeLevel;
    }

    public void TapSystem(){
        money += upgradeLevel * moneyForTap;
        moneyCounterText.text = money.ToString();
        TapParticleSystem();
    }

    private void UpgradeButtonDisable(){
        if(money < upgradeCost)
            upgradeButton.interactable = false;
        else
            upgradeButton.interactable = true;
    }

    public void UpgradeSystem(){
        if(money >= upgradeCost)
        {
            upgradeLevel++;
            money -= upgradeCost;
            upgradeCost = (int)(upgradeCost * muliplier);

            UpdateText();
        }
    }

    private void TapParticleSystem()
    {
        GameObject money = Instantiate(moneyPrefub, Input.mousePosition, Quaternion.Euler(0, 0, Random.Range(0f, 360f)), GameObject.FindGameObjectWithTag("UI").transform);
        money.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(2.5f, 3f)) * moneySpeed * 100, ForceMode2D.Impulse);
    }
}
