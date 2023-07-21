using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Controllers
{
    public class Player : Character
    {
        [SerializeField] protected  GameObject bulletPrefab;
        [SerializeField] protected  Transform shotPosition;
        [SerializeField] protected  Transform gunPosition;
        
        [SerializeField] private InputSystem inputSystem;
        
        protected bool _isFire;

        private void Start()
        {
            MoveSpeed = 3f;
            _isFire = false;
        }

        private void FixedUpdate()
        {
            Movment();
        }

        private void Update()
        {
            Shot();
        }

        private void Movment()
        {
            Vector2 inputVector = inputSystem.GetMovmentVector2Normalized();

            Vector3 moveDirecrion = new Vector3(inputVector.x, 0f, inputVector.y);
            transform.position += moveDirecrion * MoveSpeed * Time.deltaTime;
            
            //Character.cs => Animator
            _isWalking = moveDirecrion != Vector3.zero ? _isWalking = true : _isWalking = false;
            IsWalking(_isWalking);
        }

        #region Weapon

        private void Shot()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && _isFire == false)
            {
                Fire();
                StartCoroutine("FireSpeedGun"); //кд на выстрел (скорострельность)
            }
        }

        private void Fire()
        {
            GameObject bulletTransform = Instantiate(bulletPrefab, gunPosition.position, Quaternion.identity);

            Vector3 shotDirecrion = (shotPosition.position - gunPosition.position).normalized;
            bulletTransform.GetComponent<Bullet>().Setup(shotDirecrion);
        }

        private IEnumerator FireSpeedGun()
        {
            _isFire = true;
            yield return new WaitForSeconds(ConfigManager.FireSpeed);
            _isFire = false;
        }

        #endregion
    }
}
