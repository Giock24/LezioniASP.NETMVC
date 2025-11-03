using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVC.Core.Interfaces;

public interface ISpecialData
{
    string GetString();
}

public class MockSpecialData : ISpecialData
{
    public string GetString()
    {
        return "Hello!";
    }
}