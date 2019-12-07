///-----------------------------------------------------------------
/// Author : Maximilien Galea
/// Date : 07/12/2019 17:54
///-----------------------------------------------------------------

using UnityEngine;

namespace Com.MaximilienGalea.Juiciness.Juiciness {
	public class Enemy : MonoBehaviour {
	
		[SerializeField] private float jumpHight;
		[SerializeField] private float timeBetweenJump;
        [SerializeField] private float jumpSpeed;

		private float elapsedTime = 0;
        private Vector3 startPosition;

        private void Start() {
            startPosition = transform.position;
        }

        private void Update () {
            if (elapsedTime >= timeBetweenJump) {
                Jump();
                elapsedTime -= timeBetweenJump;
            }
            elapsedTime += Time.deltaTime;
		}

		private void Jump() {
            transform.position = Vector3.MoveTowards(startPosition,startPosition + jumpHight * Vector3.up,jumpSpeed * Time.deltaTime);
		}
	}
}