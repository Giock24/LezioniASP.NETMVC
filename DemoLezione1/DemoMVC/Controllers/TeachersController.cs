using DemoMVC.Controllers;
using DemoMVC.Core.Entities;
using DemoMVC.Core.Interfaces;

public class TeachersController : BaseCRUDController<Teacher, int>
{
    public TeachersController(IGenericData<Teacher, int> repository) : base(repository)
    {

    }


}