using UnityEngine;

public class CryptoMarket : MonoBehaviour
{
    private float bitcoinPrice = 45000f; // Starting price
    private float priceChangeSpeed = 100f; // How much price fluctuates per update
    private float timeUntilPriceChange = 0f;
    private const float PRICE_CHANGE_INTERVAL = 5f; // Change price every 5 seconds
    private const float MIN_PRICE = 1000f;
    private const float MAX_PRICE = 100000f;
    
    private void Update()
    {
        timeUntilPriceChange += Time.deltaTime;
        if (timeUntilPriceChange >= PRICE_CHANGE_INTERVAL)
        {
            RandomizePriceChange();
            timeUntilPriceChange = 0f;
        }
    }
    
    private void RandomizePriceChange()
    {
        float randomChange = Random.Range(-priceChangeSpeed, priceChangeSpeed);
        bitcoinPrice += randomChange;
        
        // Clamp price within min/max range
        bitcoinPrice = Mathf.Clamp(bitcoinPrice, MIN_PRICE, MAX_PRICE);
    }
    
    public float GetCurrentCryptoPrice()
    {
        return bitcoinPrice;
    }
    
    public void SetCryptoPrice(float newPrice)
    {
        bitcoinPrice = Mathf.Clamp(newPrice, MIN_PRICE, MAX_PRICE);
    }
    
    public float GetPriceChangeSpeed() => priceChangeSpeed;
    public void SetPriceChangeSpeed(float newSpeed) => priceChangeSpeed = Mathf.Max(0, newSpeed);
}
