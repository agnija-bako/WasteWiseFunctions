using System;
using System.IO;

namespace WasteWiseFunctions.business;
public class GlassMetall : Pickup
{
    public int price;

    public GlassMetall(int price)
    {
        this.price = price;
    }
}