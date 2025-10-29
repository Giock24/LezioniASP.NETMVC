using DemoMVC.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVC.Core.Interfaces;

public interface IMenu
{
    MenuViewModel GetMenuViewModel();
}
