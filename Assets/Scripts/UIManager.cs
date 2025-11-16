using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text moneyText;
    public Text hashrateText;
    public Text priceText;
    public Button buySlotButton;
    public Button[] buyGPUButtons = new Button[4];
    
    private PlayerData playerData;
    private CryptoMarket cryptoMarket;
    
    private void Start()
    {
        playerData = GetComponent<PlayerData>();
        cryptoMarket = GetComponent<CryptoMarket>();
        
        if (buySlotButton != null)
            buySlotButton.onClick.AddListener(() => GameManager.instance.BuySlot());
        
        for (int i = 0; i < buyGPUButtons.Length; i++)
        {
            int index = i;
            if (buyGPUButtons[i] != null)
                buyGPUButtons[i].onClick.AddListener(() => GameManager.instance.BuyGPU(index));
        }
    }
    
    public void UpdateUI()
    {
        if (playerData == null || cryptoMarket == null) return;
        
        if (moneyText != null)
            moneyText.text = $"Money: ${playerData.money:F2}";
        
        if (hashrateText != null)
            hashrateText.text = $"Hashrate: {playerData.GetTotalHashrate():F0} MH/s";
        
        if (priceText != null)
            priceText.text = $"BTC Price: ${cryptoMarket.GetCurrentCryptoPrice():F0}";
    }
}
