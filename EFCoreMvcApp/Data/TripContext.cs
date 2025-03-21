using Microsoft.EntityFrameworkCore;
using TripsApp.Models;
namespace TripsApp.Data
{
public class TripContext : DbContext
{
public TripContext(DbContextOptions<TripContext> options) :
base(options)
{
}
public DbSet<Trip> Trips { get; set; } // DbSet for the Tripentity, representing the Trips table
}
}