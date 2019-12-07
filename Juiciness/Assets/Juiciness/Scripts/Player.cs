///-----------------------------------------------------------------
/// Author : Maximilien Galea
/// Date : 07/12/2019 17:42
///-----------------------------------------------------------------

using System;
using UnityEngine;

namespace Com.MaximilienGalea.Juiciness.Juiciness {
    public class Player : MonoBehaviour {
        [SerializeField] private LayerMask groundMask;
        [Space]
        [SerializeField] private float speed;
        [SerializeField] private float jumpForce;
        [SerializeField] private float jumpDuration;
        [SerializeField] private float fallForce;


        private float elapsedTimeJump;
        private bool isGrounded;

        private PlayerController controller;
        private void Start() {
            controller = GetComponent<PlayerController>();
        }

        private void FixedUpdate() {
            isGrounded = Physics.Raycast(transform.position, Vector3.down, .7f, groundMask);

            transform.position += controller.GetAxis() * speed * Time.deltaTime;

            if (controller.Jump()) {
                Jump();
                elapsedTimeJump += Time.deltaTime;
            } else if (!isGrounded) {
                Fall();
            }
            
        }

        private void Fall() {
            transform.position += Vector3.down * fallForce * Time.deltaTime;
        }

        private void Jump() {
            isGrounded = false;
            transform.position += jumpForce * Vector3.up * Time.deltaTime;
            
        }
    }
}