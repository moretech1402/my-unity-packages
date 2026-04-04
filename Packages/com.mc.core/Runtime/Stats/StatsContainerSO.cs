using System;
using System.Collections.Generic;
using UnityEngine;

namespace MC.Core.Stats
{
    [Serializable]
    public class StatEntry
    {
        [SerializeField] private StatDefinitionSo _stat;
        [SerializeField] private int _value;

        public StatDefinitionSo Stat => _stat;
        public int Value => _value;

        public StatId Id => Stat.Id;
    }

    [CreateAssetMenu(
        fileName = "StatsContainerSO",
        menuName = "Game/Stats/Create Stats Container"
    )]
    public class StatsContainerSo : ScriptableObject
    {
        [SerializeField] private List<StatEntry> _stats = new();

        public IReadOnlyList<StatEntry> Stats => _stats;

        public bool TryGetStatValue(StatDefinitionSo stat, out int value)
        {
            if (stat != null)
            {
                // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
                foreach (var entry in _stats)
                {
                    if (entry.Stat != stat) continue;
                    value = entry.Value;
                    return true;
                }
            }

            value = 0;
            return false;
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_stats == null)
                return;

            var seenStats = new Dictionary<StatDefinitionSo, int>();

            for (var i = 0; i < _stats.Count; i++)
            {
                var stat = _stats[i].Stat;

                if (stat == null)
                    continue;

                if (seenStats.TryGetValue(stat, out var firstIndex))
                {
                    Debug.LogError(
                        $"Duplicate stat '{stat.name}' detected in '{name}' at index {i}. First occurrence at index {firstIndex}.",
                        this
                    );
                }
                else
                {
                    seenStats.Add(stat, i);
                }
            }
        }
#endif
    }
}