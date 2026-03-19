using CommonTools;
using DockingApiClient;
using DockingDataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericComputationPlatform.Controllers;

[Route("ligand")]
[ResponseCache(Duration = 600)]
public partial class LigandController : Controller
{
    private readonly AppSettings _appSettings;
    private readonly ResultClient _resultClient;
    private readonly LigandClient _ligandClient;

    public LigandController(
        ResultClient resultClient,
        LigandClient ligandClient,
        IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
        _resultClient = resultClient;
        _ligandClient = ligandClient;
    }

    [HttpGet("depiction/{ligandId:length(16)}/{type:required}")]
    public virtual async Task<IActionResult> Depiction(string ligandId, string type)
    {
        FileObject result = await _ligandClient.GetDepictionAsync(ligandId, type);
        if (result == null)
            return NotFound();
        return File(Encoding.UTF8.GetBytes(result.Content), result.MimeType, result.FileName);
    }

    [HttpGet("model/{ligandId:length(16)}/{format:required}")]
    public virtual async Task<IActionResult> Model(string ligandId, string format)
    {
        FileObject result = await _ligandClient.GetModelAsync(ligandId, format);
        if (result == null)
            return NotFound();
        return File(Encoding.UTF8.GetBytes(result.Content), result.MimeType, result.FileName);
    }

    [HttpGet("docked/{ligandId:length(16)}/{proteinId:required}/{modelId:int}")]
    [Obsolete]
    public virtual async Task<IActionResult> Docked(string ligandId, string proteinId, int modelId)
    {
        FileObject result = await _resultClient.GetConformationLegacyAsync(ligandId, proteinId, modelId);
        if (result == null)
            return NotFound();
        return File(Encoding.UTF8.GetBytes(result.Content), result.MimeType, result.FileName);
    }

    [HttpGet("docked/{ligandId:length(16)}/{proteinId:required}/{dockingId:length(16)}")]
    public virtual async Task<IActionResult> Docked(string ligandId, string proteinId, string dockingId)
    {
        FileObject result = await _resultClient.GetComplexedConformationAsync(ligandId, proteinId, dockingId);
        if (result == null)
            return NotFound();
        return File(Encoding.UTF8.GetBytes(result.Content), result.MimeType, result.FileName);
    }

    [HttpGet("bbbscore/{ligandId:length(16)}/{algo:required}/{fp:required}")]
    public virtual async Task<IActionResult> BbbScore(string ligandId, string algo, string fp)
    {
        float? result = await _ligandClient.GetBbbAsync(ligandId, algo, fp);
        if (result == null)
            return NotFound();
        return Content(result.Value.ToString("0.00"));
    }

    [HttpGet("fingerprint/{ligandId:length(16)}/{type:required}")]
    public virtual async Task<IActionResult> Fingerprint(string ligandId, Fingerprint type)
    {
        IReadOnlyList<byte> result = await _ligandClient.GetFingerprintAsync(ligandId, type.ToString());
        if (result == null)
            return NotFound();

        int blockBytes = _appSettings.Formatting.FingerprintBlockBytes;
        int rowBlocks = _appSettings.Formatting.FingerprintRowBlocks;
        return Content(result.ToArray().ToHexString(blockBytes, rowBlocks));
    }

}
