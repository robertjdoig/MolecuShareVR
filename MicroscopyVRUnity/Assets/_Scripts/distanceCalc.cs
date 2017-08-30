namespace VRTK.Examples { 

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class distanceCalc : MonoBehaviour {

        [SerializeField]
        private GameObject tooltip;
        GameObject tooltipInstance;
        VRTK_ObjectTooltip ObjectToolTip;

        [SerializeField]
        private Vector3 tooltipOfset;

        GameObject wpHolder;

        [SerializeField]
        private GameObject linePrefab;
        GameObject linePrefabInstance;

        public Color c1 = Color.cyan;
        public Color c2 = Color.red;
        public int lengthOfLineRenderer = 100;
        private LineRenderer lineRend;

        [SerializeField]
        private GameObject wpPrefab;

        [SerializeField]
        private VRTK_ControllerEvents controller_events;

        //GameObject[] points;
        public float pressure = 0; 
        public float distance = 0;

        [SerializeField]
        private float actuationPoint;

        [SerializeField]
        private bool isActived = false;

        List<GameObject> points = new List<GameObject>();

        public float overallDistance; 
        //GameObject sphere; 

        // Use this for initialization
        void Start()
        {

            wpHolder = new GameObject();
            wpHolder.name = "WP Holder";

            linePrefabInstance = Instantiate(linePrefab);
            linePrefabInstance.transform.parent = wpHolder.transform;

            tooltipInstance = Instantiate(tooltip);
            ObjectToolTip = tooltipInstance.GetComponent<VRTK_ObjectTooltip>();
            tooltipInstance.transform.parent = wpHolder.transform;
            tooltipInstance.GetComponent<VRTK_ObjectTooltip>().alwaysFaceHeadset = true;

            lineRend = linePrefabInstance.GetComponent<LineRenderer>();
            lineRend.material = new Material(Shader.Find("Particles/Additive"));
            lineRend.startColor = c1;
            lineRend.endColor = c2;
            lineRend.numPositions = lengthOfLineRenderer;

            for(int i = 0; i < lengthOfLineRenderer; i++){
                lineRend.SetPosition(i, Vector3.zero);
            }

        }

        // Update is called once per frame
        void Update()
        {

            pressure = controller_events.GetTriggerAxis();

            //Creates a Sphere when the trigger is pressed
            if (pressure <= 0.1f && pressure >= 0.05f )
            {
                points.Add(createSphere(transform.position)as GameObject);
                isActived = false;
            }

            distance = 0;
            overallDistance = 0;

            if(points.Count > 2)
            {
                //ObjectToolTip.drawLineFrom = points[0].transform;
                //ObjectToolTip.drawLineTo.position = points[0].transform.position + tooltipOfset;
                tooltipInstance.transform.position = points[0].transform.position + tooltipOfset;
        
                var linePoints = new Vector3[lengthOfLineRenderer];
                for(int i = 0; i < points.Count - 1; i++)
                {
                    distance = Vector3.Distance(points[i].transform.position, points[i + 1].transform.position);
                    overallDistance += Mathf.Abs(distance);
                    Debug.DrawLine(points[i].transform.position, points[i + 1].transform.position);
                }
                
                if(points.Count < lengthOfLineRenderer){
                    for(int i = 0; i < points.Count; i++)
                    {
                        linePoints[i] = points[i].transform.position;
                    }
                }
                lineRend.SetPositions(linePoints);
            }

            string text = "Overall Distance: " + overallDistance;
            ObjectToolTip.UpdateText(text);



        }

        GameObject createSphere(Vector3 position)
        {
            GameObject sphere = Instantiate(wpPrefab);
            //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = position;
            sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            sphere.transform.parent = wpHolder.transform;
            return sphere;
        }

       
    }
}