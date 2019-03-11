using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewComponentConfig : MonoBehaviour {
    public int Id;

    public float InitPosX;
    public float InitPosY;
    public float InitPosZ;


    public string Label;

    public ViewComponentConfig(GameObject component = null) {
        if (component) {
            
                 
        }
    }

    public void Awake() {
    }

    public void Start() {
    }
}
