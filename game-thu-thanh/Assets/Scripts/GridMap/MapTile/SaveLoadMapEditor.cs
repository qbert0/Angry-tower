using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SaveLoadMap))]
public class SaveLoadMapEditor : Editor {
    
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        SaveLoadMap saveLoadMap = (SaveLoadMap)target;
        if(GUILayout.Button("Load")) {
            Debug.Log("load map");
            saveLoadMap.Load();
        }


        if(GUILayout.Button("Save")) {
            Debug.Log("save map");
            saveLoadMap.Save();
        }
        
    }
}
