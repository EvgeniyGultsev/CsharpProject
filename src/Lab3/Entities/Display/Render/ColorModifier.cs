﻿using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display.Render;

public class ColorModifier : IModifier
{
    private readonly Color _color;

    public ColorModifier(Color color)
    {
        _color = color;
    }

    public string Modify(string value)
    {
        return Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(value);
    }
}