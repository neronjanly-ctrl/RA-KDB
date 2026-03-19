
var NodeStyle = {
    BorderPaint: "#069",
    BorderWidth: 4.0,
    FillColor: "#09C",
    SelectedFillColor: "#ff0",
    Height: 30.0,
    Label: "",
    LabelColor: "#fff",
    LabelSelectedColor: "#333",
    LabelFontSize: 12,
    Shape: "roundRect",
    Size: 35.0,
    Transparency: 255,
    Width: 70.0,
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

CanvasRenderingContext2D.prototype.drawLabel = function (text, centerX, centerY, selected) {
    if (text === undefined || text === null || text === "") {
        text = NodeStyle.Label;
    }

    var width = NodeStyle.Width - NodeStyle.BorderWidth;
    var height = NodeStyle.Height - NodeStyle.BorderWidth;

    this.roundRect(centerX - width / 2, centerY - height / 2, width, height, 4);

    if (NodeStyle.BorderWidth > 0) {
        this.lineWidth = NodeStyle.BorderWidth;
        this.strokeStyle = NodeStyle.BorderPaint;
        this.stroke();
    }

    if (selected) {
        this.fillStyle = NodeStyle.SelectedFillColor;
    } else {
        this.fillStyle = NodeStyle.FillColor;
    }
    this.fill();

    var textHeight = NodeStyle.LabelFontSize;
    this.font = " " + textHeight + "px Arial";

    var textWidth = this.measureText(text).width;

    if (selected) {
        this.fillStyle = NodeStyle.LabelSelectedColor;
    } else {
        this.fillStyle = NodeStyle.LabelColor;
    }
    this.fillText(text, centerX - textWidth / 2, centerY + textHeight / 3);

    return this;
};

function draw(canvas) {
    var ctx = canvas.getContext("2d");

    ctx.save();

    ctx.clearRect(0, 0, canvas.width, canvas.height);

    ctx.scale(Navigation.Scale, Navigation.Scale);
    ctx.translate(Navigation.OffsetX, Navigation.OffsetY);

    ctx.beginPath();
    for (var i in model.Edges) {
        var edges = model.Edges[i];
        for (var j in edges) {
            ctx.moveTo(model.Nodes[i].PosX, model.Nodes[i].PosY);
            ctx.lineTo(model.Nodes[edges[j]].PosX, model.Nodes[edges[j]].PosY);
        }
    }

    ctx.lineWidth = 3;
    ctx.strokeStyle = "#666";
    ctx.stroke();

    for (var i in model.Nodes) {
        var node = model.Nodes[i];
        var rb = Navigation.ToPhysical(node.PosX + NodeStyle.Width / 2, node.PosY + NodeStyle.Height / 2);
        var lt = Navigation.ToPhysical(node.PosX - NodeStyle.Width / 2, node.PosY - NodeStyle.Height / 2);

        if (rb.x <= 0 || rb.y <= 0 || lt.x >= canvas.width || lt.y >= canvas.height) {
            continue;
        }
        ctx.drawLabel(node.Name, node.PosX, node.PosY, node.Selected);
    }

    ctx.restore();
}

function construct() {

}

function initNodes() {
    var count = model.Nodes.length;
    var cols = Math.floor(Math.sqrt(count));

    var width = NodeStyle.Width + 10, height = NodeStyle.Height + 10;
    var offsetX = width / 2, offsetY = height / 2;

    for (var i = 0; i < count; i++) {
        model.Nodes[i] = {
            Id: i,
            Name: model.Nodes[i],
            PosX: offsetX + Math.floor(i / cols) * width,
            PosY: offsetY + i % cols * height,
            Selected: false,
        }
    }

    model.SelectedIds = [];
}

$(function () {
    var canvas = $("canvas");

    if (!canvas[0].getContext) return;

    $(window).resize(function (event) {
        canvas.prop("width", this.innerWidth);
        canvas.prop("height", this.innerHeight);
        canvas.css("width", this.innerWidth);
        canvas.css("height", this.innerHeight);

        draw(canvas[0]);

        return false;
    });

    canvas.mousewheel(function (event, delta) {
        Navigation.Zoom(event.offsetX, event.offsetY, delta);

        draw(event.target);

        return false;
    });

    var dragging = false, dragged = false, cursorX = 0, cursorY = 0;
    canvas.mousedown(function (event) {
        dragged = false;

        if (event.ctrlKey) return false;

        cursorX = event.offsetX;
        cursorY = event.offsetY;
        dragging = true;

        return false;
    });

    canvas.mouseup(function (event) {
        dragging = false;

        return false;
    });

    canvas.mousemove(function (event) {
        if (!dragging) return false;

        dragged = true;

        var dirty = false;

        if (event.shiftKey) {
            Navigation.Pan(event.offsetX - cursorX, event.offsetY - cursorY);
            cursorX = event.offsetX;
            cursorY = event.offsetY;
            dirty = true;
        } else {
            if (model.SelectedIds.length > 0) {
                var dx = (event.offsetX - cursorX) / Navigation.Scale;
                var dy = (event.offsetY - cursorY) / Navigation.Scale;

                for (var i in model.SelectedIds) {
                    model.Nodes[model.SelectedIds[i]].PosX += dx;
                    model.Nodes[model.SelectedIds[i]].PosY += dy;
                }

                cursorX = event.offsetX;
                cursorY = event.offsetY;

                dirty = true;
            }
        }

        draw(event.target);

        return false;
    });

    canvas.click(function (event) {
        if (dragged) return false;

        var pos = Navigation.ToLogical(event.offsetX, event.offsetY);

        var w2 = NodeStyle.Width / 2, h2 = NodeStyle.Height / 2;
        var dirty = false, onblank = !event.ctrlKey;

        for (var i in model.Nodes) {
            if (Math.abs(pos.x - model.Nodes[i].PosX) > w2
                || Math.abs(pos.y - model.Nodes[i].PosY) > h2) {
                continue;
            }

            if (!event.ctrlKey) {
                onblank = false;

                // single selection: clicking on the only selected node takes no effect.
                if (model.Nodes[i].Selected
                    && model.SelectedIds.length == 1) {
                    break;
                }

                // single selection: clicking on nonselected node unselects the others.
                for (var j in model.SelectedIds) {
                    model.Nodes[model.SelectedIds[j]].Selected = false;
                }

                model.SelectedIds = [i];
                model.Nodes[i].Selected = true;

                dirty = true;
                break;
            } else {
                // multiple selection: clicking on the selected node unselects itself.
                if (model.Nodes[i].Selected) {
                    model.Nodes[i].Selected = false;
                    for (var j in model.SelectedIds) {
                        if (model.SelectedIds[j] == i) {
                            model.SelectedIds.splice(j, 1);
                            break;
                        }
                    }
                    dirty = true;
                } else {
                    // multiple selection： clicking on the nonselected node selects itself.
                    model.Nodes[i].Selected = true;
                    model.SelectedIds.push(i);
                    dirty = true;
                }
            }
        }

        if (onblank) {
            if (model.SelectedIds.length > 0) {
                for (var j in model.SelectedIds) {
                    model.Nodes[model.SelectedIds[j]].Selected = false;
                }
                model.SelectedIds = [];
                dirty = true;
            }
        }

        if (dirty) draw(event.target);

        return false;
    });

    initNodes();

    $(window).resize();
});