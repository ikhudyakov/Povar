using System;
using System.Collections.Generic;
using UnityEngine;

namespace Configs
{
    public enum AnimState
    {
        Idle = 0,
        Run = 1,
        JumpUp = 2,
        JumpDown = 3
    }

    [CreateAssetMenu(fileName = "SpriteAnimationConfig", menuName = "Configs/ Animation", order = 1)]
    public class SpriteAnimatorConfig : ScriptableObject
    {
        [Serializable]
        public sealed class SpriteSequence
        {
            public AnimState Track;
            public List<Sprite> Sprites = new List<Sprite>();
        }

        public List<SpriteSequence> Sequence = new List<SpriteSequence>();
    }
}