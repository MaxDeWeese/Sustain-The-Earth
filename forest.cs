using UnityEngine;

public class forest : MonoBehaviour{
    public float emmisionCNT;
    public float energyCNT;
    public int energyPrice;
    public GameObject main;

    public bool timer;

    public int destructiontime;
    public Vector3Int pos;

    public bool destroys;

    public bool shiftTime;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        main = GameObject.FindWithTag("main");
    }

    // Update is called once per frame
    void Update()
    {  
        if(destroys){


            if(shiftTime){
                destructiontime-=1;
                Debug.Log("final count");
                if(destructiontime<=0){
                    Debug.Log("red red red");
                    main.GetComponent<place_destroy>().RemoveTile(pos);
                
                }
            }else{
                if(timer){
                    destructiontime-=1;
                    if(destructiontime<=0){
                        colorShift();
                    }
                }else if(Random.Range(0, destructiontime) ==1){
                colorShift();
                
                }
            }

        
        
    }
    main.GetComponent<track_values>().updateVals(emmisionCNT,energyCNT);
    

    
}
public void colorShift(){
        main.GetComponent<place_destroy>().RemoveTile(pos);
        main.GetComponent<place_destroy>().explodeEffect(pos);

        destructiontime = 500;
        shiftTime = true;
}
}
