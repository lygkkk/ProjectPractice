﻿using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using ProjectPractice.MariaDb.Models;

namespace ProjectPractice.MariaDb
{
    class Program
    {
        static void Main(string[] args)
        {
            string c = "张李孙王";
            MariaContext mariaContext = new MariaContext();

            var dd = mariaContext.UserInfos.Where(e => e.Name.Contains()).ToList();

            
        }
    }
}