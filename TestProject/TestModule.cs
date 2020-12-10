using System;
namespace DateTimeTest
{
    public class TestModule 
    {
        static TestModule _instance;
        public static TestModule Instance => _instance ?? (_instance = new TestModule());

        protected TestModule()
        {
        }
    }

}
