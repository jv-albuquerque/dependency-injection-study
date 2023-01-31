using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Major.SpaceInvaders.Enemy
{
    public class SpawnSwarm : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        [Space]
        [SerializeField] private int nLines = 6;
        [SerializeField] private int nColumns = 10;
        [Space]
        [SerializeField] private float horizontalOffset;
        [SerializeField] private float verticalOffset;
        [SerializeField] private Vector2 firstPos;

        private void Start()
        {
            for (int line = nLines - 1; line >= 0; line--)
            {
                for (int column = 0; column < nColumns; column++)
                {
                    var enemy = Instantiate(enemyPrefab, transform);

                    enemy.transform.position = firstPos + new Vector2(column * horizontalOffset, line * verticalOffset);
                }
            }
        }
    }
}
