using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPTT_API
{
    public class Constants
    {
        public static class Config
        {
            //GC
            public static string[] fireRadioList = { "12.101", "12.102", "12.103", "12.104", "12.105",
                                "12.116", "12.117", "12.118", "12.119", "12.120",
                                "12.121", "12.122", "12.123", "12.127", "12.128",
                                "12.132", "12.133", "12.134", "12.135", "12.140",
                                "12.141", "12.142", "12.146", "12.149", "12.156",
                                "12.157" };

            public static string[] bmsRadioList = { "12.101", "12.102", "12.103", "12.104", "12.105",
                                "12.116", "12.117", "12.132", "12.133", "12.134", "12.135", "12.136",
                                "12.137", "12.138", "12.139","12.156", "12.157"};


            public const string ServerIP = @"10.108.96.44:8888";
            
            //WWSI
            //public static string[] radioList = { "12.70" };
            //public const string ServerIP = @"192.168.1.10:8888";
        }
    }
}
