using UnityEngine;
using UnityEngine.Tilemaps;
public class shop : MonoBehaviour
{
    public GameObject main;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void buyTile( AnimatedTile newT){
        
        
        main.GetComponent<place_destroy>().replcementTile = newT;
        
    }

    public void buyobj(GameObject obj){
        
        main.GetComponent<place_destroy>().replaceObject = obj;
        
    }
    public void buyprice( int price){
        if(main.GetComponent<track_values>().energy-price >= 0){
            main.GetComponent<place_destroy>().editmode = 1;
            main.GetComponent<track_values>().energy -=price;
            Debug.Log("bought");
        }
        

    }


    
    public void test(){
        Debug.Log("why");
    }
    public void sell(){
        main.GetComponent<place_destroy>().editmode = 2;
        
    }
}
