using System;
using System.Collections.Generic;
using System.IO;

namespace WasteWiseFunctions.business;

public class UserAccount
{
    public int userID;
    public int count_pickups = 0;
    public List<Container> containers;
    public int runningExpenses;
    public int baseCharge;
    public List<ExtraService> extras;



    public class ExtraService
    {
        string type;
        public int price;
    }

    public void pickup_waste()
    {
        count_pickups++;
    }

    public int getTotal()
    {
        return baseCharge + runningExpenses;
    }

    public int invoice()
    {
        int sum = getTotal();
        runningExpenses = 0;
        count_pickups = 0;
        return sum;
    }


    public UserAccount GetUserForSensor(string id)
    {
        this.userID = 3; //should be fetched from the database based on sensor ID
        return this;

    }

}