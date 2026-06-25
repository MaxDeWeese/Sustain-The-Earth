using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using Unity.Collections;
using System;
using UnityEngine.Tilemaps;
using Unity.Mathematics;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;

public class place_destroy : MonoBehaviour
{
    public Camera cam;
    public Tilemap baseMap;
    public int editmode;
    // 0 = none
    // 1 = add
    // 2 = destroy

    public GameObject g = null;

    public GameObject replaceObject;

    public AnimatedTile replcementTile;
    public Tile removeTile;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Dictionary<Vector2Int, GameObject> tileObjects = new Dictionary<Vector2Int, GameObject>();
    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        if( Input.GetMouseButtonDown(0) && editmode != 0){
        // find mouse position in grid

            float x = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,cam.nearClipPlane)).x;
            float y = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,cam.nearClipPlane)).y;
            int xInt = (int) Mathf.Ceil((x - 0.49f)*33.3333f)-1;
            int yInt = (int) Mathf.Ceil((y + 0.49f)*33.3333f)-1;
            Debug.Log(xInt+"_"+yInt);

            if(xInt >= 4 || xInt <= -4){
                return;
            }
            if(xInt == 0 && yInt == -1){
                Debug.Log("that's the city, don't place there");
            }else{
                if(editmode ==1){
                    
                    PlaceTile(new Vector3Int(xInt,yInt,0));
                }else{
                    RemoveTile(new Vector3Int(xInt,yInt,0));
                }
            }
        }
    }
    public void RemoveTile(Vector3Int pos){

        if(tileObjects.ContainsKey(new Vector2Int(pos.x,pos.y))){
            
            baseMap.SetTile(pos,removeTile);
            Destroy(tileObjects[new Vector2Int(pos.x,pos.y)]);
            tileObjects.Remove(new Vector2Int(pos.x,pos.y));
            editmode = 0;
            gameObject.GetComponent<track_values>().energy +=30; 
        }  
    }
    public void PlaceTile(Vector3Int pos){

        if(tileObjects.ContainsKey(new Vector2Int(pos.x,pos.y))){
            return;
        }
        
        baseMap.SetTile(pos,replcementTile);
        g = (GameObject)GameObject.Instantiate(replaceObject, new Vector3(0,0,0), quaternion.identity);
        g.GetComponent<forest>().pos = pos;
        tileObjects.Add(new Vector2Int(pos.x,pos.y), g);
        editmode = 0;
          
    }
    public void explodeEffect(Vector3Int pos){
        Debug.Log("color shift");
        baseMap.SetColor(pos, Color.red);
    }

}
