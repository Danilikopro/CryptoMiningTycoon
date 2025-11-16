using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    private PlayerData playerData;
    private CryptoMarket cryptoMarket;
    private UIManager uiManager;
    
    private float miningTick = 0f;
    private const float MINING_INTERVAL = 1f; // Update income every second
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        // Get or add components
        playerData = GetComponent<PlayerData>();
        if (playerData == null) playerData = gameObject.AddComponent<PlayerData>();
        
        cryptoMarket = GetComponent<CryptoMarket>();
        if (cryptoMarket == null) cryptoMarket = gameObject.AddComponent<CryptoMarket>();
        
        uiManager = GetComponent<UIManager>();
        if (uiManager == null) uiManager = gameObject.AddComponent<UIManager>();
        
        // Initialize systems
        playerData.Initialize();
    }
    
    private void Update()
    {
        if (playerData == null || cryptoMarket == null || uiManager == null)
            return;
            
        miningTick += Time.deltaTime;
        if (miningTick >= MINING_INTERVAL)
        {
            UpdateMiningIncome();
            miningTick = 0f;
        }
    }
    
    private void UpdateMiningIncome()
    {
        float totalHashrate = playerData.GetTotalHashrate();
        float currentCryptoPrice = cryptoMarket.GetCurrentCryptoPrice();
        
        // Calculate income: (Hashrate in MH/s / 1,000,000) * Price per Bitcoin * Time
        float income = (totalHashrate / 1000000f) * currentCryptoPrice;
        
        playerData.AddMoney(income);
        uiManager.UpdateUI();
    }
    
    public void BuyGPU(int gpuIndex)
    {
        if (playerData != null)
        {
            playerData.BuyGPU(gpuIndex);
            uiManager.UpdateUI();
        }
    }
    
    public void BuySlot()
    {
        if (playerData != null)
        {
            playerData.BuySlot();
            uiManager.UpdateUI();
        }
    }
    
    public PlayerData GetPlayerData() => playerData;
    public CryptoMarket GetCryptoMarket() => cryptoMarket;
    public UIManager GetUIManager() => uiManager;
}
