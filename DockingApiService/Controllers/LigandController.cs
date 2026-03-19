using ChemicalFunctions;
using CommonTools;
using DockingApiService.DataModels;
using DockingDataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DockingApiService.Controllers;

[Route("ligand")]
[ApiController]
[ResponseCache(Duration = 600)]
public class LigandController : ControllerBase
{
    private readonly ComputationContext _ctx;
    private readonly IConfiguration _config;

    public LigandController(ComputationContext ctx, IConfiguration config)
    {
        _ctx = ctx;
        _config = config;
    }

    /// <summary>
    /// Puts a ligand in the database with its SMILES.
    /// </summary>
    /// <remarks>
    /// The SMILES and its internal ID are a reversable one-to-one mapping. Sample request:
    /// 
    ///     PUT api/ligand
    ///     {
    ///       "Smiles": "O=C(C)Oc1ccccc1C(=O)O"
    ///     }
    /// 
    /// </remarks>
    /// <param name="model">Parameters as defined in CreateLigandModel. See sample request for more.</param>
    /// <returns>No return value.</returns>
    /// <response code="204">Sucessful operation.</response>
    [ProducesResponseType(204)]
    [HttpPut]
    public async Task<ActionResult> Put([FromBody] CreateLigandModel model)
    {
        long lid = model.Smiles.ComputeHashInt64();
        Ligand ligand = await _ctx.Ligands
            .Where(o => o.Id == lid)
            .SingleOrDefaultAsync();

        if (ligand == null)
        {
            await _ctx.Ligands.AddAsync(ligand = new Ligand
            {
                Id = lid,
                Smiles = model.Smiles
            });
            await _ctx.SaveChangesAsync();
        }

        return NoContent();
    }

    /// <summary>
    /// Gets the 2D or 3D depicting SVG for the ligand specified by <paramref name="ligandId"/>.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/ligand/depiction/4b24a5712e7b3623/2d
    /// 
    /// </remarks>
    /// <param name="ligandId">The identifier of the query ligand.</param>
    /// <param name="type">The type of depiction to be fetched. Could be "2d" or "3d".</param>
    /// <returns>An file object containing the depicting SVG.</returns>
    /// <response code="200">Sucessful operation.</response>
    /// <response code="400">If the depiction type is not recognized.</response>
    /// <response code="404">If the ligand does not exist.</response>
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [HttpGet("depiction/{ligandId:length(16)}/{type:required}")]
    public async Task<ActionResult<FileObject>> GetDepiction(string ligandId, string type)
    {
        if (type != "2d" && type != "3d")
            return BadRequest();

        long lid = ligandId.ParseId();
        Ligand ligand = await _ctx.Ligands
            .Where(o => o.Id == lid)
            .SingleOrDefaultAsync();

        if (ligand == null)
            return NotFound();

        string svg = ligand.DepictionSvgs[type];

        if (string.IsNullOrWhiteSpace(svg))
        {
            OpenBabelOptions options = _config.GetSection("OpenBabel").Get<OpenBabelOptions>();

            svg = ligand.Smiles.SmilesToSvg(type == "3d", options);
            if (svg != null)
            {
                ligand.DepictionSvgs[type] = svg;
                await _ctx.SaveChangesAsync();
            }
        }

        if (svg == null)
            return NotFound();

        return new FileObject
        {
            Content = svg,
            MimeType = "image/svg+xml",
            FileName = $"ligand_depiction{type}_{ligandId}.svg"
        };
    }

    /// <summary>
    /// Gets the molecular fingerprint in the given type for the ligand specified by <paramref name="ligandId"/>.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/ligand/fingerprint/4b24a5712e7b3623/FP2
    /// 
    /// </remarks>
    /// <param name="ligandId">The identifier of the query ligand.</param>
    /// <param name="type">The molceular fingerprint type to be fetched. Could be "MACCS", "FP2", "FP3", "FP4", "ECFP0", "ECFP2", "ECFP4", "ECFP6", "ECFP8" or "ECFP10".</param>
    /// <returns>The binary byte array containing the fingerprint.</returns>
    /// <response code="200">Sucessful operation.</response>
    /// <response code="400">If the fingerprint type is not recognized.</response>
    /// <response code="404">If the ligand does not exist.</response>
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [HttpGet("fingerprint/{ligandId:length(16)}/{type:required}")]
    public async Task<ActionResult<IEnumerable<byte>>> GetFingerprint(string ligandId, string type)
    {
        if (!type.TryParseFingerprint(out Fingerprint fptype))
            return BadRequest();

        long lid = ligandId.ParseId();
        Ligand ligand = await _ctx.Ligands
            .SingleOrDefaultAsync(o => o.Id == lid);

        if (ligand == null)
            return NotFound();

        byte[] fp = ligand.Fingerprints[fptype];
        if (fp == null)
        {
            fp = ligand.Smiles.ComputeFingerprint(type);
            if (fp == null)
                return NotFound();
            ligand.Fingerprints[fptype] = fp;
            await _ctx.SaveChangesAsync();
        }

        return fp;
    }

    /// <summary>
    /// Gets the depicting model in the given <paramref name="type"/> for the ligand specified by <paramref name="ligandId"/>.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/ligand/model/4b24a5712e7b3623/sdf
    /// 
    /// </remarks>
    /// <param name="ligandId">The identifier of the query ligand.</param>
    /// <param name="type">The depicting model type to be fetched. Could be "smi", "pdb", "pdbqt", "mol2" or "sdf".</param>
    /// <returns>An file object containing the depicting model.</returns>
    /// <response code="200">Sucessful operation.</response>
    /// <response code="400">If the model type is not recognized.</response>
    /// <response code="404">If the ligand does not exist.</response>
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [HttpGet("model/{ligandId:length(16)}/{type:required}")]
    public async Task<ActionResult<FileObject>> GetModel(string ligandId, string type)
    {
        if (!OpenBabelHelper.ModelFormats.ContainsKey(type))
            return BadRequest();

        long lid = ligandId.ParseId();
        Ligand ligand = await _ctx.Ligands
            .AsNoTracking()
            .SingleOrDefaultAsync(o => o.Id == lid);

        if (ligand == null)
            return NotFound();

        string model;
        if (type == "pdbqt" && _config.GetValue<bool>("ExternalPrograms:UseVegaForPdbqt"))
            model = ligand.Smiles.SmilesToPdbqtVega();
        else
            model = ligand.Smiles.SmilesToModel(type);

        if (model == null)
            return NotFound();

        return new FileObject
        {
            Content = model,
            MimeType = type.ParseChemicalFormat().GetMimeType().MimeType,
            FileName = $"ligand_model_{ligandId}.{type}"
        };
    }

    /// <summary>
    /// Gets the predicted BBB score in the given <paramref name="algo"/> and <paramref name="fp"/> type for the ligand specified by <paramref name="ligandId"/>.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/ligand/bbb/4b24a5712e7b3623/SVM/MACCS
    /// 
    /// </remarks>
    /// <param name="ligandId">The identifier of the query ligand.</param>
    /// <param name="algo">The algorithm used in prediction. Could be "AdaBoost" or "SVM".</param>
    /// <param name="fp">The molecular fingerprint type used in prediction. Could be "MACCS", "PubChem", "Molprint2D" or "FP2".</param>
    /// <returns>The predicted BBB score using the specified algorithm and fingerprint type.</returns>
    /// <response code="200">Sucessful operation.</response>
    /// <response code="400">If the algorithm or fingerprint type is not recognized.</response>
    /// <response code="404">If the ligand does not exist.</response>
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [HttpGet("bbb/{ligandId:length(16)}/{algo:required}/{fp:required}")]
    public async Task<ActionResult<float?>> GetBbb(string ligandId, string algo, string fp)
    {
        if (!algo.TryParseBbbAlgorithm(out BbbAlgorithm bbbalgo) || !fp.TryParseBbbFingerprint(out BbbFingerprint bbbfp))
            return BadRequest();

        long lid = ligandId.ParseId();
        Ligand ligand = await _ctx.Ligands
            .Where(o => o.Id == lid)
            .SingleOrDefaultAsync();

        if (ligand == null)
            return NotFound();

        float? bs = ligand.BbbScores[bbbalgo, bbbfp];

        if (bs != null)
            return bs;

        using HttpClient hc = new()
        {
            Timeout = TimeSpan.FromMilliseconds(_config.GetValue<int>("ExternalPrograms:BBBTimeout"))
        };

        string url = string.Format(_config["ExternalPrograms:BBBUrl"], WebUtility.UrlEncode(ligand.Smiles), algo, fp);
        string data = await hc.GetStringAsync(url);
        MatchCollection ms = Regex.Matches(data, @"<table[\s\S]+?<\/table>");

        string res = string.Empty;

        foreach (Match m in ms)
        {
            if (m.Value.Contains("Score"))
            {
                MatchCollection ms2 = Regex.Matches(m.Value, @"<p>([\s\S]+?)</p>");
                foreach (Match m2 in ms2)
                {
                    if (m2.Groups[1].Value.Contains("Score"))
                    {
                        Match m3 = Regex.Match(m2.Groups[1].Value, @"score\s*\:\s*(-?\d+(?:\.\d+))$", RegexOptions.IgnoreCase);
                        res += m3.Groups[1].Value;
                    }
                }
                break;
            }
        }

        if (!string.IsNullOrEmpty(res) && float.TryParse(res, out float result))
        {
            ligand.BbbScores[bbbalgo, bbbfp] = result;
            await _ctx.SaveChangesAsync();
            return result;
        }

        return (float?)null;
    }
}
