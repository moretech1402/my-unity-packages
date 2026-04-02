using UnityEngine;

namespace MC.Game.Stats
{
    [CreateAssetMenu(fileName = "StatsContainerSO", menuName = "Game/Stats/Create Stats Container")]
    public class StatsContainerSo : ScriptableObject
    {
        public int health = 100;
        public int mana = 50;
        public int stamina = 75;
        public int strength = 10;
        public int speed = 10;
        public int attack = 0;
        public int defense = 0;
    }
}
