using System;
using System.IO;

namespace WasteWiseFunctions.business;

public class Paper : Pickup{

    public int price;
    
    Paper(int price){
        this.price = price;
    }
}