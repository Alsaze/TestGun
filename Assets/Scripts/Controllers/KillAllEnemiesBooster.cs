using UnityEngine;

namespace Controllers
{
    public class KillAllEnemiesBooster : Booster
    {
        public KillAllEnemiesBooster(int price) : base(price)
        {
        }

        public override void Activate()
        {
            ConfigManager.Gold -= Price;
            for (int i = 0; i < ConfigManager.Enemy.Count; i++)
            {
                MonoBehaviour.Destroy(ConfigManager.Enemy[i]);
                ConfigManager.Score += 100;
                ConfigManager.Gold += 1;
            }
            ConfigManager.Enemy.Clear();
        }
    }
}