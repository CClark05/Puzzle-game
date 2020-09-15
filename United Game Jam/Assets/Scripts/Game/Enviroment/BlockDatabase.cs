using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Blocks 
{ 
    Background,
    Barrier,
    Movement,
    Flag,
    Spawn,
    Teleport,
}

public static class BlockDatabase
{
    public static int GetBlockID(Blocks block)
    {
        switch (block) 
        {
            case Blocks.Background:
                return 1;
            case Blocks.Movement:
                return 2;
            case Blocks.Flag:
                return 3;
            case Blocks.Barrier:
                return 4;
            case Blocks.Spawn:
                return 5;
            case Blocks.Teleport:
                return 6;
            default:
                return 99; //Invalid block
        }

    }
    public static Blocks GetBlockName(int id)
    {
        switch (id)
        {
            default:
            case 1:
                return Blocks.Background;
            case 2:
                return Blocks.Movement;
            case 3:
                return Blocks.Flag;
            case 4:
                return Blocks.Barrier;
            case 5:
                return Blocks.Spawn;
            case 6:
                return Blocks.Teleport;
        }
    }
}
