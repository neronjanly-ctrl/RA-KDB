using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CytoscapeOnline.Models
{
    public class DrugModel
    {
        public string[] Drugs;
        public string[] Targets;
        public int[] TargetStates;
        public short[][] TargetDrugs;
        public short[][] DrugTargets;
        public int[][] Interactions;
    }
}