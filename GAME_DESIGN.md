# Crypto Mining Tycoon - Game Design Document

## Core Concept

A simple idle/incremental tycoon game where players build a cryptocurrency mining empire. The game combines real GPU hardware, Bitcoin pricing simulation, and progressive upgrades to create an addictive gameplay loop.

## Win Condition

There is no "winning" state. The game is infinite progression with:
- Exponential income growth
- Prestige/reset mechanics (future)
- New content at specific milestones

## Core Mechanics

### 1. Mining Income
- **Base Formula**: `Hourly Income = (Total Hashrate / 1,000,000) × Bitcoin Price`
- **Hashrate**: Measured in MH/s (Megahashes per second)
- **Bitcoin Price**: Fluctuates between $1,000 - $100,000
- **Update Frequency**: Every second in-game

### 2. GPU Cards (Current)

| GPU | Hashrate | Cost | Efficiency |
|-----|----------|------|------------|
| GTX 1060 | 25 MH/s | $50 | Starter card |
| RTX 2080 | 100 MH/s | $300 | Standard |
| RTX 3090 | 150 MH/s | $800 | High-end |
| RTX 4090 | 250 MH/s | $1,600 | Flagship |

### 3. Mining Slots
- Player starts with 1 slot
- Each slot can hold 1 GPU (currently)
- New slots cost: Base $1,000 × (1.15^slot_number)
- Maximum 10 slots per mining rig

### 4. Cryptocurrency Market
- **Current Asset**: Bitcoin
- **Starting Price**: $45,000
- **Price Update**: Every 5 seconds
- **Random Change**: ±$100 per update
- **Price Range**: $1,000 - $100,000

## Progression System

### Early Game (0-10 minutes)
- Earn initial $100
- Buy first GPU (GTX 1060)
- Unlock understanding of income system
- Start earning passive income

### Mid Game (10 minutes - 1 hour)
- Accumulate $500-$5,000
- Buy multiple GPUs
- Unlock 3-5 mining slots
- Observe Bitcoin price fluctuations
- Plan purchases based on income vs. cost

### Late Game (1+ hours)
- Accumulate $10,000+
- Fill mining slots with high-end GPUs
- Consider purchasing additional slots
- Monitor price changes for optimal selling

## Monetization (Future)

### Free to Play
- No hard paywall
- All content accessible without spending

### Optional IAP
- **Cosmetics**: GPU skins, mining rig themes
- **Time Savers**: 
  - ×2 income boost (1 hour) - $0.99
  - Instant slot unlock - $1.99
  - Bonus starting capital - $4.99
- **Convenience**: 
  - Ads removal - $2.99
  - Auto-sell optimization - $1.99

### Ad Revenue
- Watch ads for:
  - 1-hour income multiplier (×2)
  - Immediate resource collection
  - Special discounts

## UI/UX Elements

### Main Screen
- **Top Left**: Current Money Balance
- **Top Center**: Total Hashrate
- **Top Right**: Bitcoin Price
- **Center**: Mining Slots Display (Grid)
- **Bottom**: GPU Purchase Buttons (4 types)
- **Right Sidebar**: Additional Slots to Buy

### Visual Feedback
- Green text for income gains
- Red text for price drops
- Animations for GPU installations
- Particle effects for mining activity

## Technical Implementation

### Scripts
1. **GameManager**: Main game loop (1 second updates)
2. **PlayerData**: Currency, GPU inventory, slot management
3. **CryptoMarket**: Price simulation and volatility
4. **UIManager**: Real-time display updates

### Save System (Future)
- Persist: Money, GPU inventory, unlocked slots, playtime
- Cloud sync option for mobile
- Auto-save every minute
- Auto-save on app close

### Offline Progression (Future)
- When app closed, calculate: `Offline Time × Hourly Income`
- Show "Earned while away" notification
- Optional 2x multiplier on offline earnings (IAP)

## Future Features (Roadmap)

### Phase 1 (Month 1)
- [ ] Save/load system
- [ ] Visual GPU card representations
- [ ] Sound effects
- [ ] Better animations

### Phase 2 (Month 2)
- [ ] Prestige/reset mechanic
- [ ] Permanent multipliers ("power-ups")
- [ ] Achievement system
- [ ] Leaderboards

### Phase 3 (Month 3)
- [ ] Additional cryptocurrencies (Ethereum, Litecoin, etc.)
- [ ] Power consumption management
- [ ] Cooling systems
- [ ] Electricity cost calculation

### Phase 4 (Long-term)
- [ ] Procedural GPU generation
- [ ] Custom mining rigs
- [ ] Trading system with other players
- [ ] Real-time multiplayer elements

## Balancing

### Economic Balance
- Prices scale to prevent player boredom
- Each GPU tier is ~4x the cost of previous
- Each GPU tier is ~2.5x more efficient
- New slots cost increases exponentially

### Time Gates
- Early purchases: 1-5 minutes
- Mid purchases: 5-30 minutes
- Late purchases: 30+ minutes
- Prevents power creep and maintains engagement

## Player Retention

### Short-term (Minutes)
- Immediate income feedback
- Quick purchase gratification
- Visual changes upon GPU install

### Medium-term (Hours)
- Unlock new GPU tiers
- Unlock new slots
- See exponential growth

### Long-term (Days)
- Prestige mechanics
- Achievements
- New content/features
- Community competition

## Target Audience

- **Age**: 13-50
- **Platform**: PC (Steam) initially, mobile later
- **Genre Fans**: 
  - Tycoon game enthusiasts
  - Incremental game fans
  - Cryptocurrency enthusiasts
  - Strategy game players

## Success Metrics

- DAU (Daily Active Users)
- Average Session Length: 5-30 minutes
- Retention Rate: 30% day-30
- IAP Conversion: 2-5%
- Revenue per User: $0.50-$2.00
