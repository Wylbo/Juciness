///-----------------------------------------------------------------
/// Author : Maximilien Galea
/// Date : 07/12/2019 17:44
///-----------------------------------------------------------------

using UnityEngine;

namespace Com.MaximilienGalea.Juiciness.Juiciness {
    public class PlayerController : MonoBehaviour {

        [SerializeField] private string horizontalAxis;
        [SerializeField] private string verticalAxis;
        [SerializeField] private string jumpKey;


        private void Update() {

        }

        public Vector3 GetAxis() {
            float hori = Input.GetAxis(horizontalAxis);
            float vert = Input.GetAxis(verticalAxis);

            return new Vector3(hori, 0, vert);
        }

        public bool Jump() {
            return Input.GetAxis(jumpKey) != 0; 
        }
    }
}