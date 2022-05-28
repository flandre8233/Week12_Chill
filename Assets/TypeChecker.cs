using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public static class TypeChecker
{
    public static bool IsSameOrSubclass(Type potentialBase, Type potentialDescendant)
    {
        return potentialDescendant.IsSubclassOf(potentialBase)
               || potentialDescendant == potentialBase;
    }
}
