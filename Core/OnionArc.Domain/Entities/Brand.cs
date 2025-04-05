using OnionArc.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArc.Domain.Entities;

public class Brand : EntityBase
{
    public Brand()
    {

    }
    public Brand(string name, string logo)
    {
        Name = name;
        Logo = logo;
    }
    public string Name { get; set; }
    public string Logo { get; set; }
}
