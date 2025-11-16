using UnityEngine;

public class CryptoMarket : MonoBehaviour
{
    private float bitcoinPrice = 45000f; // Starting price
    private float priceChangeSpeed = 100f; // How much price fluctuates per second
    private float timeUntilPriceChange = 0f;
    private float priceChangeInterval = 5f; // Change price every 5 seconds
    
    private void Update()
    {
        timeUntilPriceChange += Time.deltaTime;
        if (timeUntilPriceChange >= priceChangeInterval)
        {
            RandomizePriceChange();
            timeUntilPriceChange = 0f;
        }
    }
    
    private void RandomizePriceChange()
    {
        float randomChange = Random.Range(-priceChangeSpeed, priceChangeSpeed);
        bitcoinPrice += randomChange;
        bitcoinPrice = Mathf.Max(bitcoinPrice, 1000f); // Minimum price
    }
    
    public float GetCurrentCryptoPrice()
    {
        return bitcoinPrice;
    }
    
    public void SetCryptoPrice(float newPrice)
    {
        bitcoinPrice = Mathf.Max(newPrice, 1000f);
    }
}
