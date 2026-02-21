using System;
using System.Collections.Generic;
public class WorldData
{
    public static bool developerMode = true;
    public static int currentDay = 0;
    public static Inventory playerInventory = new Inventory();
    public static bool gamePaused = false;
    public static String lastScene = "Outside";
}