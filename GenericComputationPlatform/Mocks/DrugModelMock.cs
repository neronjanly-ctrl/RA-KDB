using DockingApiClient;
using DockingDataModels;
using System.Collections.Generic;

namespace GenericComputationPlatform.Mocks;

public class DrugModelMock
{
    private readonly ProteinClient _proteinClient;

    public DrugModelMock(ProteinClient proteinClient)
    {
        _proteinClient = proteinClient;
    }

    public async IAsyncEnumerable<string[]> GetDataRaw(string domainId, int size)
    {
        yield return new[] { "Protein", "Target", "Value", "Drug", "DrugId", "Short Name", "Gene Symbol", "Known" };

        const int p = 10007;

        IReadOnlyList<Protein> proteins = await _proteinClient.ListByDomainAsync(domainId, null);

        for (int i = 0; i < size; i++)
        {
            Protein protein = proteins[i * p % proteins.Count];
            yield return new[] { "", "", $"{0.7 + (100 + i * p) % 70 / 10.0}", "TESTLIGAND", "0000000000000000", protein.ProteinSymbol, protein.OrganismSymbol, $"{i * p % 7 % 2}" };
        }
    }
}
