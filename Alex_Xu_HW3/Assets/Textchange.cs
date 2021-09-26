using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Textchange : MonoBehaviour
{
    
    public enum Stages {StageOne, StageTwo, StageThree}
    public Stages myStage = Stages.StageOne;

    [SerializeField]
    private TMP_Text myText;
    public string newText = "This is my text";

    public int counter = 0;
    
    private void Awake(){
        myText = GetComponent<TMP_Text>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        myText.text = newText;   
    }

    void EnumChange(){
        switch(myStage){
            
            case Stages.StageOne:
                myText.text = "Stage One";
                myStage = Stages.StageTwo;
                break;

            case Stages.StageTwo:
                myText.text = "Stage Two";
                myStage = Stages.StageThree;
                break;

             case Stages.StageThree:
                myText.text = "Stage Three";
                myStage = Stages.StageOne;
                break;

        }
        counter += 1;
        myText.text += " " + counter.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.S))
            EnumChange();
       
        if(Input.GetKeyDown(KeyCode.Space)){
           myText.text = "I Pressed Space." ;
        }
    }
}
