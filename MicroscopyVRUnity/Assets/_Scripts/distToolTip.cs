namespace VRTK {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class distToolTip : MonoBehaviour {

        //[SerializeField]
        public GameObject p1;

        //[SerializeField]
        public GameObject p2;

        [SerializeField]
        private Vector3[] positions;

        [SerializeField]
        private Vector3 tool_tip_ofset;

        private LineRenderer lr;
        private VRTK_ObjectTooltip tool_tip;

        private GameObject MessurementsHolder;

        [SerializeField]
        private Color[] colors = new Color[10];


        // Use this for initialization
        void Start() {
            positions = new Vector3[2];
            lr = GetComponent<LineRenderer>();
            tool_tip = GetComponent<VRTK_ObjectTooltip>();
            MessurementsHolder = gameObject.transform.parent.gameObject;


            int rand = Random.Range(0, colors.Length - 1);
            tool_tip.containerColor = colors[rand];
            tool_tip.lineColor = colors[rand];
            lr.startColor = colors[rand];
            lr.endColor = colors[rand];
           
        }

        // Update is called once per frame
        void FixedUpdate() {
            if(p1 == null || p2 == null){
                Destroy(gameObject);
            }

            UpdatePositions(p1, 0);
            UpdatePositions(p2, 1);
            lr.SetPositions(positions);

            string text = "Distance: " + CalcDist();
            tool_tip.UpdateText(text);

            tool_tip.drawLineFrom = p1.transform;
            tool_tip.drawLineTo = p2.transform;
            tool_tip.transform.position = p1.transform.position + tool_tip_ofset;
            
        }

        void UpdatePositions(GameObject go,int index) {
            if(go != null){
                positions[index] = go.transform.localPosition;
            }
        }

        float CalcDist() {
            float result = Vector3.Distance(positions[0], positions[1]);
            return result;
        }
    }
}