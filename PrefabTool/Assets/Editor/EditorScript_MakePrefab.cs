﻿using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// @Author Marshall Mason
/// Editor script_ make prefab.
/// </summary>
public class EditorScript_MakePrefab : MonoBehaviour {
	[MenuItem("Project Tools/Create Prefab")]
	public static void MakePrefab()
	{
		GameObject[] selectedObjects = Selection.gameObjects;
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(Application.dataPath + @"\Editor\Jump.wav");
        player.Play();
		foreach(GameObject go in selectedObjects)
		{
			string name = go.name;
			string assetPath = "Assets/" + name + ".prefab";
            

			if(AssetDatabase.LoadAssetAtPath (assetPath, typeof(GameObject)))
			{
				//Debug.Log ("Asset existed");
				if(EditorUtility.DisplayDialog ("Prefab already exists", "Prefab already exists. Do you want to overwrite?", "Overwrite", "Cancel"))
				{
					CreateNew (go, assetPath);
				}
			}
			else
			{
				CreateNew (go, assetPath);
			}
			//Debug.Log ("Name: " + go.name + " Path: " + assetPath);

		}
	}


	public static void CreateNew(GameObject obj, string location)
	{
		Object prefab = PrefabUtility.CreateEmptyPrefab (location);
		PrefabUtility.ReplacePrefab (obj, prefab);
		DestroyImmediate (obj);
		GameObject clone = PrefabUtility.InstantiatePrefab (prefab) as GameObject;
	}
}
