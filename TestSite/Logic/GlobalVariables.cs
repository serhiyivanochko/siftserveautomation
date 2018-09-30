﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSite.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestSite.Logic
{
    static class GlobalVariables
    {
        public static ChromeDriver driver;
        public static List<string> inputListCategories = new List<string>()
        {
            "All Categories",
            "Desktops",
            "PC",
            "Mac",
            "Laptops & Notebooks",
            "Acer",
            "Apple",
            "HP",
            "Others",
            "Components",
            "Mice and Trackballs",
            "Monitors",
            "test 1",
            "test 2",
            "Printers",
            "Scanners",
            "Web Cameras",
            "Tablets",
            "Apple",
            "Other",
            "Samsung",
            "Software",
            "Apple",
            "Microsoft",
            "Other",
            "Phones & PDAs",
            "Apple",
            "HTC",
            "Others",
            "Samsung",
            "Cameras",
            "Canon",
            "Nikon",
            "MP3 Players",
            "Apple",
            "Others",
        };
    }
}
