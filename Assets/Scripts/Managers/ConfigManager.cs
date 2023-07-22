using System.Collections.ObjectModel;
using UnityEngine;

public static class ConfigManager
{
    public static float FireDamage = 1;
    public static float FireSpeed = 1;
    public static float Hp = 1;
    public static float MoveSpeedEnemie = 1;
    public static float FrequencySpawn = 5;
    public static ObservableCollection<GameObject> Enemy = new ObservableCollection<GameObject>();
    public static int Gold = 0; 
    public static int Time = 0;
    public static int Score = 0;
    public static float ElapsedTime = 0;
}
