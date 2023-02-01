using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Major.SpaceInvaders.Enemy
{
    public class SpawnSwarm : MonoBehaviour
    {
        [SerializeField] private EnemyController _enemyPrefab;
        [Space]
        [SerializeField] private int _nLines = 6;
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
            for (int line = 0; line < _nLines; line++)
            {
                for (int column = 0; column < _nColumns; column++)
                {
                    Spawn(_firstPos + new Vector2(column * _horizontalOffset, line * _verticalOffset));
                }
            }
        }

        private void Spawn(Vector2 position)
        {
            var enemy = Instantiate(_enemyPrefab, transform);
            enemy.transform.position = position;
            enemy.SetController(_swarmController);
        }
    }
}
