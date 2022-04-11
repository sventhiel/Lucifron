﻿using Fare;
using Lucifron.ReST.Library.Extensions;
using Lucifron.ReST.Server.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lucifron.ReST.Server.Tests.Helpers
{
    [TestFixture]
    public class DOIHelperTests
    {
        public static Dictionary<string, string> MyProperty { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            MyProperty = new Dictionary<string, string>
        {
            { "{DadtasetId}", "1337" }
        };
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        { }

        [TestCase("idiv\\.{DatasetId}-[a-zA-Z0-9]{6}")]
        public void Pattern(string pattern, Dictionary<string, string> placeholders = null)
        {
            try
            {
                var doi = DOIHelper.Create(pattern, MyProperty);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}