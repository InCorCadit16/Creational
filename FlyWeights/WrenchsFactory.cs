using GarageSimulation.Models;
using GarageSimulation.Models.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GarageSimulation.FlyWeights
{
    class WrenchsFactory
    {
        private static readonly Dictionary<string, IWrench> wrenchs = new Dictionary<string, IWrench>();

        public static IWrench GetWrench(string type)
        {
            bool found = wrenchs.TryGetValue(type, out IWrench wrench);

            if (!found)
            {
                switch (type)
                {
                    case "openEnd": wrenchs.Add(type, new OpenEndWrench()); break;
                    case "pipe": wrenchs.Add(type, new PipeWrench()); break;
                    case "circle": wrenchs.Add(type, new CircleWrench()); break;
                }

                wrenchs.TryGetValue(type, out wrench);
            }

            return wrench;
        }
    }
}
