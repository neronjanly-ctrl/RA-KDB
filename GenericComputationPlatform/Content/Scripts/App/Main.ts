/// <reference path="../../../node_modules/@microsoft/signalr/dist/esm/index.d.ts" />

function setCreateMessage(msg: string, error: boolean) {
    if (!error) {
        $("#formMessage").html(msg).removeClass("text-danger").addClass("text-info");
    }
    else {
        $("#formMessage").html(msg).removeClass("text-info").addClass("text-danger");
    }
}

// ReSharper disable once InconsistentNaming
declare let NGL: any;

function setupProteinInfoModal() {
    $("#proteinInfo").on("show.bs.modal",
        function (event) {
            const a = $(event.relatedTarget as any);
            const pname = a.data("pname");

            const modal = $(this);
            const href = a.attr("href");
            if (href === undefined)
                return;

            modal.find(".maximizeBtn").attr("href", href);
            modal.find(".modal-title").text(pname);
            modal.find(".modal-body").text("Loading...");

            modal.find(".modal-body").load(href,
                () => {
                    modal.find(".modal-title").html($("#proteinHeader").html());

                    setTimeout(() => {
                        const stage = new NGL.Stage("viewport", { backgroundColor: "white" });
                        const url = $("link[rel=model]").attr("href");

                        stage.loadFile(url).then(function (o: any) {
                            o.addRepresentation("cartoon", {
                                colorScheme: "residueindex",
                                colorScale: "spectral",
                                colorReverse: true,
                                quality: "high"
                            });
                            o.autoView();
                        });
                    }, 500);
                });
        });
}

function setupFingerprintInfoModal() {
    $("#fingerprintInfo").on("show.bs.modal",
        function (event) {
            const a = $(event.relatedTarget as any);
            const fptype = a.data("fptype");

            const modal = $(this);
            const href = a.attr("href");
            if (href === undefined)
                return;

            modal.find(".maximizeBtn").attr("href", href);
            modal.find(".modal-title").text(fptype);

            if (a.data("fp"))
                modal.find(".modal-body").text(a.data("fp"));
            else {
                modal.find(".modal-body").text("Loading...");
                modal.find(".modal-body").load(href, o => a.data("fp", o));
            }
        });
}

function setupCompareLigandsModal() {
    $("#compareLigands").on("show.bs.modal",
        function (event) {
            //console.log(`compareLigands.show.bs.modal`);

            const a = $(event.relatedTarget as any);
            const pname = a.data("pname");

            const modal = $(this);
            const href = a.attr("href");
            if (href === undefined)
                return;

            modal.find(".maximizeBtn").attr("href", href);
            modal.find(".modal-title").text(pname);
            modal.find(".modal-body").text("Loading...");

            modal.find(".modal-body").load(href, () => {
                modal.find(".modal-title").html($("#ligandHeader").html());
                let fp0 = modal.find(".fp").eq(0), fp1 = modal.find(".fp").eq(1);
                let t0 = fp0.text(), t1 = fp1.text();
                let nt0 = "", nt1 = "";
                if (t0.length === t1.length) {
                    let inb = false;

                    for (let i = 0; i < t0.length; i++) {
                        if (t0[i] == t1[i]) {
                            if (inb) {
                                nt0 += "</b>";
                                nt1 += "</b>";
                                inb = false;
                            }
                        }
                        else {
                            if (!inb) {
                                nt0 += "<b>";
                                nt1 += "<b>";
                                inb = true;
                            }
                        }
                        nt0 += t0[i];
                        nt1 += t1[i];
                    }

                    if (inb) {
                        nt0 += "</b>";
                        nt1 += "</b>";
                    }

                    fp0.html(nt0);
                    fp1.html(nt1);
                }
            });
        });
}

// create job page UI logic
function toggleMolRow(input: HTMLElement) {
    $(".mol-row").hide();
    $(input).parents(".mol-name-row").next().show();
}

function addRemoveBtn(input: JQuery<HTMLElement>) {
    input.css("width", "calc(100% - 110px)")
        .after($("<button class=\"btn btn-danger float-right\" style=\"width:100px\">Remove</button>"))
        .next()
        .click(ev => {
            removeMol($(ev.target));
        });
}

function removeRemoveBtn(input: JQuery<HTMLElement>) {
    input.css("width", "")
        .next()
        .remove();
}

declare let JSApplet: any;
let maxLigands: number = 3;
let apps: JsmeApplet[] = [];

function removeMol(button: JQuery<HTMLElement>) {
    let count = $(".mol-row").length;

    let molNameLabel = "Molecule Name";
    let molLabel = "Molecule";
    let molNameId = "ligandName";
    let molId = "mol";

    let row1 = button.parents(".mol-name-row");
    let row2 = row1.next();
    let prevCount = row1.prevAll(".mol-name-row").length;

    let visible = row2.is(":visible");

    apps.splice(prevCount, 1);

    row1.nextAll(".mol-name-row").each((_i, el) => {
        let row1 = $(el);
        let row2 = row1.next();
        row1.find("strong").text(`${molNameLabel} ${prevCount + 1}`);
        row1.find("label").attr("for", `${molNameId}${prevCount}`);
        row1.find("input").attr("id", `${molNameId}${prevCount}`).attr("name", `${molNameId}${prevCount}`)
        row1.find(".alert").attr("id", `${molNameId}${prevCount}ErrMsg`);
        row2.find("strong").text(`${molLabel} ${prevCount + 1}`);
        row2.find("label").attr("for", `${molId}${prevCount}`);
        row2.find(".mol-editor").attr("id", `${molId}${prevCount}`);
        row2.find(".alert").attr("id", `${molId}${prevCount}ErrMsg`);
        prevCount++;
    });

    row1.remove();
    row2.remove();

    // deleted the last but one molecule
    if (count === 2) {
        $(".mol-name-row strong").text(molNameLabel);
        $(".mol-row strong").text(molLabel);
        removeRemoveBtn($(".mol-name-row input"));
    }

    // deleted the visible molecule, show another
    if (visible) {
        $(".mol-row").eq(Math.min(count - 2, prevCount)).show();
    }

    $("button#addmol").show();
    setCreateMessage("", false);
}

function addMol() {
    let count = $(".mol-row").length;

    if (count >= maxLigands) {
        setCreateMessage(`You can add up to ${maxLigands} molecules.`, true);
        return;
    }

    let molNameLabel = "Molecule Name";
    let molLabel = "Molecule";
    let molNameId = `ligandName${count}`;
    let molId = `mol${count}`;

    if (count === 1) {
        $(".mol-name-row strong").text(`${molNameLabel} 1`);
        $(".mol-row strong").text(`${molLabel} 1`);
    }

    if (count > 0) {
        molNameLabel = `${molNameLabel} ${count + 1}`;
        molLabel = `${molLabel} ${count + 1}`;
    }

    let row1 = $(`
<div class="form-group row mol-name-row">
    <label class="col-sm-2 col-form-label" for="${molNameId}">
        <span class="bg-info mr-2">&nbsp;</span>
        <strong>${molNameLabel}</strong>
    </label>
    <div class="col-sm-10">
        <input type="text" class="form-control d-inline-block" id="${molNameId}" name="${molNameId}" placeholder="e.g. Aspirin"/>
        <div class="alert alert-danger fade collapse mt-2" role="alert" id="${molNameId}ErrMsg"/>
        <small class="form-text text-muted">Provide the name of the molecule to be computed.</small>
    </div>
</div>
`);

    let row2 = $(`
<div class="form-group row mol-row">
    <label class="col-sm-2" for="${molId}">
        <span class="bg-info mr-2">&nbsp;</span>
        <strong>${molLabel}</strong>
    </label>
    <div class="col-sm-10">
        <div id="${molId}" class="mol-editor" width="100%" height="380px"/>
        <div class="alert alert-danger fade collapse mt-2" role="alert" id="${molId}ErrMsg"/>
        <small class="form-text text-muted">Draw a molecule or paste MOL, SDF or SMILES via clicking on the blue double-triangle button on the right of the toolbar.</small>
    </div>
</div>
`);

    // insert rows
    if (count === 0) {
        $(".job-name-row").after(row2).after(row1);
    }
    else {
        $(".mol-row:visible").hide();
        $(".mol-row:last").after(row2).after(row1);

        // add Remove button
        if (count === 1) {
            addRemoveBtn($(".mol-name-row:first input"));
        }
        addRemoveBtn($(".mol-name-row:last input"));
    }
    count++;

    apps.push(new JSApplet.JSME(molId, "100%", "380px", {
        "options": "nozoom,noshowdraganddropsymbolindepictmode",
        "jme": "",
    }));

    // add event handler for toggling display
    $(".mol-name-row:last input").focus(ev => toggleMolRow(ev.target));

    if (count === maxLigands)
        $("button#addmol").hide();
}

function hookJobCreateButtons() {
    let submitting = false;

    $("button#create").click(ev => {
        ev.preventDefault();
        if (submitting)
            return;
        submitting = true;

        const url = $(ev.target).prev("a").attr("href") as string;
        const jobName = $("input[name='jobName']").val();
        const isPrivate = $("input[name='isPrivate']").prop("checked");

        let done: boolean = true;
        if (jobName === "") {
            $("#jobNameRequired").addClass("show").show();
            done = false;
        } else {
            $("#jobNameRequired").hide().removeClass("show");
        }

        let ligandCount = $(".mol-row").length;

        let formData: { [key: string]: any } = {
            "JobName": jobName,
            "IsPrivate": isPrivate === true
        };

        let firstBad = -1;
        let nameSet = new Set<string>();
        let smilesSet = new Set<string>();

        for (let i = 0; i < ligandCount; i++) {
            let ligandName = $(`input[name='ligandName${i}']`).val();
            const smiles = apps[i].smiles();

            let nameLabel = ligandCount > 1 ? `Molecule Name ${i + 1}` : "Molecule Name";
            if (typeof (ligandName) !== "string" || (ligandName = ligandName.trim()) === "") {
                $(`#ligandName${i}ErrMsg`).html(`<strong>${nameLabel}</strong> is required.`).addClass("show").show();
                done = false;
                if (firstBad === -1)
                    firstBad = i;
            } else if (nameSet.has(ligandName)) {
                $(`#ligandName${i}ErrMsg`).html(`<strong>${nameLabel}</strong> is duplicate.`).addClass("show").show();
                done = false;
                if (firstBad === -1)
                    firstBad = i;
            } else {
                nameSet.add(ligandName);
                $(`#ligandName${i}ErrMsg`).hide().removeClass("show");
            }

            let molLabel = ligandCount > 1 ? `Molecule ${i + 1}` : "Molecule";
            if (smiles === "") {
                $(`#mol${i}ErrMsg`).html(`<strong>${molLabel}</strong> is required.`).addClass("show").show();
                done = false;
                if (firstBad === -1)
                    firstBad = i;
            } else if (smilesSet.has(smiles)) {
                $(`#mol${i}ErrMsg`).html(`<strong>${molLabel}</strong> is duplicate.`).addClass("show").show();
                done = false;
                if (firstBad === -1)
                    firstBad = i;
            } else {
                smilesSet.add(smiles);
                $(`#mol${i}ErrMsg`).hide().removeClass("show");
            }

            if (done) {
                formData[`Ligands[${i}].name`] = ligandName;
                formData[`Ligands[${i}].smiles`] = smiles;
            }
        }

        if (firstBad !== -1 && !$(".mol-row").eq(firstBad).is(":visible")) {
            $(".mol-row:visible").hide();
            $(".mol-row").eq(firstBad).show();
        }

        if (!done) {
            submitting = false;
            return;
        }

        setCreateMessage(`Creating new job "${jobName}"...`, false);

        formData["MZ-CSRF"] = $("input[name='MZ-CSRF']").val(),

            $.post($("form").prop("action"),
                formData,
                data => {
                    //console.log(data);
                    if (data) {
                        setCreateMessage("Created successfully.", false);
                        window.location.href = url.replace(/0$/, data);
                    } else {
                        setCreateMessage(`Failed to create new job.`, true);
                    }
                    submitting = false;
                }).fail(data => {
                    setCreateMessage(`Failed: ${data.statusText}`, true);
                    submitting = false;
                });
    });

    $(".mol-name-row input").focus(ev => toggleMolRow(ev.target));

    $("button#addmol").click(ev => {
        ev.preventDefault();

        if (submitting)
            return;
        addMol();
    });
}

function jsmeOnLoad() {
    addMol();
}

function setMaxLigands(value: number) {
    maxLigands = value;
}

function loadPreContents() {
    $("table pre").each(function () {
        const pre = $(this as any);
        const href = pre.prev("link").attr("href");
        if (!href) return;

        $.get(href,
            data => {
                pre.html(data);
            });
    });
}

function updateBbbBar(b: JQuery<HTMLElement>, score: number) {
    b.text(score.toFixed(2));
    const g = b.parent().nextAll("svg").children(".scoreBar");
    const scale = g.data("scale") as number, offset = g.data("offset") as number;
    const line = g.children("line");
    const text = g.children("text");
    const x = offset + scale * score, dx = parseFloat(text.attr("x") as string);
    line.attr("x1", x).attr("x2", x);
    text.text(`Score ${score.toFixed(2)}`).attr("x", x + dx);
    g.removeClass("d-none");
}

function loadBbbScores() {
    $(".bbbscore").each(function () {
        let score = parseFloat($(this).text());
        if (score) {
            updateBbbBar($(this), score as number);
        }
    });

    $("link[rel=bbbscore]").each(function () {
        const link = $(this as any);
        const href = link.attr("href");
        if (!href) return;

        $.get(href,
            data => {
                updateBbbBar(link.prev("b"), parseFloat(data));
            });
    });
}

interface ChemblCompound {
    id: string;
    smiles: string;
    activity: string;
    fingerprint: Blob;
    similarity: number;
};

interface Prediction {
    activity: string;
    confidenceLevel: number;
};

function setupJobHubConnection() {
    const hubUrl = $("a#jobhub").attr("href");
    if (hubUrl === undefined)
        return;

    const connection = new signalR
        .HubConnectionBuilder()
        .withUrl(hubUrl)
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("SetProgress",
        (progress: number | string,
            timeRemaining: string,
            utms: number) => {
            //console.log([new Date().toUTCString(), "SetProgress", progress, timeRemaining, utms]);
            JobProgressHelper.setProgress(progress, timeRemaining, utms);
        });

    connection.on("SetResult",
        (cavityId: string,
            ligandId: string,
            fullProteinSymbol: string,
            dockingScores: (number | null)[],
            dockingIds: (string | null)[],
            mostSimilarActiveCompound: ChemblCompound | null,
            mostSimilarCompound: ChemblCompound | null,
            prediction: Prediction | null) => {
            cavityId = cavityId.substring(0, 8);
            ligandId = ligandId.substring(0, 8);
            //console.log([new Date().toUTCString(), "SetResult", cavityId, ligandId, fullProteinSymbol, dockingScores, dockingIds, mostSimilarActiveCompound, mostSimilarCompound, prediction]);
            JobResultHelper.setResult(cavityId, ligandId, dockingScores, dockingIds, mostSimilarActiveCompound, prediction);
        });

    connection.on("SetStatus",
        (status: string,
            utms: number) => {
            //console.log([new Date().toUTCString(), "SetStatus", status, utms]);
            JobStatusHelper.setStatus(status, utms);
            if (status === "Finished" || status === "Failed")
                connection.stop();
        });

    connection.start().catch((reason: any) => {
        return console.error(reason.toString());
    });
}

function setupViewport(model: InputData) {
    const jvp = $("canvas.viewport");
    const jtb = $("aside.toolbox");

    let imgUrls: { [key: string]: string } = {};
    $("a.depiction").each(function () {
        let href = $(this).attr("href");
        if (href !== undefined) {
            let lig = $(this).attr("id");
            if (!lig?.startsWith("lig-"))
                console.error(`a.depiction[href=${href}] has no lig- id`);
            else {
                lig = lig.substring("lig-".length);
                imgUrls[lig] = href;
            }
        }
        else
            console.error("no href found for a.depiction");
    });

    if (jvp.length !== 0 && jtb.length !== 0) {
        if (Object.keys(imgUrls).length !== model.drugs.length)
            console.error(`the number of depictions(${Object.keys(imgUrls).length}) must equal to that of drugs(${model.drugs.length})`);

        const vp = new ViewportControl(jvp, model, imgUrls);
        const tb = new ToolboxControl(jtb);

        vp.select(style => {
            tb.setStyle(style);
            tb.show();
        }).cancel(() => {
            tb.hide();
        }).multiselect(() => {
            tb.hide();
        });

        tb.change(style => {
            vp.setSelectionStyle(style);
            vp.invalidate();
        });
    }
}

$("#cookieConsent button[data-cookie-string]").click(el => {
    if (el.target.dataset.cookieString !== undefined)
        document.cookie = el.target.dataset.cookieString;
});

$(".openee").click(el => {
    let tag = $(el.target).data("tag");
    let email = window.atob(tag);
    window.open(`mailto:${email}`);
    return false;
});

function utmsToString(utms: number): string {
    return new Date(utms).toLocaleString();
}

$(".update-utms").each((i, el) => {
    const utms = $(el).data("utms");
    if (utms !== undefined)
        $(el).text(utmsToString(utms));
});

$(".use-gene-symbol").click(el => {
    document.cookie = "UseGeneSymbolForTargetDisplay=true; path=/";
    document.location.reload();
    return false;
});

$(".use-protein-symbol").click(el => {
    document.cookie = "UseGeneSymbolForTargetDisplay=false; path=/";
    document.location.reload();
    return false;
});
