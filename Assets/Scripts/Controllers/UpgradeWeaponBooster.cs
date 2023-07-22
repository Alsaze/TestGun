using UnityEngine;
namespace Controllers
{
    public class UpgradeWeaponBooster : Booster
    {
        public UpgradeWeaponBooster(int price) : base(price)
        {
        }

        public override void Activate()
        {
            ConfigManager.Gold -= Price;
            ConfigManager.FireDamage += 1;
            ConfigManager.FireSpeed -= 0.1f;
        }
    }
}