using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System;
//using System;

public class TextController : MonoBehaviour {

    public Text text;
    enum States {cell, mirror, sheets_0, lock_0, sheets_1, lock_1, lock_2, cell_mirror, corridor_0, stairs_0, floor, closet_door, corridor_1, stairs_1, in_closet, corridor_2, stairs_2, corridor_3, courtyard, end};
    private States myState;


	// Use this for initialization
	void Start () {
        myState = States.cell;
	}   

    // Update is called once per frame
    void Update(){
        print(myState); // all of these states need an else ("invalid selection - do it again")

        if (myState == States.cell) { state_cell(); } // needs more keypress options
        else if (myState == States.sheets_0) { state_sheets_0(); }
        else if (myState == States.lock_0) { state_lock_0(); } // needs a try and fail scenario
        else if (myState == States.mirror) { state_mirror(); }
        else if (myState == States.sheets_1) { state_sheets_1(); }
        else if (myState == States.lock_1) { state_lock_1(); }
        else if (myState == States.lock_2) { state_lock_2(); }
        else if (myState == States.cell_mirror) { state_cell_mirror(); }
        else if (myState == States.corridor_0) { state_corridor_0(); } // formally freedom
        else if (myState == States.end) { state_end(); }
        
        //corridor scene ===================================================\\

        else if (myState == States.stairs_0)        {state_stairs_0();}
        else if (myState == States.floor)           {state_floor();}
        else if (myState == States.closet_door)     {state_closet_door();}
        else if (myState == States.corridor_1)      {state_corridor_1();} // corridor with hairclip
        else if (myState == States.stairs_1)        {state_stairs_1();}
        else if (myState == States.in_closet)       {state_in_closet();} //get in the closet with hairclip?
        else if (myState == States.corridor_2)      {state_corridor_2();}
        else if (myState == States.stairs_2)        {state_stairs_2();}
        //else if (myState == States.corridor_3)      {state_corridor_3();}
        //else if (myState == States.courtyard)       {state_courtyard();}

    }

    private void state_stairs_2()
    {
        text.text = "The walk up the stairs feels like taking a satisying poo - it just gets better the further it goes. ";
    }

    private void state_corridor_2()
    {
        text.text = "You have the hairclip. And now you've got this ugly ass suit. Everything is coming together - just have to make it to my ship. \n" +
                    "There doesn't look to be anything of use left to inspect. " +
                    "Press S to go up the stairs, Press C to inspect the closet";

        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.stairs_2;
        }
    }

    void state_in_closet()
    {
        text.text = "You approach the closet and use the hairclip to pick the lock - it was nothing like skyrim. The bastards. /n" +
                    "You see a guard uniform that happens to be the perfect size. You put it on, you can probably fool the guards around your ship. \n\n" +
                    "Press R to return to the corridor";

        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.corridor_2;
        }
    }

    void state_stairs_1()
    {

        text.text = "You can probably get the hair clip in the number pad and cause a short - based on your knowledge of bad 80's science fiction films, this should work and open the door. \n " +
                    "But that still leaves guards guarding your ship - that would be suicide. You need to find another way through. \n\n" +
                    "Press R to return to the corridor and try something else.";

        if (Input.GetKeyDown(KeyCode.R))
        {
             myState = States.corridor_1;
        }
          

    }

    void Wrong_Input()
    {
        text.text = "thats not right - You were given simple instructions, don't try and reinvent the wheel you fucking idiot. \n " +
                    "Press C to continue";

        if (Input.GetKeyDown(KeyCode.C))             {myState = States.stairs_1;}
    }

    void state_corridor_1(){ //Corridor with the hairclip

        text.text = "You have the hairclip. This could be it. Your testicles tingle at the thought of being free once again. \n" +
                    "There the stairs to your right, and the closet labelled 'STAFF UNIFORMS'\n\n" +
                    "Press S to go up the stairs, Press C to inspect the closet";

        if      (Input.GetKeyDown(KeyCode.S))       { myState = States.stairs_1; }
        else if (Input.GetKeyDown(KeyCode.C))       { myState = States.in_closet; }
        
     }

     void state_closet_door(){

        text.text = "You walk to the closet down the hall, give it a little shimmy, it doesn't budge. " +
                    "You need something to pick the simple lock. \n\n"+
                    "Press R to return to the corridor.";

        if(Input.GetKeyDown(KeyCode.R))
        {
            myState = States.corridor_0;
            print("Log = R Key Pressed"); //logs keypress to console
        }

     }

    void state_stairs_0() { // stairs doesn't work - needs hairclip

        text.text = "The stairs go up to a locked door, you can see the hanger with your ship in it; the electronic panel requires a finger print to gain entry. \n\n" +
                    "You try your own, but obviously it doesn't work - who'd be that stupid? You. . . That's who. \n\n" +
                    "Press R to return to the corridor.";

        if (Input.GetKeyDown(KeyCode.R))
        {
            print("Log = R Key pressed"); //logs keypress to console 

            myState = States.corridor_0;
        }
    }

    void state_floor()
    {
        text.text = "That glint on the floor is actually a hairclip. You pick it up. Maybe you can use this to jack the number pad? \n\n"+
                    "Press R to return to the corridor"; // this returns to the new corridor_1 state (which hairclip)

        if (Input.GetKeyDown(KeyCode.R))
        {
            print("Log = R Key pressed"); //logs keypress to console 

            myState = States.corridor_1;
        }
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

        // Random success could be like (random bool?) -- if (try = 5) {gain access}
        // OR could have have a random chance or success - like 20% chance of success - but after 5 attempts gain access no matter what?

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

    void state_corridor_0(){ // out of the cell into corridor 3 options

        text.text = "You hear a satisfying beep and a hollow thud as the locking mechanism is disengaged. " +
                    "Hot damn you're good at this, just not good enough to stop getting put in a cell in the first place. \n\n" +
                    "You're faced with a corridor, you see some stairs off to the left and a glint of something on the floor in the dingy light of the corridor. \n" +
                    "There is also a closet at the end of the room marked 'STAFF UNIFORMS' \n\n" +
                    "Press S to go up the stairs, Press F to looks at the floor or press C to look at the closet.";

        if (Input.GetKeyDown(KeyCode.S)) { myState = States.stairs_0; }
        else if (Input.GetKeyDown(KeyCode.F)) { myState = States.floor; }
        else if (Input.GetKeyDown(KeyCode.C)) { myState = States.closet_door; }
        
    }

    void state_end(){
        text.text = "Credits: Ya boi Joe. \n\n" +
                    "I don't know how to close the program so have fun with that";
    }
}