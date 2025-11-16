using UnityEngine;
using System.Collections.Generic;

public class PlayerData : MonoBehaviour
{
    public float money = 100f; // Starting money
    
    private List<GPU> ownedGPUs = new List<GPU>();
    private List<MiningSlot> miningSlots = new List<MiningSlot>();
    private int unlockedSlots = 1;
    private float slotCost = 1000f;
    
    public void Initialize()
    {
        // Initialize first slot
        if (miningSlots.Count == 0)
        {
            miningSlots.Add(new MiningSlot());
        }
    }
    
    public float GetTotalHashrate()
    {
        float total = 0f;
        foreach (var slot in miningSlots)
        {
            if (slot != null && slot.gpu != null)
            {
                total += slot.gpu.hashrate;
            }
        }
        return total;
    }
    
    public void AddMoney(float amount)
    {
        money += Mathf.Max(0, amount);
    }
    
    public bool BuyGPU(int gpuIndex)
    {
        GPU gpu = GetGPUByIndex(gpuIndex);
        if (gpu != null && money >= gpu.cost)
        {
            money -= gpu.cost;
            GPU newGPU = new GPU
            {
                name = gpu.name,
                hashrate = gpu.hashrate,
                cost = gpu.cost,
                powerUsage = gpu.powerUsage
            };
            ownedGPUs.Add(newGPU);
            return true;
        }
        return false;
    }
    
    public bool BuySlot()
    {
        if (money >= slotCost && unlockedSlots < 10)
        {
            money -= slotCost;
            unlockedSlots++;
            slotCost *= 1.15f; // Increase cost for next slot
            miningSlots.Add(new MiningSlot());
            return true;
        }
        return false;
    }
    
    public bool InstallGPU(int slotIndex, int gpuIndex)
    {
        if (slotIndex >= 0 && slotIndex < miningSlots.Count && gpuIndex >= 0 && gpuIndex < ownedGPUs.Count)
        {
            miningSlots[slotIndex].gpu = ownedGPUs[gpuIndex];
            return true;
        }
        return false;
    }
    
    private GPU GetGPUByIndex(int index)
    {
        GPU[] gpuDatabase = new GPU[]
        {
            new GPU { name = "GTX 1060", hashrate = 25f, cost = 50f, powerUsage = 120f },
            new GPU { name = "RTX 2080", hashrate = 100f, cost = 300f, powerUsage = 250f },
            new GPU { name = "RTX 3090", hashrate = 150f, cost = 800f, powerUsage = 350f },
            new GPU { name = "RTX 4090", hashrate = 250f, cost = 1600f, powerUsage = 450f },
        };
        
        if (index >= 0 && index < gpuDatabase.Length)
        {
            return gpuDatabase[index];
        }
        return null;
    }
    
    public int GetUnlockedSlots() => unlockedSlots;
    public int GetTotalSlots() => miningSlots.Count;
    public List<MiningSlot> GetMiningSlots() => miningSlots;
    public List<GPU> GetOwnedGPUs() => ownedGPUs;
}

public class GPU
{
    public string name;
    public float hashrate; // MH/s
    public float cost;
    public float powerUsage; // Watts
}

public class MiningSlot
{
    public GPU gpu;
    public bool isActive = true;
}
