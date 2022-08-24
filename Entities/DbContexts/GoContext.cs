using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public partial class GoContext : DbContext
{
    public GoContext()
    {
    }
    public GoContext(DbContextOptions<GoContext> options)
        : base(options)
    {
    }
    public virtual DbSet<MasterUsers>? masterUsers { get; set; }
    public virtual DbSet<Devices>? devices { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
    }
}