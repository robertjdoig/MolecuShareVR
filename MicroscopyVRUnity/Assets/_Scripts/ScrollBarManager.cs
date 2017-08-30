namespace VRTK {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class ScrollBarManager : MonoBehaviour {

        [SerializeField]
        private ModelLoader model_loader;

        [SerializeField]
        private VRTK_ControllerEvents controller_events;

        private GameObject contents;

        [SerializeField]
        private GameObject buttonPrefab;

        [SerializeField]
        private string[] names;

        [SerializeField]
        private string selectedName;

        [SerializeField]
        private float scroll_speed = 0.00000001f;

        public float posY;

        public GameObject buttontest;

        public GameObject[] buttonsGO;


        [Header("Debug")]
        public float testIndex;
        public float testSpeed;

        // Use this for initialization
        void Start(){
            /** Getting the contents bar inside the prefab */
            contents = transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
            testIndex = 0;

            controller_events.TouchpadPressed += new ControllerInteractionEventHandler(DoTouchPadPressed);
        }

        // Update is called once per frame
        void Update() {
            float hNames = names.Length / 2;
            UpdatePosition(controller_events.GetTouchpadAxis().y * hNames - hNames);
        }

        public void createMenu(string[] _names)
        {
            contents = transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
            buttonsGO = new GameObject[_names.Length];
            //names = new string[_names.Length];
            names = _names;

            for (int i = 0; i < names.Length; i++)
            {

                GameObject insta = Instantiate(buttonPrefab);
                insta.transform.SetParent(contents.transform);
                insta.transform.localPosition = Vector3.zero;
                insta.transform.localRotation = Quaternion.identity;
                insta.transform.localScale = new Vector3(1, 1, 1);
                insta.transform.GetChild(0).GetComponent<Text>().text = " " + names[i];

                buttonsGO[i] = insta;
            }
        }

        public void UpdatePosition(float pos)
        {

            testIndex = Mathf.Abs(pos);// * testSpeed; ;
            if (testIndex < 0)
            {
                testIndex = names.Length - 1;
            }
            else if (testIndex > names.Length)
            {
                testIndex = 0;
            }
            selectedName = (int)testIndex + " " + names[(int)testIndex];

            buttontest.transform.GetComponentInChildren<Text>().text = selectedName;
            //buttontest.transform.GetComponentInChildren<Text>().text = pos.ToString();



            RectTransform rectT = contents.GetComponent<RectTransform>();
            //rectT.Translate(new Vector3(0, pos * scroll_speed, 0));
       
            foreach(GameObject buttonGO in buttonsGO)
            {
                Button b = buttonGO.GetComponent<Button>();
                ColorBlock cb = b.colors;

                if (buttonGO.transform.position.y + rectT.transform.position.y <= rectT.transform.position.y + 0.1f && buttonGO.transform.position.y + rectT.transform.position.y >= rectT.transform.position.y - 0.1f)
                {
                    cb.normalColor = Color.blue;
                } else {
                    cb.normalColor = Color.white;
                }

                buttonGO.GetComponent<Button>().colors = cb;
            }

           
        }


        private void DoTouchPadPressed(object sender, ControllerInteractionEventArgs e)
        {
            Vector3 pos = controller_events.transform.position;
            model_loader.spawnModel(names[(int)testIndex], pos); 
        }





        /** Getter */
        public string getSelectName(){ return selectedName; }
    }
}