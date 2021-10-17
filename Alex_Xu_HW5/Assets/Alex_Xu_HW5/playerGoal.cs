using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerGoal : MonoBehaviour
{

    public TMP_Text goal;

    public bool collectWood;
    public bool collectFood;
    public bool equipAxe;
    public bool mothSpawn;
    public bool burnCocoon;
    public bool bossStageTwo;

    public static playerGoal Singleton;

    public string[] goals = new string[] { "Another day in the woods...\nwalk around and interact with your surroundings.",
                                           "A good day starts with breakfast.\nCollect 5 pieces of wood to start a fire.",
                                           "A good day starts with breakfast.\nGo grab some food from the tent.",
                                           "Strange sound come from the western woods.\nFor safety, equip the axe before check it out.",
                                           "Moth-like monsters are out in the woods.\nAttack with the axe and find the cause of the chaos.",
                                           "A huge cocoon appears on a tree, and my axe can't cut it?\nCollect 10 pieces of wood to try burn it down.",
                                           "The monster in the cocoon comes out of the cocoon!\nHeat the axe with fire to deal fire damage."};

    private void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        goal = GetComponent<TMP_Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        collectWood = false;
        collectFood = false;
        equipAxe = false;
        mothSpawn = false;
        burnCocoon = false;
        bossStageTwo = false;
        goal.text = goals[0];
        goal.text = goal.text.Replace("\\n", "\n");
    }

    // Update is called once per frame
    void Update()
    {
        if(collectWood == true)
        {
            goal.text = goals[1];
            if (collectFood == true)
            {
                goal.text = goals[2];
                if (equipAxe == true)
                {
                    goal.text = goals[3];
                    if (mothSpawn == true)
                    {
                        goal.text = goals[4];
                        if (burnCocoon == true)
                        {
                            goal.text = goals[5];
                            if (bossStageTwo == true)
                            {
                                goal.text = goals[6];
                            }
                        }
                    }
                }
            }
         }
    }
}
