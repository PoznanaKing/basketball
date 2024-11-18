using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BASSKETBALL.Models;

public partial class Matchdatum
{
    public Guid Id { get; set; } 

    public DateTime Be { get; set; }

    public DateTime Ki { get; set; }

    public int Try { get; set; }

    public int Goal { get; set; }

    public int Fault { get; set; }

    public DateTime Createdtime { get; set; }

    public DateTime Updatedtime { get; set; }

    public Guid PlayerId { get; set; }
    

    public virtual Player Player { get; set; } = null!;
}
