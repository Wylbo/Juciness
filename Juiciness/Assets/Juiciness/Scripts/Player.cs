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
        [SerializeField] private float maxSpeed;
        [SerializeField] private float acceleration;
        [SerializeField] private float friction;
        [Space]
        [SerializeField] private float jumpForce;
        [SerializeField] private float jumpDuration;
        [SerializeField] private float fallForce;


        private float elapsedTimeJump;
        private bool isGrounded;

        private Vector3 acc = new Vector3();
        private Vector3 velocity = new Vector3();

        private PlayerController inputController;

        private void Start() {
            inputController = GetComponent<PlayerController>();
        }

        private void FixedUpdate() {
            Move();
        }

        private void Move() {
            acc += inputController.GetAxis() * acceleration * Time.deltaTime;
            velocity += acc * Time.deltaTime;
            var lFriction = Mathf.Pow(friction, Time.deltaTime);
            velocity *= lFriction;

            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

            transform.position += velocity * Time.deltaTime;

            acc = Vector3.zero;


        }

    }
}