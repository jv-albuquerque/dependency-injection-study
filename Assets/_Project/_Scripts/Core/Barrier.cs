using System.Collections;
using System.Collections.Generic;
using Major.SpaceInvaders.Core;
using UnityEngine;

namespace Major.SpaceInvaders
{
    public class Barrier : MonoBehaviour, IHittable
    {
        [SerializeField] private List<Sprite> sprites;

        private SpriteRenderer render;

        private int life;

        private void Start()
        {
            render = GetComponent<SpriteRenderer>();
            life = sprites.Count;
        }

        public void Hit()
        {
            life--;

            if(life == 0)
            {
                Destroy(gameObject);
                return;
            }

            render.sprite = sprites[sprites.Count - life];
        }
    }
}
