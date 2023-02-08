using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Major.SpaceInvaders.Enemy
{
    public class SpawnSwarm : MonoBehaviour
    {
        [SerializeField] private List<EnemyController> _lineEnemyPrefab;
        [Space]
        [SerializeField] private int _nColumns = 10;
        [Space]
        [SerializeField] private float _horizontalOffset = 0.4f;
        [SerializeField] private float _verticalOffset = -0.25f;
        [SerializeField] private Vector2 _firstPos = new Vector2(-1.8f, 2.25f);

        private ISwarmController _swarmController;

        private void Start()
        {
            _swarmController = GetComponent<ISwarmController>();

            SpawnMatrix();
        }

        private void SpawnMatrix()
        {
            List<EnemyController> enemies = new List<EnemyController>();
            for (int line = 0; line < _lineEnemyPrefab.Count; line++)
            {
                for (int column = 0; column < _nColumns; column++)
                {
                    var enemy = Spawn(_lineEnemyPrefab[line], _firstPos + new Vector2(column * _horizontalOffset, line * _verticalOffset));
                    enemies.Add(enemy);
                }
            }

            _swarmController.RegisterEnemiesList(enemies);
        }

        private EnemyController Spawn(EnemyController prefab, Vector2 position)
        {
            var enemy = Instantiate(prefab, transform);
            enemy.transform.position = position;
            enemy.Set(_swarmController);

            return enemy;
        }
    }
}
