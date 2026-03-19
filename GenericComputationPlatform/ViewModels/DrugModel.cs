// ReSharper disable InconsistentNaming

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GenericComputationPlatform.ViewModels;

public class DrugModel
{
    public string[][] drugs;
    public string[][] targets;
    public int[] targetStates;
    public short[][] targetDrugs;
    public short[][] drugTargets;
    public int[][] interactions;

    public static DrugModel FromRows(IEnumerable<string[]> data, int colValue, int colDrug, int colLigandId, int colTarget, int colOrganism, int colKnown)
    {
        Dictionary<string, short> targets = new();
        Dictionary<string, short> ligands = new();
        List<string[]> drugs = new();
        List<Interaction> interactions = new();

        foreach (string[] item in data)
        {
            string drugId = item[colDrug];
            string ligandId = item[colLigandId];

            if (!ligands.ContainsKey(ligandId))
            {
                ligands[ligandId] = (short)ligands.Count;
                // different ids may have same drug name
                drugs.Add(new[] { drugId, ligandId });
            }
            else
            {
                // same id must has same drug name
                Debug.Assert(drugs.Any(o => o[0] == drugId && o[1] == ligandId));
            }

            string targetId = string.IsNullOrEmpty(item[colTarget]) ? null : $"{item[colTarget]}|{item[colOrganism]}";
            if (!string.IsNullOrEmpty(targetId) && !targets.ContainsKey(targetId))
                targets[targetId] = (short)targets.Count;

            interactions.Add(new Interaction
            {
                DrugId = ligands[ligandId],
                TargetId = string.IsNullOrEmpty(targetId) ? null : targets[targetId],
                Value = string.IsNullOrEmpty(item[colValue]) ? null : (short)(double.Parse(item[colValue]) * 1000),
                Known = !string.IsNullOrEmpty(item[colKnown]) && int.Parse(item[colKnown]) != 0,
            });
        }

        DrugModel model = new()
        {
            drugs = drugs.ToArray(),
            targets = targets
                .OrderBy(o => o.Value)
                .Select(o => o.Key.Split('|'))
                .ToArray(),
            targetStates = interactions
                .Where(o => o.TargetId != null)
                .GroupBy(o => o.TargetId, o => o.Known)
                .OrderBy(o => o.Key)
                .Select(o => o.Any(p => p) ? 1 : 0)
                .ToArray(),
            targetDrugs = interactions
                .Where(o => o.TargetId != null)
                .GroupBy(o => o.TargetId, o => o.DrugId)
                .OrderBy(o => o.Key)
                // distinct: eliminates multiple edges on two same connecting nodes
                .Select(o => o.Distinct().ToArray())
                .ToArray(),
            drugTargets = interactions
                .GroupBy(o => o.DrugId, o => o.TargetId)
                .OrderBy(o => o.Key)
                // distinct: eliminates multiedges on two same connecting nodes
                .Select(o => o.Where(p => p != null).Select(p => p.Value).Distinct().ToArray())
                .ToArray(),
            interactions = interactions
                .Where(o => o.TargetId != null && o.Value != null)
                // groupby: select the worst value for multiedge
                .GroupBy(o => (o.DrugId, TargetId: (short)o.TargetId))
                .Select(o => new[] { o.Key.DrugId, o.Key.TargetId, o.Max(p => p.Value.Value), o.Any(p => p.Known) ? 1 : 0 })
                .ToArray(),
        };

        return model;
    }
}