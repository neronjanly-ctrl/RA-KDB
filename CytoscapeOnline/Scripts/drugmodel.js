
var DrugStyle = {
    BorderPaint: { h: 0.638, s: 1, l: 0.667 },//"#5473FF",
    BorderWidth: 4.0,
    FillColor: { h: 0.667, s: 0, l: 1 },//"#fff",
    SelectedFillColor: { h: 0.167, s: 1, l: .5 },//"#ff0",
    Size: 100.0,
    LabelColor: { h: 0.667, s: 0, l: 0 },//"#000",
    SelectedLabelColor: { h: 0.667, s: 0, l: 0 },//"#000",
    LabelFontSize: 14,
};

var TargetStyle = {
    BorderPaint: { h: 0.667, s: 0, l: 0 },//"#000",
    BorderWidth: 0,
    FillColor: { h: 0.833, s: 1, l: 0.683 },//"#FF5EFF",
    SelectedFillColor: { h: 0.167, s: 1, l: .5 },//"#ff0",
    Size: 35,
    LabelColor: { h: 0.667, s: 0, l: 0 },//"#000",
    SelectedLabelColor: { h: 0.667, s: 0, l: 0 },//"#000",
    LabelFontSize: 12,
};

var KnownTargetStyle = {
    BorderPaint: { h: 0.667, s: 0, l: 0 },//"#000",
    BorderWidth: 0,
    FillColor: { h: 0.35, s: 1, l: 0.746 },//"#7EFF8A",
    SelectedFillColor: { h: 0.167, s: 1, l: .5 },//"#ff0",
    Size: 35,
    LabelColor: { h: 0.667, s: 0, l: 0 },//"#000",
    SelectedLabelColor: { h: 0.667, s: 0, l: 0 },//"#000",
    LabelFontSize: 12,
};

var InteractionStyle = {
    ShowLabel: true,
};

var Navigation = {
    Scale: 1.0,
    OffsetX: 0,
    OffsetY: 0,

    Pan: function (deltaX, deltaY) {
        this.OffsetX += deltaX / this.Scale;
        this.OffsetY += deltaY / this.Scale;
    },

    Zoom: function (centerX, centerY, delta) {
        var scale = this.Scale;
        this.Scale *= 1 + Math.max(Math.min(delta / 30, 0.6), -0.6);
        this.Scale = Math.max(Math.min(this.Scale, 10), 0.1);
        this.OffsetX += centerX * (1 / this.Scale - 1 / scale);
        this.OffsetY += centerY * (1 / this.Scale - 1 / scale);
    },

    ToPhysical: function (posX, posY) {
        return { x: (posX + this.OffsetX) * this.Scale, y: (posY + this.OffsetY) * this.Scale };
    },

    ToLogical: function (posX, posY) {
        return { x: posX / this.Scale - this.OffsetX, y: posY / this.Scale - this.OffsetY };
    },
};

function Rand(Min, Max) {
    var Range = Max - Min;
    var Rand = Math.random();
    return (Min + Math.round(Rand * Range));
}

function ToRGB(h, s, l) { // h, s, l must be within [0,1]
    var c = (1 - Math.abs(2 * l - 1)) * s;

    var seg = Math.floor(h * 6);
    var x = (1 - Math.abs(h * 6 % 2 - 1)) * c;
    var m = l - c * .5;

    var r, g, b;
    switch (seg) {
        case 0: r = c, g = x, b = 0; break;
        case 1: r = x, g = c, b = 0; break;
        case 2: r = 0, g = c, b = x; break;
        case 3: r = 0, g = x, b = c; break;
        case 4: r = x, g = 0, b = c; break;
        case 5: r = c, g = 0, b = x; break;
        case 6: r = c, g = 0, b = 0; break;
    }

    return { r: Math.floor((r + m) * 255), g: Math.floor((g + m) * 255), b: Math.floor((b + m) * 255) };
}

function ToRGBs(color) {
    var rgb = ToRGB(color.h, color.s, color.l);
    return "rgb(" + rgb.r + "," + rgb.g + "," + rgb.b + ")";
}

CanvasRenderingContext2D.prototype.roundRect = function (x, y, width, height, round) {
    this.beginPath();

    this.moveTo(x + round, y);
    this.arcTo(x + width, y, x + width, y + height, round);
    this.arcTo(x + width, y + height, x, y + height, round);
    this.arcTo(x, y + height, x, y, round);
    this.arcTo(x, y, x + width, y, round);

    this.closePath();

    return this;
};

CanvasRenderingContext2D.prototype.dashedLineTo = function (fromX, fromY, toX, toY, pattern) {
    // default interval distance -> 5px
    if (typeof pattern === "undefined") {
        pattern = 5;
    }

    // calculate the delta x and delta y
    var dx = (toX - fromX);
    var dy = (toY - fromY);
    var distance = Math.floor(Math.sqrt(dx * dx + dy * dy));
    var dashlineInteveral = (pattern <= 0) ? distance : (distance / pattern);
    var deltay = (dy / distance) * pattern;
    var deltax = (dx / distance) * pattern;

    // draw dash line
    this.beginPath();
    for (var dl = 0; dl < dashlineInteveral; dl++) {
        if (dl % 2) {
            this.lineTo(fromX + dl * deltax, fromY + dl * deltay);
        } else {
            this.moveTo(fromX + dl * deltax, fromY + dl * deltay);
        }
    }
    this.stroke();
};

CanvasRenderingContext2D.prototype.drawRound = function (x, y, radius, color, border, borderColor, text, textColor, textSize) {
    this.beginPath();
    border = Math.min(radius - 1, border);
    this.arc(x, y, radius - border, 0, Math.PI * 2);
    this.closePath();

    if (border > 0) {
        this.lineWidth = border * 2;
        this.strokeStyle = ToRGBs(borderColor);
        this.stroke();
    }

    this.fillStyle = ToRGBs(color);
    this.fill();

    this.font = "bold " + textSize + "px Arial";

    var textWidth = this.measureText(text).width;

    this.fillStyle = ToRGBs(textColor);
    this.fillText(text, x - textWidth / 2, y + textSize / 3);

    return this;
};

var DrugModel = {
    Drugs: [],
    Targets: [],
    Interactions: [],
    SelectedIds: [],

    Init: function (model) {
        this.SelectedIds = [];

        var drugCount = model.Drugs.length;

        for (var i = 0; i < drugCount; i++) {
            this.Drugs[i] = {
                Id: i,
                Name: model.Drugs[i],
                Targets: model.DrugTargets[i],
                Selected: false,
            };
        }

        var targetCount = model.Targets.length;

        for (var i = 0; i < targetCount; i++) {
            this.Targets[i] = {
                Id: i,
                Name: model.Targets[i],
                Known: model.TargetStates[i] !== 0,
                Drugs: model.TargetDrugs[i],
                Selected: false,
            };
        }

        var interactionCount = model.Interactions.length;

        for (var i = 0; i < interactionCount; i++) {
            this.Interactions[i] = {
                Drug: model.Interactions[i][0],
                Target: model.Interactions[i][1],
                Value: model.Interactions[i][2] / 1000.0,
                Known: model.Interactions[i][3] !== 0,
                Reverse: false,
            };
        }
    },

    Layout: function (screenWidth, screenHeight) {
        var degree = Math.PI * 2 / this.Drugs.length;
        var radius = Math.min(screenWidth, screenHeight) / 2 - DrugStyle.Size * 1.5 / 2;
        var centerX = screenWidth / 2, centerY = screenHeight / 2;

        var combs = {};

        function Nearest(x, y) {
            var distY = TargetStyle.Size * 2, distX = distY / 2 * Math.sqrt(3);

            x = Math.round((x - centerX) / distX);
            y = Math.round((y - centerY + (x % 2 == 0 ? 0 : distY / 2)) / distY);

            for (var j = 1; ; j++) {
                for (var l = 0; l < j; l++) {
                    y++;
                    if (!combs["" + x + "," + y]) {
                        combs["" + x + "," + y] = true;
                        return { x: centerX + x * distX, y: centerY + y * distY + (x % 2 == 0 ? 0 : distY / 2) };
                    }
                }
                for (var l = 0; l < j; l++) {
                    x--;
                    if (!combs["" + x + "," + y]) {
                        combs["" + x + "," + y] = true;
                        return { x: centerX + x * distX, y: centerY + y * distY + (x % 2 == 0 ? 0 : distY / 2) };
                    }
                }

                j++;
                for (var l = 0; l < j; l++) {
                    y--;
                    if (!combs["" + x + "," + y]) {
                        combs["" + x + "," + y] = true;
                        return { x: centerX + x * distX, y: centerY + y * distY + (x % 2 == 0 ? 0 : distY / 2) };
                    }
                }
                for (var l = 0; l < j; l++) {
                    x++;
                    if (!combs["" + x + "," + y]) {
                        combs["" + x + "," + y] = true;
                        return { x: centerX + x * distX, y: centerY + y * distY + (x % 2 == 0 ? 0 : distY / 2) };
                    }
                }
            }
        }

        for (var i = 0; i < this.Drugs.length; i++) {
            var mainDegree = i * degree;

            this.Drugs[i].X = centerX + Math.sin(mainDegree) * radius;
            this.Drugs[i].Y = centerY - Math.cos(mainDegree) * radius;

            var count = 0;
            var ones = [];

            for (var j = 0; j < this.Drugs[i].Targets.length; j++) {
                var tid = this.Drugs[i].Targets[j];
                if (this.Targets[tid].Drugs.length === 1) { // one-degree targets
                    ones[count++] = tid;
                }
            }

            var degree2 = Math.PI / 6;
            var radius2 = (DrugStyle.Size + TargetStyle.Size) / 2 + TargetStyle.Size * 0.8;
            var centerX2 = this.Drugs[i].X, centerY2 = this.Drugs[i].Y;

            for (var j = 0; j < count; j++) {
                var subDegree = mainDegree - (count - 1) * degree2 / 2 + j * degree2;
                this.Targets[ones[j]].X = centerX2 + Math.sin(subDegree) * radius2;
                this.Targets[ones[j]].Y = centerY2 - Math.cos(subDegree) * radius2;
            }
        }


        for (var i = 0; i < this.Targets.length; i++) {
            var target = this.Targets[i];
            var drugs = target.Drugs;

            if (drugs.length === 1) {
                continue;
            }

            if (drugs.length >= 2) {
                var x = 0, y = 0;
                for (var j = 0; j < drugs.length; j++) {
                    x += this.Drugs[drugs[j]].X;
                    y += this.Drugs[drugs[j]].Y;
                }

                var pos = Nearest(x / drugs.length, y / drugs.length);
                target.X = pos.x;
                target.Y = pos.y;
            }
        }
    },

    EncodeDrugId: function (id) {
        return id;
    },

    EncodeTargetId: function (id) {
        return 32768 + id;
    },

    EncodeInteractionId: function (id) {
        return 100000 + id;
    },

    DecodeDrugId: function (id) {
        return id;
    },

    DecodeTargetId: function (id) {
        return id - 32768;
    },

    DecodeInteractionId: function (id) {
        return id - 100000;
    },

    IsDrugId: function (id) {
        return id < 32768;
    },

    IsTargetId: function (id) {
        return id >= 32768 && id < 100000;
    },

    IsInteractionId: function (id) {
        return id >= 100000;
    },

    HitTest: function (x, y) {
        // if click on a drug node
        for (var i = 0; i < this.Drugs.length; i++) {
            var radius = DrugStyle.Size / 2;
            var dx = x - this.Drugs[i].X, dy = y - this.Drugs[i].Y;

            if (dx * dx + dy * dy <= radius * radius) {
                return this.EncodeDrugId(i);
            }
        }

        // if click on a target node
        for (var i = 0; i < this.Targets.length; i++) {
            var radius;
            if (this.Targets[i].Known) {
                radius = (KnownTargetStyle.Size + this.Targets[i].Drugs.length * 5) / 2;
            } else {
                radius = (TargetStyle.Size + this.Targets[i].Drugs.length * 5) / 2;
            }

            var dx = x - this.Targets[i].X, dy = y - this.Targets[i].Y;

            if (dx * dx + dy * dy <= radius * radius) {
                return this.EncodeTargetId(i);
            }
        }

        // if click on a interaction
        for (var i = 0; i < this.Interactions.length; i++) {
            var ix = this.Interactions[i];
            var x0 = this.Drugs[ix.Drug].X, y0 = this.Drugs[ix.Drug].Y;
            var x1 = this.Targets[ix.Target].X, y1 = this.Targets[ix.Target].Y;
            var l = Math.sqrt((x1 - x0) * (x1 - x0) + (y1 - y0) * (y1 - y0));
            var l0 = Math.sqrt((x - x0) * (x - x0) + (y - y0) * (y - y0));
            var l1 = Math.sqrt((x - x1) * (x - x1) + (y - y1) * (y - y1));

            if (l0 + l1 < l * 1.005) {
                //alert("" + this.Drugs[ix.Drug].Name + "," + this.Targets[ix.Target].Name);
                return this.EncodeInteractionId(i);
            }
        }

        return null;
    },

    GetSelectionStyle: function () {
        if (this.SelectedIds.length !== 1) {
            return null;
        }

        var id = this.SelectedIds[0];
        var style;

        if (this.IsDrugId(id)) {
            style = DrugStyle;
        } else if (this.IsTargetId(id)) {
            if (this.Targets[this.DecodeTargetId(id)].Known) {
                style = KnownTargetStyle;
            } else {
                style = TargetStyle;
            }
        } else {
            return null;
        }

        return {
            color: style.FillColor,
            size: style.Size,
            borderColor: style.BorderPaint,
            borderWidth: style.BorderWidth,
            textColor: style.LabelColor,
            textSize: style.LabelFontSize
        };
    },

    SetSelectionStyle: function (style) {
        if (this.SelectedIds.length !== 1) {
            return false;
        }

        var id = this.SelectedIds[0];
        var tstyle;

        if (this.IsDrugId(id)) {
            tstyle = DrugStyle;
        } else if (this.IsTargetId(id)) {
            if (this.Targets[this.DecodeTargetId(id)].Known) {
                tstyle = KnownTargetStyle;
            } else {
                tstyle = TargetStyle;
            }
        } else {
            return false;
        }

        if (style.color != undefined) {
            tstyle.FillColor = style.color;
        }
        if (style.size != undefined) {
            tstyle.Size = style.size;
        }
        if (style.borderColor != undefined) {
            tstyle.BorderPaint = style.borderColor;
        }
        if (style.borderWidth != undefined) {
            tstyle.BorderWidth = style.borderWidth;
        }
        if (style.textColor != undefined) {
            tstyle.LabelColor = style.textColor;
        }
        if (style.textSize != undefined) {
            tstyle.LabelFontSize = style.textSize;
        }

        return true;
    },

    UnselectAll: function () {
        if (this.SelectedIds.length === 0) {
            return false;
        }

        for (var i = 0; i < this.SelectedIds.length; i++) {
            var id = this.SelectedIds[i];
            if (this.IsDrugId(id)) {
                this.Drugs[this.DecodeDrugId(id)].Selected = false;
            } else if (this.IsTargetId(id)) {
                this.Targets[this.DecodeTargetId(id)].Selected = false;
            }
        }

        this.SelectedIds = [];

        return true;
    },

    Select: function (sel) {
        if (this.IsDrugId(sel)) {
            var id = this.DecodeDrugId(sel);

            // single selection: clicking on the only selected node takes no effect.
            if (this.Drugs[id].Selected
                && this.SelectedIds.length === 1) {
                return false;
            }

            // single selection: clicking on nonselected node unselects the others.
            this.UnselectAll();
            this.SelectedIds = [sel];
            this.Drugs[id].Selected = true;
        } else if (this.IsTargetId(sel)) {
            var id = this.DecodeTargetId(sel);

            // single selection: clicking on the only selected node takes no effect.
            if (this.Targets[id].Selected
                && this.SelectedIds.length === 1) {
                return false;
            }

            // single selection: clicking on nonselected node unselects the others.
            this.UnselectAll();
            this.SelectedIds = [sel];
            this.Targets[id].Selected = true;
        } else {
            return false;
        }

        return true;
    },

    MultiSelect: function (sel) {
        if (this.IsDrugId(sel)) {
            var id = this.DecodeDrugId(sel);

            // multiple selection: clicking on the selected node unselects itself.
            if (this.Drugs[id].Selected) {
                this.Drugs[id].Selected = false;
                for (var i = 0; i < this.SelectedIds.length; i++) {
                    if (this.SelectedIds[i] === id) {
                        this.SelectedIds.splice(i, 1);
                        break;
                    }
                }
            } else {
                // multiple selection： clicking on the nonselected node selects itself.
                this.Drugs[id].Selected = true;
                this.SelectedIds.push(sel);
            }
        } else if (this.IsTargetId(sel)) {
            var id = this.DecodeTargetId(sel);

            // multiple selection: clicking on the selected node unselects itself.
            if (this.Targets[id].Selected) {
                this.Targets[id].Selected = false;
                for (var i = 0; i < this.SelectedIds.length; i++) {
                    if (this.SelectedIds[i] === id) {
                        this.SelectedIds.splice(i, 1);
                        break;
                    }
                }
            } else {
                // multiple selection： clicking on the nonselected node selects itself.
                this.Targets[id].Selected = true;
                this.SelectedIds.push(sel);
            }
        }

        return true;
    },

    Draw: function (canvas) {
        var ctx = canvas.getContext("2d");

        // setup context
        ctx.save();

        ctx.clearRect(0, 0, canvas.width, canvas.height);
        ctx.scale(Navigation.Scale, Navigation.Scale);
        ctx.translate(Navigation.OffsetX, Navigation.OffsetY);

        // draw known interaction solid lines
        ctx.beginPath();
        ctx.lineWidth = 3;
        ctx.strokeStyle = "#00FF47";

        for (var i = 0; i < this.Interactions.length; i++) {
            var ix = this.Interactions[i];
            if (ix.Known) {
                var x0 = this.Drugs[ix.Drug].X, y0 = this.Drugs[ix.Drug].Y;
                var x1 = this.Targets[ix.Target].X, y1 = this.Targets[ix.Target].Y;

                ctx.moveTo(x0, y0);
                ctx.lineTo(x1, y1);
            }
        }

        ctx.stroke();

        // draw unknown interaction dashed lines
        ctx.beginPath();
        ctx.lineWidth = 1;
        ctx.strokeStyle = "#6500FF";

        for (var i = 0; i < this.Interactions.length; i++) {
            var ix = this.Interactions[i];
            if (!ix.Known) {
                var x0 = this.Drugs[ix.Drug].X, y0 = this.Drugs[ix.Drug].Y;
                var x1 = this.Targets[ix.Target].X, y1 = this.Targets[ix.Target].Y;

                ctx.dashedLineTo(x0, y0, x1, y1, 4);
            }
        }

        ctx.stroke();

        // draw drug nodes
        for (var i = 0; i < this.Drugs.length; i++) {
            var node = this.Drugs[i];
            var rb = Navigation.ToPhysical(node.X + DrugStyle.Size / 2, node.Y + DrugStyle.Size / 2);
            var lt = Navigation.ToPhysical(node.X - DrugStyle.Size / 2, node.Y - DrugStyle.Size / 2);

            if (rb.x <= 0 || rb.y <= 0 || lt.x >= canvas.width || lt.y >= canvas.height) {
                continue;
            }

            if (node.Selected) {
                ctx.drawRound(node.X, node.Y, DrugStyle.Size / 2, DrugStyle.SelectedFillColor,
                    DrugStyle.BorderWidth, DrugStyle.BorderPaint, node.Name, DrugStyle.SelectedLabelColor,
                    DrugStyle.LabelFontSize);
            } else {
                ctx.drawRound(node.X, node.Y, DrugStyle.Size / 2, DrugStyle.FillColor,
                    DrugStyle.BorderWidth, DrugStyle.BorderPaint, node.Name, DrugStyle.LabelColor,
                    DrugStyle.LabelFontSize);
            }
        }

        // draw target nodes
        for (var i = 0; i < this.Targets.length; i++) {
            var node = this.Targets[i];
            var rb = Navigation.ToPhysical(node.X + TargetStyle.Size / 2, node.Y + TargetStyle.Size / 2);
            var lt = Navigation.ToPhysical(node.X - TargetStyle.Size / 2, node.Y - TargetStyle.Size / 2);

            if (rb.x <= 0 || rb.y <= 0 || lt.x >= canvas.width || lt.y >= canvas.height) {
                continue;
            }

            var style;
            if (node.Known) {
                style = KnownTargetStyle;
            } else {
                style = TargetStyle;
            }

            if (node.Selected) {
                ctx.drawRound(node.X, node.Y, (style.Size + 5 * node.Drugs.length) / 2, style.SelectedFillColor,
                    style.BorderWidth, style.BorderPaint, node.Name, style.SelectedLabelColor,
                    style.LabelFontSize);
            } else {
                ctx.drawRound(node.X, node.Y, (style.Size + 5 * node.Drugs.length) / 2, style.FillColor,
                    style.BorderWidth, style.BorderPaint, node.Name, style.LabelColor,
                    style.LabelFontSize);
            }
        }

        // draw known interaction labels
        var textSize = 12;
        ctx.font = "bold " + textSize + "px Arial";
        ctx.fillStyle = "#007723";
        var a = DrugStyle.Size / 2, b = KnownTargetStyle.Size / 2;

        for (var i = 0; i < this.Interactions.length; i++) {
            var ix = this.Interactions[i];
            if (ix.Known && (InteractionStyle.ShowLabel ^ ix.Reverse)) {
                var x0 = this.Drugs[ix.Drug].X, y0 = this.Drugs[ix.Drug].Y;
                var x1 = this.Targets[ix.Target].X, y1 = this.Targets[ix.Target].Y;
                var l = Math.sqrt((x1 - x0) * (x1 - x0) + (y1 - y0) * (y1 - y0));
                var f = (l + a - b) / l / 2;

                var text = ix.Value;
                var textWidth = ctx.measureText(text).width;
                ctx.fillText(text, x0 + (x1 - x0) * f - textWidth / 2, y0 + (y1 - y0) * f + textSize / 2);
            }
        }

        // draw unknown interaction labels
        ctx.fillStyle = "#320077";
        b = TargetStyle.Size / 2;
        for (var i = 0; i < this.Interactions.length; i++) {
            var ix = this.Interactions[i];
            if (!ix.Known && (InteractionStyle.ShowLabel ^ ix.Reverse)) {
                var x0 = this.Drugs[ix.Drug].X, y0 = this.Drugs[ix.Drug].Y;
                var x1 = this.Targets[ix.Target].X, y1 = this.Targets[ix.Target].Y;
                var l = Math.sqrt((x1 - x0) * (x1 - x0) + (y1 - y0) * (y1 - y0));
                var f = (l + a - b) / l / 2;

                var text = ix.Value;
                var textWidth = ctx.measureText(text).width;
                ctx.fillText(text, x0 + (x1 - x0) * f - textWidth / 2, y0 + (y1 - y0) * f + textSize / 2);
            }
        }

        // cleanup context
        ctx.restore();
    },

    Shift: function (dx, dy) {
        if (this.SelectedIds.length === 0) {
            return false;
        }

        for (var i = 0; i < this.SelectedIds.length; i++) {
            var id = this.SelectedIds[i];
            if (this.IsDrugId(id)) {
                id = this.DecodeDrugId(id)
                this.Drugs[id].X += dx;
                this.Drugs[id].Y += dy;
            } else if (this.IsTargetId(id)) {
                id = this.DecodeTargetId(id);
                this.Targets[id].X += dx;
                this.Targets[id].Y += dy;
            }
        }

        return true;
    },
};

var Palette = {
    Hue: 0,
    Saturation: 0,
    Lightness: 0,

    Strip: { width: 200, height: 40 },
    Block: { width: 80, height: 60 },
    PaletteMargin: { x: 10, y: 10 },
    StripMargin: .3,

    Init: function (width, height, color) {
        var client = { width: width - 2 * this.PaletteMargin.x, height: height - 2 * this.PaletteMargin.y };
        this.Strip = { width: client.width, height: client.height / 4 };
        this.Block = { width: client.width * .3, height: client.height / 4 };
        this.Hue = color.h;
        this.Saturation = color.s;
        this.Lightness = color.l;
    },

    HitTest: function (x, y) {
        x -= this.PaletteMargin.x;
        y -= this.PaletteMargin.y;

        if (x < 0 || y < 0
            || x > this.Strip.width || y > this.Strip.height * 3) {
            return null;
        }
        if (y < this.Strip.height) {
            return { x: x / this.Strip.width, y: "h" };
        }

        y -= this.Strip.height;
        if (y < 0) {
            return null;
        }
        if (y < this.Strip.height) {
            return { x: x / this.Strip.width, y: "s" };
        }

        y -= this.Strip.height;
        if (y < 0) {
            return null;
        }
        if (y < this.Strip.height) {
            return { x: x / this.Strip.width, y: "l" };
        }

        return null;
    },

    Select: function (sel) {
        switch (sel.y) {
            case "h": this.Hue = sel.x; break;
            case "s": this.Saturation = sel.x; break;
            case "l": this.Lightness = sel.x; break;
        }
    },

    DrawSlider: function (ctx, x, y, value) {
        ctx.beginPath();
        ctx.moveTo(x + value * this.Strip.width, y);
        ctx.lineTo(x + value * this.Strip.width - this.Strip.height * .1, y + this.Strip.height * .2);
        ctx.lineTo(x + value * this.Strip.width + this.Strip.height * .1, y + this.Strip.height * .2);
        ctx.closePath();
        ctx.fillStyle = "#000";
        ctx.fill();
    },

    Draw: function (canvas) {
        if (!canvas.getContext) {
            return;
        }

        var ctx = canvas.getContext("2d");

        ctx.clearRect(0, 0, canvas.width, canvas.height);

        var width = this.Strip.width, height = this.Strip.height * (1 - this.StripMargin);

        // draw hue strip
        var x = this.PaletteMargin.x, y = this.PaletteMargin.y;

        var grd1 = ctx.createLinearGradient(x, 0, x + width, 0);
        grd1.addColorStop(0 / 6, "rgb(255,000,000)");
        grd1.addColorStop(1 / 6, "rgb(255,255,000)");
        grd1.addColorStop(2 / 6, "rgb(000,255,000)");
        grd1.addColorStop(3 / 6, "rgb(000,255,255)");
        grd1.addColorStop(4 / 6, "rgb(000,000,255)");
        grd1.addColorStop(5 / 6, "rgb(255,000,255)");
        grd1.addColorStop(6 / 6, "rgb(255,000,000)");

        ctx.fillStyle = grd1;
        ctx.fillRect(x, y, width, height);

        this.DrawSlider(ctx, x, y + height, this.Hue);

        // draw saturation strip
        y += this.Strip.height;

        var rgb = ToRGB(this.Hue, 1, .5);
        var grd2 = ctx.createLinearGradient(x, 0, x + width, 0);
        grd2.addColorStop(0, "rgb(127,127,127)");
        grd2.addColorStop(1, "rgb(" + rgb.r + "," + rgb.g + "," + rgb.b + ")");

        ctx.fillStyle = grd2;
        ctx.fillRect(x, y, width, height);

        this.DrawSlider(ctx, x, y + height, this.Saturation);

        // draw value strip
        y += this.Strip.height;

        var rgb = ToRGB(this.Hue, this.Saturation, .5);
        var grd3 = ctx.createLinearGradient(x, 0, x + width, 0);
        grd3.addColorStop(0, "rgb(0,0,0)");
        grd3.addColorStop(.5, "rgb(" + rgb.r + "," + rgb.g + "," + rgb.b + ")");
        grd3.addColorStop(1, "rgb(255,255,255)");

        ctx.fillStyle = grd3;
        ctx.fillRect(x, y, width, height);

        this.DrawSlider(ctx, x, y + height, this.Lightness);

        // draw result
        y += this.Strip.height;

        var rgb = ToRGB(this.Hue, this.Saturation, this.Lightness);
        ctx.fillStyle = "rgb(" + rgb.r + "," + rgb.g + "," + rgb.b + ")";
        ctx.fillRect(x, y, this.Block.width, this.Block.height);
        //ctx.lineWidth = 1;
        //ctx.strokeStyle = "#000";
        //ctx.strokeRect(x, y, 80, 60);
    }
};

$(function () {
    var canvasVP = $("canvas.viewport");

    if (canvasVP.length === 0 || !canvasVP[0].getContext) {
        return;
    }

    var toolbox = $("aside.toolbox");

    $(window).resize(function (event) {
        canvasVP.attr("width", this.innerWidth);
        canvasVP.attr("height", this.innerHeight);
        canvasVP.css("width", this.innerWidth);
        canvasVP.css("height", this.innerHeight);

        DrugModel.Draw(canvasVP[0]);

        return false;
    });

    canvasVP.mousewheel(function (event, delta) {
        Navigation.Zoom(event.offsetX, event.offsetY, delta);

        DrugModel.Draw(event.target);

        return false;
    });

    var dragging = false, dragged = false, cursorX = 0, cursorY = 0;
    canvasVP.mousedown(function (event) {
        dragged = false;

        cursorX = event.offsetX;
        cursorY = event.offsetY;

        dragging = true;

        if (event.ctrlKey) {
            return false;
        }

        var pos = Navigation.ToLogical(event.offsetX, event.offsetY);
        var dirty = false;
        var sel = DrugModel.HitTest(pos.x, pos.y);

        if (sel === null) { // clicked on the blank area
            if (DrugModel.UnselectAll()) {
                toolbox.fadeOut();
                //$("canvas.palette").fadeOut();
                $("canvas.palette").remove();
                dirty = true;
            }
        } else if (DrugModel.IsInteractionId(sel)) {
            var id = DrugModel.DecodeInteractionId(sel);
            DrugModel.Interactions[id].Reverse = !DrugModel.Interactions[id].Reverse;
            dirty = true;
        } else { // clicked on something
            if (DrugModel.Select(sel)) {
                var style = DrugModel.GetSelectionStyle();

                toolbox.find("div:eq(0)").css("background", ToRGBs(style.color));
                toolbox.find("div:eq(0)").attr("data-hsl", JSON.stringify(style.color));
                toolbox.find("div:eq(0)").attr("data-target", "color");
                toolbox.find("div:eq(1)").css("background", ToRGBs(style.borderColor));
                toolbox.find("div:eq(1)").attr("data-hsl", JSON.stringify(style.borderColor));
                toolbox.find("div:eq(1)").attr("data-target", "borderColor");
                toolbox.find("div:eq(2)").css("background", ToRGBs(style.textColor));
                toolbox.find("div:eq(2)").attr("data-hsl", JSON.stringify(style.textColor));
                toolbox.find("div:eq(2)").attr("data-target", "textColor");
                toolbox.find("input:eq(0)").val(style.size);
                toolbox.find("input:eq(0)").attr("data-target", "size");
                toolbox.find("input:eq(0)").css("color", "#000");
                toolbox.find("input:eq(1)").val(style.borderWidth);
                toolbox.find("input:eq(1)").attr("data-target", "borderWidth");
                toolbox.find("input:eq(1)").css("color", "#000");
                toolbox.find("input:eq(2)").val(style.textSize);
                toolbox.find("input:eq(2)").attr("data-target", "textSize");
                toolbox.find("input:eq(2)").css("color", "#000");

                toolbox.fadeIn();
                $("canvas.palette").remove();
                dirty = true;
            }
        }

        if (dirty) {
            DrugModel.Draw(event.target);
        }

        return false;
    });

    canvasVP.mouseup(function (event) {
        dragging = false;

        if (!event.ctrlKey) {
            return false;
        }

        if (dragged) {
            return false;
        }

        var pos = Navigation.ToLogical(event.offsetX, event.offsetY);
        var dirty = false;
        var sel = DrugModel.HitTest(pos.x, pos.y);

        if (sel === null) { // clicked on the blank area
        } else { // clicked on something
            if (DrugModel.MultiSelect(sel)) {
                toolbox.fadeOut();
                dirty = true;
            }
        }

        if (dirty) {
            DrugModel.Draw(event.target);
        }

        return false;
    });

    canvasVP.mousemove(function (event) {
        if (!dragging) {
            return false;
        }

        dragged = true;

        var dirty = false;

        if (event.shiftKey) { // pan the viewport
            Navigation.Pan(event.offsetX - cursorX, event.offsetY - cursorY);
            cursorX = event.offsetX;
            cursorY = event.offsetY;
            dirty = true;
        } else { // move selected items
            var dx = (event.offsetX - cursorX) / Navigation.Scale;
            var dy = (event.offsetY - cursorY) / Navigation.Scale;

            if (DrugModel.Shift(dx, dy)) {
                cursorX = event.offsetX;
                cursorY = event.offsetY;
                dirty = true;
            }
        }

        if (dirty) {
            DrugModel.Draw(event.target);
        }

        return false;
    });

    $(document).keypress(function (event) {
        if (event.which == 32) {
            InteractionStyle.ShowLabel = !InteractionStyle.ShowLabel;

            for (var i = 0; i < DrugModel.Interactions.length; i++) {
                DrugModel.Interactions[i].Reverse = false;
            }
            dirty = true;
        }

        if (dirty) {
            DrugModel.Draw(canvasVP[0]);
        }

        return false;
    });

    DrugModel.Init(model);
    DrugModel.Layout(screen.availWidth, screen.availHeight);

    $(window).resize();

    ///////////////////////////////////////////

    toolbox.find("input").keypress(function (event) {
        if (event.key !== '.' && (event.key < '0' || event.key > '9')) {
            return false;
        }
    }).keyup(function (event) {
        var numPane = $(this);

        var num = parseFloat(numPane.val());
        var max = parseInt(numPane.attr("max")), min = parseInt(numPane.attr("min"));

        if (isNaN(num) || num < min || num > max) {
            numPane.css("color", "#F00");
            return false;
        }

        numPane.css("color", "#000");

        var style = {};
        style[numPane.attr("data-target")] = num;
        DrugModel.SetSelectionStyle(style);
        DrugModel.Draw(canvasVP[0]);
        return false;
    });

    toolbox.find("div").click(function (event) {
        var colorPane = $(this);

        if ($("canvas.palette").length > 0) {
            $("canvas.palette").remove();
        }

        var palette = $("<canvas class='palette'>");
        colorPane.parent().after(palette);

        var pltWidth = 300, pltHeight = 200;
        palette.attr("width", pltWidth);
        palette.attr("height", pltHeight);
        palette.css("width", pltWidth);
        palette.css("height", pltHeight);
        palette.css("left", toolbox.position().left + toolbox.outerWidth());
        palette.css("top", colorPane.position().top);

        var sliding = false;
        palette.mousedown(function (event) {
            if (sliding) {
                return false;
            }

            var sel = Palette.HitTest(event.offsetX, event.offsetY);
            if (sel === null) {
                return false;
            }

            sliding = true;

            var sel = Palette.HitTest(event.offsetX, event.offsetY);
            if (sel === null) {
                return false;
            }

            Palette.Select(sel);
            Palette.Draw(palette[0]);

            var selected = { h: Palette.Hue, s: Palette.Saturation, l: Palette.Lightness };
            colorPane.css("background", ToRGBs(selected));

            var style = {};
            style[colorPane.attr("data-target")] = selected;
            DrugModel.SetSelectionStyle(style);
            DrugModel.Draw(canvasVP[0]);
            return false;
        });

        palette.mouseup(function (event) {
            sliding = false;
            return false;
        });

        palette.mousemove(function (event) {
            if (!sliding) {
                return false;
            }

            var sel = Palette.HitTest(event.offsetX, event.offsetY);
            if (sel === null) {
                return false;
            }

            Palette.Select(sel);
            Palette.Draw(palette[0]);

            var selected = { h: Palette.Hue, s: Palette.Saturation, l: Palette.Lightness };
            colorPane.css("background", ToRGBs(selected));

            var style = {};
            style[colorPane.attr("data-target")] = selected;
            DrugModel.SetSelectionStyle(style);
            DrugModel.Draw(canvasVP[0]);
            return false;
        });

        var color = JSON.parse(colorPane.attr("data-hsl"));

        Palette.Init(palette[0].width, palette[0].height, color);
        Palette.Draw(palette[0]);

        palette.fadeIn();
    });

});