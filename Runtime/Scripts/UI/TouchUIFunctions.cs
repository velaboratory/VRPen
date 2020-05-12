﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace VRPen {


    //this is supplemental ui functions specifically for use with the touch use-case (phone/tablet)
    public class TouchUIFunctions : MonoBehaviour {

        public GameObject displayObj;
        public CanvasScaler canvasScale;
        public TouchInput touchInput;
        public UIManager uiMan;

        public GameObject moveIcon;
        public GameObject drawIcons;

        //waiting for canvas text
        public VRPen.Display display;
        public Text waitingForCanvas;
        bool canvasExists = false;

        void Start() {
            if (!VectorDrawing.actSynchronously) uiMan.removeAddCanvasButtons();
        }

       

        private void Update() {

            //waiting for canvas text
            if (!canvasExists) {
                canvasExists = display.currentLocalCanvas != null;
                if (canvasExists) {
                    waitingForCanvas.gameObject.SetActive(false);
                }
            }
        }

        public void changeCanvasSize(bool increase) {
            float increment = increase ? 0.05f : -0.05f;
            displayObj.transform.localScale += new Vector3(increment, increment, increment);
        }

        public void changeUIScale(bool increase) {
            float increment = increase ? 0.05f : -0.05f;
            canvasScale.scaleFactor += increment;
        }

        public void toggleCanvasMove(bool toggle) {

            //if the move is already on, it should be turned off if the button is clicked
            if (touchInput.canvasMove && toggle) toggle = false;

            touchInput.canvasMove = toggle;
            moveIcon.SetActive(toggle);
            drawIcons.SetActive(!toggle);
        }
    }

}
