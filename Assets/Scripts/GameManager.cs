using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public PlayerData playerData;
    public CryptoMarket cryptoMarket;
    public UIManager uiManager;
    
    private float miningTick = 0f;
    private float miningInterval = 1f; // Update income every second
    
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
        playerData = GetComponent<PlayerData>();
        cryptoMarket = GetComponent<CryptoMarket>();
        uiManager = GetComponent<UIManager>();
        
        if (playerData == null) playerData = gameObject.AddComponent<PlayerData>();
        if (cryptoMarket == null) cryptoMarket = gameObject.AddComponent<CryptoMarket>();
        if (uiManager == null) uiManager = gameObject.AddComponent<UIManager>();
    }
    
    private void Update()
    {
        miningTick += Time.deltaTime;
        if (miningTick >= miningInterval)
        {
            UpdateMiningIncome();
            miningTick = 0f;
        }
    }
    
    private void UpdateMiningIncome()
    {
        float totalHashrate = playerData.GetTotalHashrate();
        float currentCryptoPrice = cryptoMarket.GetCurrentCryptoPrice();
        float income = (totalHashrate / 1000000f) * currentCryptoPrice; // Hashrate is in MH/s, convert to profit
        
        playerData.AddMoney(income);
        uiManager.UpdateUI();
    }
    
    public void BuyGPU(int gpuIndex)
    {
        playerData.BuyGPU(gpuIndex);
        uiManager.UpdateUI();
    }
    
    public void BuySlot()
    {
        playerData.BuySlot();
        uiManager.UpdateUI();
    }
}
