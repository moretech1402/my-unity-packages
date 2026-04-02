using UnityEngine;

namespace MC.Game.Stats
{
    [CreateAssetMenu(fileName = "StatsContainerSO", menuName = "Game/Stats/Create Stats Container")]
    public class StatsContainerSO : ScriptableObject
    {
        public int Health = 100;
        public int Mana = 50;
        public int Stamina = 75;
        public int Strength = 10;
        public int Speed = 10;
        public int Attack = 0;
        public int Defense = 0;
    }
}
