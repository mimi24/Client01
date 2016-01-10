using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallController : MonoBehaviour {
    public List<Material> wallTypeList = new List<Material>();
    //public List<Texture>
    void Start() {
        for (int i = 0; i < 4; i++) {
            wallTypeList.Add(Resources.Load("Materials/Walls " + (i + 1).ToString()) as Material);
            Debug.Log(wallTypeList[i].name);
        }
    }

    public void ChangeWallTexture() {
        Debug.Log("change wall texture");
        for (int i = 0; i < wallTypeList.Count; i++) {
            wallTypeList[i].SetTexture("_MainTex", Resources.Load("Textures/Crate04") as Texture);
        }
    }
}
