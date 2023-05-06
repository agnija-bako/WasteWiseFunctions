using System;
using System.IO;

namespace WasteWiseFunctions.business;

public class HouseholdWaste : Pickup{
public int price;
    
    HouseholdWaste(int price){
        this.price = price;
    }
}