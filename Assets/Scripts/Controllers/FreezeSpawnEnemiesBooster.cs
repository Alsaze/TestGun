using UnityEngine;

namespace Controllers
{
    public class FreezeSpawnEnemiesBooster : Booster
    {
        public FreezeSpawnEnemiesBooster(int price) : base(price)
        {
        }

        public override void Activate()
        {
            ConfigManager.Gold -= Price;
            ConfigManager.FrequencySpawn =
                ConfigManager.FrequencySpawn = 5;
        }
    }
}