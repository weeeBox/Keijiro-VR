using System;

public struct color
{
    public static implicit operator color(int value)
    {
        return new color(); // FIXME    
    }

    public static implicit operator int(color color)
    {
        return 0;
    }
}

