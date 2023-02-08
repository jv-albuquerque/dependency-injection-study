using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Major.SpaceInvaders.Enemy
{
    public interface ISwarmController
    {
        event Action OnMove;

        void RegisterEnemiesList(List<EnemyController> list);
        void OnEnemyDie(EnemyController enemy);
        void OnHitLimits();
    }
}
