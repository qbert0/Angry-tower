using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameManager))]

public class GameManagerEditor : Editor
{
    bool spawn = false;
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        GameManager gameManager = (GameManager)target;

        gameManager.CanSpawn(GUILayout.Toggle(spawn, "spawn"));

        // if(GUILayout.Button("Spanw")) {
        //     Debug.Log("spawn");
        //     gameManager.CanSpawn();
        // }

    }
}
