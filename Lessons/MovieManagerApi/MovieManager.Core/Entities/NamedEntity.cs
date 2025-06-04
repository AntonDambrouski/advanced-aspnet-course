using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManager.Core.Entities;
internal class NamedEntity : Entity
{
    public string Name { get; set; } = string.Empty;
}
