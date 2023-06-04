using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DestruccionEnemigo
{
    public static int enemiesDestroyed = 0;

    public static void IncrementCounter()
    {
        enemiesDestroyed += 1;
    }
}
