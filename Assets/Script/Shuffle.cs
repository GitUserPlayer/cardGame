using System.Collections;
using System.Collections.Generic;
using System;
public static class Shuffle 
{
    public static void myShuffle(int [] arrayInt) 
    {
        int swapNum;
        int randomNum;

        Random random = new Random();

        for (int i =0;i<arrayInt.Length ;i++) 
        {
            randomNum = random.Next(arrayInt.Length);
            swapNum = arrayInt[i];
            arrayInt[i] = arrayInt[randomNum];
            arrayInt[randomNum] = swapNum;
        }

    }
}
