using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DemoDataRequest.Models
{
    public class Test
    {
        private int TestID { get; set; }
        private String Prop1 { get; set; }
        private String Prop2 { get; set; }
        private String Prop3 { get; set; }
        private String Prop4 { get; set; }
    }

    public class TestContext : DbContext
    {
        private DbSet<Test> Tests { get; set; }
    }
}