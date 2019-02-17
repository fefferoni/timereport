using System;
using System.Collections.Generic;
using System.Text;
using TimeReport.Repository;
using Xunit;
using Xunit.Sdk;

namespace TimeReport.IntegrationTests
{
    public class TimeReportDbContextEfCoreFixture
    {
        private TimeReportContext systemUnderTest;

        public TimeReportDbContextEfCoreFixture()
        {
            systemUnderTest = null;
        }

        public TimeReportContext SystemUnderTest
        {

            get
            {
                if (systemUnderTest == null)
                {
                    systemUnderTest = new TimeReportDbContextBuilder().Create();

                    systemUnderTest.Database.EnsureCreated();
                }

                return systemUnderTest;
            }
        }


    }
}
