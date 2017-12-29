using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System;

public class TextController : MonoBehaviour {

    public Text text;
    enum States {cell, mirror, sheets_0, lock_0, sheets_1, lock_1, lock_2, cell_mirror, corridor_0, end};
    private States myState;


	// Use this for initialization
	void Start () {
        myState = States.cell;
	}   

    // Update is called once per frame
    void Update(){
        print(myState); // all of these states need an else ("invalid selection - do it again")

        if (myState == States.cell)                 {state_cell();} // needs more keypress options
        else if (myState == States.sheets_0)        {state_sheets_0();}
        else if (myState == States.lock_0)          {state_lock_0();} // needs a try and fail scenario
        else if (myState == States.mirror)          {state_mirror();}
        else if (myState == States.sheets_1)        {state_sheets_1();}
        else if (myState == States.lock_1)          {state_lock_1();}
        else if (myState == States.lock_2)          {state_lock_2();}
        else if (myState == States.cell_mirror)     {state_cell_mirror();}
        else if (myState == States.corridor_0)      {state_corridor_0();}
        else if (myState == States.end)             {state_end();}    
    }

    void state_cell () { //Describing the cell
        text.text = "You are a prisoner on a maximum security space station. You stink of booze and regret. The Regret tastes like tequila. " +
                    "You see a bed with dirty sheets, a mirror on the wall and the door with a lock number pad. " +
                    "You want to escape. The Gin aint gonna drink itself back on the ship \n\n" +
                    "Press S to view sheets, M to view mirror, L to view lock - it looks like a shitty lock";

        if (Input.GetKeyDown(KeyCode.S))
        {
            print("Log = S Key pressed"); //logs keypress to console 

            myState = States.sheets_0;
       }
        else if (Input.GetKeyDown(KeyCode.L)) { myState = States.lock_0; }
        else if (Input.GetKeyDown(KeyCode.M)) { myState = States.mirror; }
    }

    void state_sheets_0() { // looking at the sheets 
        text.text = "The sheets are filthy, and not because you slept in them! " +
                    "You long for the bouncy comfort of your roundish water bed. \n\n" +
                    "Press R to turn around and look at your cell";

        if (Input.GetKeyDown(KeyCode.R))
        {
            print("Log = R key pressed"); //logs keypress to console 

            myState = States.cell;
        }

    }

    void state_sheets_1(){ //looking at the sheets with mirror does nothing

        text.text = "The mirror does nothing useful with the filthy sheets. If only it was a picture of Spiderman these sheets would get a lot more filthy. . .\n\n" +
                    "Press R to return to looking at your cell (or yourself, you look damn good)";
        if(Input.GetKeyDown(KeyCode.R)){
            
            myState = States.cell_mirror;

            print("Log = R key pressed"); //logs keypress to console 
        }

    }

    void state_lock_0() { //looking at the lock without anything in your hand

        text.text = "There is a panel on the opposite side of the cell door. You can't see it from inside the cell so you " +
                    "lightly feel the pad. Its a number 9 digit number pad with a big button. . . You Imagine its Red \n\n" +
                    ". . . You like big red buttons\n\n" +

                    "If only you could use something to look at the number pad from inside the cell \n\n" +
                    "Press R to to keep looking around your cell";

        if (Input.GetKeyDown(KeyCode.R))
        {
            print("Log = R key pressed"); //logs keypress to console 

            myState = States.cell;
        }

    }

    void state_lock_1(){ //lock with mirror - perhaps make random success? 

        text.text = "You put the mirror through the bars of the cell and turn it to see the reflection of the numberpad. " +
                    "You can see the dirt on some of the numbers \n\n" +
                    "You press the numbers in no particular order. . . \n\n" +
                    "Press C to continue. ";
        
        if (Input.GetKeyDown(KeyCode.C)){
            myState = States.lock_2;
        }
        
    }

    void state_lock_2(){
        
        text.text = "It worked! - Almost like it was all planned this way. . . " +
                    "Press F for your Freedom."; 
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            myState = States.corridor_0;

            print("Log = F key pressed"); //logs keypress to console 
        }
    }

    void state_mirror(){ //Get the mirror off the wall
        text.text = "The mirror seems loose - I can probaly take it off the wall with my rippling muscles. \n\n" +
                    "Press T to take the mirror - try not to look at yourself too much. \n\n" +
                    "Or press R to return to your cell";

        if (Input.GetKeyDown(KeyCode.T))
        {
            myState = States.cell_mirror;

            print("Log = T key pressed"); //logs keypress to console
        }
            else if(Input.GetKeyDown(KeyCode.R))    {myState = States.cell;};
    }

    void state_cell_mirror(){ //inside the cell with the mirror

        text.text = "You have the mirror in your hands, you want to get out more than ever - " +
            "you see you're hair has been messed up (good job not looking at yourself) \n\n" +
             "Press S to view sheets, press L to view the Lock";

        if(Input.GetKeyDown(KeyCode.S))             {myState = States.sheets_1;} 
        else if(Input.GetKeyDown(KeyCode.L))        {myState = States.lock_1;}
    }

    void state_corridor_0(){
        text.text = "You hear a satisfying beep and a hollow thud as the locking mechanism is disengaged. " +
                    "Hot damn you're good at this, just not good enough to stop getting put in a cell in the first place. \n\n" +
                    "Now just to get past the hundreds of gaurds between you and your janky ass ship. . . And look damn good doing it. \n" +
                    "Press Enter to quit, Press P to play again";   

        if(Input.GetKeyDown(KeyCode.P))             {myState = States.cell;}
        else if(Input.GetKeyDown(KeyCode.Return))   {myState = States.end;}
    }

    void state_end(){
        text.text = "Credits: Ya boi Joe. \n\n" +
                    "I don't know how to close the program so have fun with that";
    }
}