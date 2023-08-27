﻿
namespace Ex03.GarageLogic
{
    public class Owner
    {
        public string name { get; private set; }
        public string phoneNumber { get; private set; }

        public Owner(string name, string phoneNumber)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
        }
    }
}
