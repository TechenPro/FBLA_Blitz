using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPlayState : PlayerState
{
    protected override void OnFire(object sender, InfoEventArgs<int> e){
        // Key Listeners for the different players
        // Button numbers are refrencing the index of the button name in the button list found in the InputController
        if(owner.name == "Player1")
        {
            if (e.info == 0)
            {
                owner.ChooseAnswer(1);
            }
            else if (e.info == 1)
            {
                owner.ChooseAnswer(2);
            }
            else if (e.info == 2)
            {
                owner.ChooseAnswer(3);
            }
            else if (e.info == 3)
            {
                owner.ChooseAnswer(4);
            }
            else if(e.info == 4){
                if(owner.blitzMeter.MeterAmount == 100)
                    owner.EnterBlitz();
            }
        }
        else if (owner.name == "Player2")
        {
            if (e.info == 5)
            {
                owner.ChooseAnswer(1);
            }
            else if (e.info == 6)
            {
                owner.ChooseAnswer(2);
            }
            else if (e.info == 7)
            {
                owner.ChooseAnswer(3);
            }
            else if (e.info == 8)
            {
                owner.ChooseAnswer(4);
            }
            else if (e.info == 9)
            {
                if (owner.blitzMeter.MeterAmount == 100)
                    owner.EnterBlitz();
            }
        }
    }
}
