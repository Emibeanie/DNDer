using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AffectionTrigger
{
    public enum Trigger { perfect, perfect_att, perfect_def, miss, miss_hit, miss_def, attack_for_less, attack_for_more, get_hit }
    public Trigger trigger;
    public bool negative = false;
    public int rndWeight = 0;

    public AffectionTrigger(Trigger trigger,bool negative = false,int rndWeight = 0)
    {
        this.trigger = trigger;
        this.negative = negative;
        this.rndWeight = rndWeight;
    }
    public int Check(Trigger trigger)
    {
        if (trigger == this.trigger)
        {
            if(new System.Random().Next(0,rndWeight) == 0)
            {
                if (!negative) return 1;
                else return -1;
            }
        }
        return 0;
    }
}
