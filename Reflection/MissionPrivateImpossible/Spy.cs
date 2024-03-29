﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{

    public string RevealPrivateMethods(string className)
    {
        Type classType = Type.GetType(className);
        var privateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        var sb = new StringBuilder();

        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (var method in privateMethods)
        {
            sb.AppendLine(method.Name);
        }
        return sb.ToString().Trim();
    }
}

