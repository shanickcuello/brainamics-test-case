using DG.Tweening;
using UnityEngine;

namespace Coins
{
    [CreateAssetMenu(fileName = "AnimationSettings", menuName = "Coin/AnimationSettings", order = 0)]
    public class CoinsAnimationSettings : ScriptableObject
    {
        [SerializeField] public Vector3 rotationVector;
        [SerializeField] public float rotationSpeed;
        [SerializeField] public RotateMode rotateMode;
        [SerializeField] public bool relative;
        [SerializeField] public Ease easeAnimationCurve;
        [SerializeField] public float duration;
        [Header("Set -1 for infinit loop")]
        public int loopsAmount;
    }
}