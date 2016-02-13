using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class WallController : MonoBehaviour {
    public List<Material> wallTypeList = new List<Material>();
    //public List<Texture>
    void Start() {
        for (int i = 0; i < 4; i++) {
            wallTypeList.Add(Resources.Load("Materials/Walls " + (i + 1).ToString()) as Material);
            Debug.Log(wallTypeList[i].name);
        }

        ChangeWallTexture();
    }

    public void ChangeWallTexture() {
        Debug.Log("change wall texture");
        string wallPathString = "";
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (sceneIndex > 0 && sceneIndex <= 9)
			wallPathString = "Textures/leaves2";
        else if (sceneIndex > 9 && sceneIndex <= 14)
			wallPathString = "Textures/sand";
        else
            wallPathString = "Textures/Wall01";


        for (int i = 0; i < wallTypeList.Count; i++) {
            wallTypeList[i].SetTexture("_MainTex", Resources.Load(wallPathString) as Texture);
        }
    }
}
