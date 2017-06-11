using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_World_Simulation {
	class World {
		// The world will contain everything.
		public List<Sector> sectors;
		public List<Conflict> conflicts;

		public static void Move(Sector curentSector, Unit unit, Sector sector) {
			// Check if the sectors are connected.
			if (curentSector.connections.Contains(sector) == false) {
				// We cant move there!

				// TODO: Add debug error reporting (When we implement visuals).
				return;
			} 
			sector.units.Add(unit);				// Add it to the new Sector.
			curentSector.units.Remove(unit);	// Remove it from the old sector.
		}

		public World() {
			sectors = new List<Sector>();
			conflicts = new List<Conflict>();
		}

		public void Generate(Sector initSector, int size) {
			Random rand = new Random();
			int x = 1;	// Sectors are named f0, f1, f2, f3... for now. This variable
						// is used to name them. It is also used to count how many sectors
						// were generated.
						// FIXME: Fix this

			List<Sector> frontier = new List<Sector>();	// We use a BFS essentitally to generate the world.
														// we add a sector to the frontier and generate some
														// neighbours for it. Then we add the neighbours to
														// the frontier and give them some neighbours. We
														// stop when the size variable reaches size.
			frontier.Add(initSector);
			Sector current;				// The sector we are currently processing.
			while(true) {
				current = frontier[0];
				int len = rand.Next(1, 9);  // How many connections the sector will have.
				for (int i = 0; i < len; i++) {
					Sector s = new Sector("f" + x, this);   // Make a new neighbour.
					current.connections.Add(s);				// Add the new neighbour to our connections.
					current.connections[current.connections.IndexOf(s)].connections.Add(current);   // Add ourselves to our neighbours connections.
					frontier.Add(current.connections[current.connections.IndexOf(s)]);	// Add the neighbour to the frontier.
					sectors.Add(current.connections[current.connections.IndexOf(s)]);   // Add the neighbour to the sectors list.
					if (x >= size) {	// Check if enough sectors have been created.
						return;
					}
					x += 1;	// Increase x.
				}
				frontier.Remove(current);	// Remove ourselves from the frontier.
			}
		}
	}
}
