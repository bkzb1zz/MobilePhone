namespace MobilePhone
{
    using System;

    class StartUp
    {
        static void Main()
        {
            GSMTest();

            GSMCallHistoryTest();
        }

        private static void GSMCallHistoryTest()
        {
            GSM testGsm = new GSM("Nokia", "TelerikCorp");

            testGsm.AddCall("0888888881", 20);
            testGsm.AddCall("0888888882", 60);
            testGsm.AddCall("0888888883", 10);
            testGsm.AddCall("0888888884", 30);
            testGsm.AddCall("+359888888885", 250);

            testGsm.ShowCallHistory();

            Console.WriteLine("Total call price: " + testGsm.TotalCallPrice());

            testGsm.DeleteCall(5);
            Console.WriteLine("Removed Longest call!");

            Console.WriteLine("Total call price: " + testGsm.TotalCallPrice());

            testGsm.ClearCallHistory();
            Console.WriteLine("Cleared call history!");
            testGsm.ShowCallHistory();
        }

        private static void GSMTest()
        {
            GSM test1 = new GSM("Nokia", "Connecting People", 140000
                , "HappyOwner", new Battery("BestBatteryEVER", 1000, 10000, Battery.Type.AlienTech), new Display(4.5m, 16000000));

            GSM test2 = new GSM("Kia", "Thailand");

            GSM test3 = new GSM("Somebrand", "SomeManufacturer", 100, "Az", new Battery(), new Display());

            GSM[] testAll = new GSM[] { test1, test2, test3 };

            foreach (var gsm in testAll)
            {
                Console.WriteLine(gsm);
            }

            Console.WriteLine(GSM.IPhone4S);
        }
    }
}