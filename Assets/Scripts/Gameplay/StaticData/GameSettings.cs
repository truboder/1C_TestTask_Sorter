using UnityEngine;
using Utils.Helpers;

namespace Gameplay.StaticData
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Game/GameSettings")]
    public class GameSettings : ScriptableObject
    {
        [Header("Game Settings")]
        public Range<float> ShapesCountRange = new Range<float>(50f, 100f);
        public Range<float> SpawnTimeoutRange = new Range<float>(1f, 3f);
        public Range<float> ShapeSpeedRange = new Range<float>(2f, 5f);
        public int PlayerHealth = 3;
    }
}