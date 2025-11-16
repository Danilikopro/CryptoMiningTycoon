PROJECT_SETUP.md# Crypto Mining Tycoon - Project Setup Guide

## Project Structure

```
CryptoMiningTycoon/
├── Assets/
│   ├── Scripts/
│   │   ├── GameManager.cs         # Main game controller
│   │   ├── PlayerData.cs          # Player data and GPU management
│   │   ├── CryptoMarket.cs        # Cryptocurrency price simulation
│   │   └── UIManager.cs           # UI updates and input handling
│   ├── UI/
│   │   └── (UI Canvas and Prefabs)
│   └── Scenes/
│       └── MainScene.unity
├── .gitignore
└── README.md
```

## Setup Instructions

### 1. Create a New Unity Project
- Open Unity Hub
- Create a new **2D** project (Unity 2021.3 or higher recommended)
- Name it: `CryptoMiningTycoon`

### 2. Clone/Setup Project
```bash
git clone https://github.com/Danilikopro/CryptoMiningTycoon.git
```

### 3. Set Up Scripts
1. Copy all .cs files from `Assets/Scripts/` to `Assets/Scripts/` in your Unity project
2. Unity will automatically recompile

### 4. Create Main Scene
1. Create a new scene called "MainScene"
2. Create an empty GameObject called "GameManager"
3. Add these components (scripts) to GameManager:
   - GameManager.cs
   - PlayerData.cs
   - CryptoMarket.cs
   - UIManager.cs

### 5. Create UI Canvas
1. Create a Canvas (Right-click in Hierarchy > UI > Canvas)
2. Add Text elements:
   - Money Display
   - Hashrate Display
   - Price Display
3. Add Buttons:
   - Buy Slot Button
   - Buy GPU Buttons (4 buttons for 4 GPU types)

### 6. Assign UI References
In the Inspector, with GameManager selected:
- Drag Text elements to corresponding fields in UIManager script
- Drag Buttons to corresponding fields

### 7. Save and Test
- Save the scene as `Assets/Scenes/MainScene.unity`
- Press Play to test

## Core Systems

### GameManager
- Singleton pattern implementation
- Manages game state and updates
- Calculates mining income every second
- Handles purchases

### PlayerData
- Tracks player money and total hashrate
- Manages GPU inventory and mining slots
- Handles GPU purchasing
- Calculates total mining capacity

### CryptoMarket
- Simulates cryptocurrency price fluctuations
- Updates prices every 5 seconds
- Random price changes (±100 per update)

### UIManager
- Updates all display texts
- Connects buttons to game logic
- Displays real-time stats

## Gameplay Loop

1. Player starts with $100 and 1 mining slot
2. Buys GPU from 4 available types (GTX 1060, RTX 2080, RTX 3090, RTX 4090)
3. Each GPU generates cryptocurrency based on its hashrate
4. Bitcoin price fluctuates randomly
5. Player can sell mined crypto for profit
6. Use profit to buy more slots and GPUs
7. Build a mining empire!

## Next Steps

- [ ] Add visual graphics for GPU cards
- [ ] Implement save/load system
- [ ] Add prestige/reset mechanic
- [ ] Create upgrade shop for efficiency
- [ ] Add achievements system
- [ ] Implement offline progression
