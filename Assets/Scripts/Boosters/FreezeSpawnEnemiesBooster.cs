using UnityEngine;

namespace Controllers
{
    public class FreezeSpawnEnemiesBooster : Booster
    {
        public FreezeSpawnEnemiesBooster(int price) : base(price)
        {
        }

        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.R) && ConfigManager.Gold >= Price)
            {
                ConfigManager.Gold -= Price;
                ConfigManager.CanSpawn = false;
            }
        }
    }
}