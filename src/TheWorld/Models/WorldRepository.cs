﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWorld.Models
{
    public class WorldRepository : IWorldRepository
    {
        private WorldContext _context;

        public WorldRepository(WorldContext context)
        {
            _context = context;
        }

        public void AddStop(string tripName, Stop newStop)
        {
            var trip = GetTripByName(tripName);
            if (trip != null)
            {
                trip.Stops.Add(newStop);
                _context.Stops.Add(newStop);
            }
        }

        public void AddTrip(Trip trip)
        {
            _context.Add(trip);
        }

        public IEnumerable<Trip> GetAllTrips()
        {
            return _context.Trips.ToList();
        }

        public Trip GetTripByName(string tripName)
        {
            return _context.Trips.Include(t => t.Stops).Where(t => t.Name == tripName).FirstOrDefault();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
