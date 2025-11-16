using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text moneyText;
    [SerializeField] private Text hashrateText;
    [SerializeField] private Text priceText;
    [SerializeField] private Button buySlotButton;
    [SerializeField] private Button[] buyGPUButtons = new Button[4];
    
    private PlayerData playerData;
    private CryptoMarket cryptoMarket;
    private GameManager gameManager;
    
    private void Start()
    {
        gameManager = GameManager.instance;
        
        if (gameManager == null)
        {
            Debug.LogError("GameManager instance not found!");
            return;
        }
        
        playerData = gameManager.GetPlayerData();
        cryptoMarket = gameManager.GetCryptoMarket();
        
        // Setup button listeners
        if (buySlotButton != null)
        {
            buySlotButton.onClick.AddListener(() => gameManager.BuySlot());
        }
        else
        {
            Debug.LogWarning("Buy Slot Button not assigned in UIManager");
        }
        
        for (int i = 0; i < buyGPUButtons.Length; i++)
        {
            if (buyGPUButtons[i] != null)
            {
                int index = i;
                buyGPUButtons[i].onClick.AddListener(() => gameManager.BuyGPU(index));
            }
        }
        
        // Initial UI update
        UpdateUI();
    }
    
    public void UpdateUI()
    {
        if (playerData == null || cryptoMarket == null)
        {
            return;
        }
        
        // Update money display
        if (moneyText != null)
        {
            moneyText.text = $"Money: ${playerData.money:F2}";
        }
        
        // Update hashrate display
        if (hashrateText != null)
        {
            float totalHashrate = playerData.GetTotalHashrate();
            hashrateText.text = $"Hashrate: {totalHashrate:F0} MH/s";
        }
        
        // Update price display
        if (priceText != null)
        {
            float btcPrice = cryptoMarket.GetCurrentCryptoPrice();
            priceText.text = $"BTC Price: ${btcPrice:F0}";
        }
    }
    
    // Optional: Update UI at regular intervals for real-time feedback
    private void Update()
    {
        // Update UI every frame for smooth animations
        UpdateUI();
    }
}
