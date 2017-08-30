namespace VRTK
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class RadialTouchValue : MonoBehaviour {

        [SerializeField]
        private VRTK_ControllerEvents inputController;

        VRTK_ObjectTooltip tooltip;

        float angle;

        // Use this for initialization
        void Start()
        {
            tooltip = GetComponent<VRTK_ObjectTooltip>();
        }

        // Update is called once per frame
        void Update()
        {

            if (inputController.touchpadTouched)
            {
                angle = inputController.GetTouchpadAxisAngle();
                string text = "Angle: " + angle/360*255;
                tooltip.UpdateText(text);

            }
            
        }
    }

}