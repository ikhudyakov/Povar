using UnityEngine;

namespace Views.GameInput
{
    class PCInputView : BaseInputView
    {
        public override void Init()
        {
            base.Init();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            XAxisInput = Input.GetAxis("Horizontal");
            IsJump = Input.GetAxis("Vertical") > 0;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ShowPauseMenu();
            }

            IsFire = Input.GetKey(KeyCode.Space);
        }
    }
}
