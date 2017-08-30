namespace VRTK
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class setControllerInpu : MonoBehaviour {



        public GameObject leftController;

        [SerializeField]
        private VRTK_Pointer pointer;

        void Start()
        {
            pointer.controller = gameObject.transform.parent.transform.parent.GetComponent<VRTK_ControllerEvents>();

        }
    }
}