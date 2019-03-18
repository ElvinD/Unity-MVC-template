using Ordina;
using UnityEngine;

[System.Serializable]
public class ViewComponentConfig : MonoBehaviour {
    public int Id;

    public float InitPosX;
    public float InitPosY;
    public float InitPosZ;

    public UIActions actions;
    public string Label;
}
