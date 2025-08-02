using Mirror;
using TMPro;
using UnityEngine;

namespace GameLogic.Views
{
    public class PlayerNameTagView : NetworkBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameText;
        private Camera _cam;

        public override void OnStartClient()
        {
            base.OnStartClient();
            TryAssignCamera();
            nameText.text = string.Empty;
        }

        void LateUpdate()
        {
            if (_cam == null)
            {
                TryAssignCamera();
                if (_cam == null) return;
            }

            Vector3 dir = _cam.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(-dir.normalized, Vector3.up);
        }

        void TryAssignCamera()
        {
            _cam = Camera.main;
        }

        public void SetName(string nick, bool isLocal)
        {
            nameText.text  = nick;
            nameText.color = isLocal ? Color.green : Color.white;
        }

        public void OnLateUpdate()
        {
            throw new System.NotImplementedException();
        }
    }
}
