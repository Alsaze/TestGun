using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public abstract class Booster
    {
        public int Price { get; private set; }

        protected Booster(int price)
        {
            Price = price;
        }

        public abstract void Activate();
    }
}