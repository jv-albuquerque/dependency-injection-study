using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Major.SpaceInvaders.Enemy
{
    public interface ISwarmController
    {
        public event Action OnMove;

        void OnHitLimits();
    }
}
