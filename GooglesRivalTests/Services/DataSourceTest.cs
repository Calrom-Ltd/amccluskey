// <copyright file="DataSourceTest.cs" company="Adam's Awesome API">
// Copyright (c) Adam's Awesome API. All rights reserved.
// </copyright>

namespace GooglesRivalTests.Services
{
    using System;
    using GooglesRival.Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// SQL Data Source tests.
    /// </summary>
    [TestClass]
    public class DataSourceTest
    {
        /// <summary>
        /// Gets all users test.
        /// </summary>
        [TestMethod]
        public void ThrowExceptionWhenConnectionStringIsInvalid()
        {
            try
            {
                //// Setup
                Environment.SetEnvironmentVariable("ConnectionString", "Nonsense");

                //// Act
                IDataSource sut = new SqlDataSource();

                ////Assert
                Assert.Fail("No Exception Thown");
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex.Message, "Exception Message should not be null");
            }
        }
    }
}
