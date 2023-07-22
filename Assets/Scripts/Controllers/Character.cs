using System;
using UnityEngine;

namespace Controllers
{
    public abstract class Character : MonoBehaviour
    {
        //в дальнейшем у персонажа может быть HP и условия победы изменятся 
        public float HpCharacter  { get; set; }
        public float MoveSpeed { get; set; }

        protected Animator _animator;
        
        protected bool _isWalking;
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            HpCharacter = ConfigManager.Hp;
        }

        private void Animator()
        {
            if (_isWalking)
            {
                _animator.SetFloat("Speed", 1);
            }
            else
            {
                _animator.SetFloat("Speed", 0);
            }
        }

        protected void IsWalking(bool isWalking)
        {
            _isWalking = isWalking;
            Animator();
        }
    }
}
