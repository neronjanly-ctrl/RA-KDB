
class ViewportRenderer {
    drugs: Drug[];
    targets: Target[];
    interactions: Interaction[];
    selectedIds: number[];

    navigation: Navigation;
    settings: Settings;

    constructor(model: InputData) {
        this.navigation = new Navigation();
        this.settings = new Settings();
        this.selectedIds = [];

        const drugCount = model.drugs.length;

        this.drugs = [];
        for (let i = 0; i < drugCount; i++) {
            this.drugs[i] = {
                id: i,
                name: model.drugs[i][0],
                targets: model.drugTargets[i],
                selected: false,
                x: 0,
                y: 0,
            };
        }

        const targetCount = model.targets.length;

        this.targets = [];
        const orgSet = new Set<string>();
        for (const [, org] of model.targets)
            orgSet.add(org);

        for (let i = 0; i < targetCount; i++) {
            this.targets[i] = {
                id: i,
                name: model.targets[i][1] === "HUMAN" || orgSet.size === 1 ? model.targets[i][0] : `${model.targets[i][0]}\n${model.targets[i][1]}`,
                known: model.targetStates[i] !== 0,
                drugs: model.targetDrugs[i],
                selected: false,
                x: 0,
                y: 0,
            };
        }

        const interactionCount = model.interactions.length;

        this.interactions = [];
        for (let i = 0; i < interactionCount; i++) {
            this.interactions[i] = {
                drug: model.interactions[i][0],
                target: model.interactions[i][1],
                value: (model.interactions[i][2] / 1000.0).toString(),
                known: model.interactions[i][3] !== 0,
                reverse: false,
            };
        }
    }

    private nearest(combs: Map<string, boolean>, x: number, y: number, centerX: number, centerY: number): Point {
        const distY = this.settings.unknownTargetStyle.size * 2, distX = distY / 2 * Math.sqrt(3);

        x = Math.round((x - centerX) / distX);
        y = Math.round((y - centerY + (x % 2 === 0 ? 0 : distY / 2)) / distY);

        for (let j = 1; ; j++) {
            for (let l = 0; l < j; l++) {
                y++;
                if (!combs.has(`${x},${y}`)) {
                    combs.set(`${x},${y}`, true);
                    return new Point(centerX + x * distX, centerY + y * distY + (x % 2 === 0 ? 0 : distY / 2));
                }
            }
            for (let l = 0; l < j; l++) {
                x--;
                if (!combs.has(`${x},${y}`)) {
                    combs.set(`${x},${y}`, true);
                    return new Point(centerX + x * distX, centerY + y * distY + (x % 2 === 0 ? 0 : distY / 2));
                }
            }

            j++;
            for (let l = 0; l < j; l++) {
                y--;
                if (!combs.has(`${x},${y}`)) {
                    combs.set(`${x},${y}`, true);
                    return new Point(centerX + x * distX, centerY + y * distY + (x % 2 === 0 ? 0 : distY / 2));
                }
            }
            for (let l = 0; l < j; l++) {
                x++;
                if (!combs.has(`${x},${y}`)) {
                    combs.set(`${x},${y}`, true);
                    return new Point(centerX + x * distX, centerY + y * distY + (x % 2 === 0 ? 0 : distY / 2));
                }
            }
        }
    }

    private _drugsStackLayout(drugIds: number[], x: number, y: number, boxWidth: number, boxHeight: number): void {
        for (let i = 0; i < drugIds.length; i++) {
            const drug = this.drugs[drugIds[i]];
            if (boxWidth > boxHeight) {
                drug.x = x + (i + 0.5) * boxWidth / drugIds.length;
                drug.y = y + boxHeight / 2;
            }
            else {
                drug.x = x + boxWidth / 2;
                drug.y = y + (i + 0.5) * boxHeight / drugIds.length;
            }
            if (drug.targets.length !== 0) {
                const coords = ArcLayout.layout(
                    drug, drug.targets.length, this.settings.unknownTargetStyle.size, this.settings.drugStyle.size / 2, this.settings.branchesPerRound);
                this._placeTargets(coords, drug.targets);
            }
        }
    }

    private _placeTargets(coords: _Point[], selector: number[]) {
        for (let i = 0; i < selector.length; i++) {
            this.targets[selector[i]].x = coords[i].x;
            this.targets[selector[i]].y = coords[i].y;
        }
    }

    private _placeDrugs(coords: _Point[], selector: number[]) {
        for (let i = 0; i < selector.length; i++) {
            this.drugs[selector[i]].x = coords[i].x;
            this.drugs[selector[i]].y = coords[i].y;
        }
    }

    private _drugsNetworkLayout(drugIds: number[], x: number, y: number, boxWidth: number, boxHeight: number): void {
        // Fetch full-degree/multi-degree target nodes and one-drug/two-drug targets for drugIds
        const n = drugIds.length;
        const fullTarIds: number[] = [], multiTarIds: number[] = [], drugDegs = Array<number>(n).fill(0);
        const oneTarIds = Array2D.create<number>(n), twoTarIds = Array3D.createMono<number>(n), threeTarIds = Array4D.createMono<number>(n);

        for (let i = 0; i < this.targets.length; i++) {
            let deg = 0, drug1 = -1, drug2 = -1, drug3 = -1;
            for (let j = 0; j < this.targets[i].drugs.length; j++) {
                const idx = drugIds.indexOf(this.targets[i].drugs[j]);
                if (idx >= 0) {
                    drugDegs[idx]++;
                    deg++;
                    if (deg === 1)
                        drug1 = idx;
                    else if (deg === 2)
                        drug2 = idx;
                    else if (deg === 3)
                        drug3 = idx;
                }
            }
            if (deg > 1)
                multiTarIds.push(i);
            if (deg === drugIds.length)
                fullTarIds.push(i);
            if (deg === 1)
                oneTarIds[drug1].push(i);
            else if (deg === 2) {
                twoTarIds[drug1][drug2].push(i);
                twoTarIds[drug2][drug1].push(i);
            }
            else if (deg === 3) {
                threeTarIds[drug1][drug2][drug3].push(i);
                threeTarIds[drug1][drug3][drug2].push(i);
                threeTarIds[drug2][drug1][drug3].push(i);
                threeTarIds[drug2][drug3][drug1].push(i);
                threeTarIds[drug3][drug1][drug2].push(i);
                threeTarIds[drug3][drug2][drug1].push(i);
            }
        }

        const center: _Point = { x: x + boxWidth / 2, y: y + boxHeight / 2 };
        const rowHeight = this.settings.rowHeight, targetDistance = this.settings.targetDistance;
        const targetSize = this.settings.unknownTargetStyle.size, drugSize = this.settings.drugStyle.size, targetDensity = this.settings.branchesPerRound;
        const targetSizes = [0, targetSize + 5, targetSize + 5 * 2, targetSize + 5 * 3, targetSize + 5 * 4, targetSize + 5 * 5];

        // One drug: arrange targets around the canvas center
        if (drugIds.length === 1) {
            this._placeDrugs([center], drugIds);
            let coords: _Point[];
            if (fullTarIds.length > targetDensity)
                coords = SpiralLayout.layout(center, fullTarIds.length, targetSizes[1], drugSize * 0.8, targetDensity);
            else
                coords = ArcLayout.layout(center, fullTarIds.length, targetSizes[1], drugSize * 0.8, targetDensity);
            this._placeTargets(coords, fullTarIds);
            return;
        }

        // Two drugs: arrange targets in rows in the canvas center
        if (drugIds.length === 2) {
            const off = boxHeight / 4;
            const p0: _Point = { x: center.x, y: center.y - off }, p1: _Point = { x: center.x, y: center.y + off };
            this._placeDrugs([p0, p1], drugIds);

            // Place two-degree targets
            this._placeTargets(BisectorLayout.layout(p0, p1, fullTarIds.length, targetSizes[2], rowHeight, targetDistance, boxWidth), fullTarIds);

            // Calculate the field angle for the bisector layout
            const boxSize = BisectorLayout.measure(fullTarIds.length, targetSizes[2], rowHeight, targetDistance, boxWidth);
            const fieldAngle = (Math.PI - Math.atan2(boxSize.width / 2, off - boxSize.height / 2)) * 2;

            // Place one-degree targets
            this._placeTargets(ArcLayout.layout(p0, oneTarIds[0].length, targetSizes[1], drugSize / 2, targetDensity, 0, fieldAngle), oneTarIds[0]);
            this._placeTargets(ArcLayout.layout(p1, oneTarIds[1].length, targetSizes[1], drugSize / 2, targetDensity, Math.PI, fieldAngle), oneTarIds[1]);
            return;
        }

        // Three drugs: arrange drugs in a row, a pair with a hanging, or a triangle
        if (drugIds.length === 3) {
            let idx: number[] | undefined;
            if (fullTarIds.length === 0) {
                if (twoTarIds[0][1].length === 0) {
                    idx = [0, 2, 1];
                }
                else if (twoTarIds[1][2].length === 0) {
                    idx = [1, 0, 2];
                }
                else if (twoTarIds[0][2].length === 0) {
                    idx = [0, 1, 2];
                }
            }

            // Linear layout and no 3-degree targets
            if (idx !== undefined) {
                const off = boxHeight * 0.3;
                const p0: _Point = { x: center.x, y: center.y - off }, p1 = center, p2: _Point = { x: center.x, y: center.y + off };
                this._placeDrugs([p0, p1, p2], [drugIds[idx[0]], drugIds[idx[1]], drugIds[idx[2]]]);

                // Place two-degree targets
                this._placeTargets(BisectorLayout.layout(p0, p1, twoTarIds[idx[0]][idx[1]].length, targetSizes[2], rowHeight, targetDistance, boxWidth), twoTarIds[idx[0]][idx[1]]);
                this._placeTargets(BisectorLayout.layout(p1, p2, twoTarIds[idx[1]][idx[2]].length, targetSizes[2], rowHeight, targetDistance, boxWidth), twoTarIds[idx[1]][idx[2]]);

                // Calculate the field angle for the bisector layout
                const boxSize1 = BisectorLayout.measure(twoTarIds[idx[0]][idx[1]].length, targetSizes[2], rowHeight, targetDistance, boxWidth);
                const boxSize2 = BisectorLayout.measure(twoTarIds[idx[1]][idx[2]].length, targetSizes[2], rowHeight, targetDistance, boxWidth);
                const fieldAngle0 = (Math.PI - Math.atan2(boxSize1.width / 2, off - boxSize1.height / 2)) * 2;
                const fieldAngle2 = (Math.PI - Math.atan2(boxSize2.width / 2, off - boxSize2.height / 2)) * 2;
                const fieldAngle1 = (fieldAngle0 + fieldAngle2) / 2 - Math.PI;
                const offsetAngle = (fieldAngle0 - fieldAngle2) / 2;

                // Place one-degree targets
                const n1 = Math.floor(oneTarIds[idx[1]].length / 2), n2 = oneTarIds[idx[1]].length - n1;
                this._placeTargets(ArcLayout.layout(p0, oneTarIds[idx[0]].length, targetSizes[1], drugSize / 2, targetDensity, 0, fieldAngle0), oneTarIds[idx[0]]);
                this._placeTargets(ArcLayout.layout(p1, n1, targetSizes[1], drugSize / 2, targetDensity, Math.PI * 1.5 + offsetAngle, fieldAngle1), oneTarIds[idx[1]].slice(0, n1));
                this._placeTargets(ArcLayout.layout(p1, n2, targetSizes[1], drugSize / 2, targetDensity, Math.PI / 2 - offsetAngle, fieldAngle1), oneTarIds[idx[1]].slice(n1));
                this._placeTargets(ArcLayout.layout(p2, oneTarIds[idx[2]].length, targetSizes[1], drugSize / 2, targetDensity, Math.PI, fieldAngle2), oneTarIds[idx[2]]);
                return;
            }

            const interacts: number[] = [];
            let min = Infinity, max = -Infinity, mini = -1, maxi = -1;
            for (let i = 0; i < 3; i++) {
                interacts[i] = drugDegs[i] - oneTarIds[i].length;
                if (interacts[i] < min) {
                    min = interacts[i];
                    mini = i;
                }
                if (interacts[i] > max) {
                    max = interacts[i];
                    maxi = i;
                }
            }

            // Inbalanced weighted connections. Layout two together and isolate the other one.
            if (max >= 10 * min) {
                // i2, p2 is the isolated one
                const i0 = drugIds[3 - maxi - mini], i1 = drugIds[maxi], i2 = drugIds[mini];

                const off = boxHeight / 4, offx = boxWidth / 4;
                const p0: _Point = { x: center.x + offx / 2, y: center.y - off }, p1: _Point = { x: center.x + offx / 2, y: center.y + off }, p2: _Point = { x: boxWidth / 12, y: center.y };
                this._placeDrugs([p0, p1, p2], [i0, i1, i2]);

                // Place two-degree targets
                this._placeTargets(BisectorLayout.layout(p0, p1, twoTarIds[i0][i1].length, targetSizes[2], rowHeight, targetDistance, boxWidth - offx), twoTarIds[i0][i1]);
                this._placeTargets(BisectorLayout.layout(p0, p2, twoTarIds[i0][i2].length, targetSizes[2], rowHeight, targetDistance, offx), twoTarIds[i0][i2]);
                this._placeTargets(BisectorLayout.layout(p1, p2, twoTarIds[i1][i2].length, targetSizes[2], rowHeight, targetDistance, offx), twoTarIds[i1][i2]);

                // Place three-degree targets
                this._placeTargets(RingsLayout.layout({ x: p2.x + offx / 2, y: p2.y }, fullTarIds.length, targetSizes[3], rowHeight), fullTarIds);

                // Calculate the field angle for the bisector layout
                const boxSize = BisectorLayout.measure(twoTarIds[i0][i1].length, targetSizes[2], rowHeight, targetDistance, boxWidth - offx);
                const fieldAngle = (Math.PI - Math.atan2(boxSize.width / 2, off - boxSize.height / 2)) * 2;

                // Place one-degree targets
                this._placeTargets(ArcLayout.layout(p0, oneTarIds[i0].length, targetSizes[1], drugSize / 2, targetDensity, 0, fieldAngle), oneTarIds[i0]);
                this._placeTargets(ArcLayout.layout(p1, oneTarIds[i1].length, targetSizes[1], drugSize / 2, targetDensity, Math.PI, fieldAngle), oneTarIds[i1]);
                this._placeTargets(ArcLayout.layout(p2, oneTarIds[i2].length, targetSizes[1], drugSize / 2, targetDensity, Math.PI * 3 / 4, fieldAngle), oneTarIds[i2]);
                return;
            }

            // Place drugs
            const p: _Point[] = [
                { x: center.x, y: center.y - boxHeight * 0.3 },
                { x: center.x + boxWidth * 0.3, y: center.y + boxHeight * 0.3 },
                { x: center.x - boxWidth * 0.3, y: center.y + boxHeight * 0.3 }];
            for (let i = 0; i < 3; i++) {
                this._placeDrugs(p, drugIds);
            }

            // Place three-degree targets
            const radius = RingsLayout.measure(fullTarIds.length, targetSizes[3], targetDistance);
            this._placeTargets(RingsLayout.layout({ x: (p[0].x + p[1].x + p[2].x) / 3, y: (p[0].y + p[1].y + p[2].y) / 3 }, fullTarIds.length, targetSizes[3], targetDistance), fullTarIds);

            // Place two-degree targets
            for (let i = 0; i < 3; i++) {
                const j = (i + 1) % 3;
                let span: number, offset: number, threshold: number;
                if (i === 1) {
                    span = y + boxHeight - (p[0].y + p[1].y + p[2].y) / 3 - radius;
                    offset = radius * 0.7;
                    threshold = targetDensity / 2;
                }
                else {
                    span = boxWidth / 2 - radius;
                    offset = radius * 1.2;
                    threshold = targetDensity;
                }
                if (twoTarIds[i][j].length > threshold) {
                    const dx = p[j].x - p[i].x, dy = p[j].y - p[i].y, l = Math.sqrt(dx * dx + dy * dy);
                    const c: _Point = { x: (p[i].x + p[j].x) / 2 + offset * dy / l, y: (p[i].y + p[j].y) / 2 - offset * dx / l };
                    this._placeTargets(RingsLayout.layout(c, twoTarIds[i][j].length, targetSizes[2], targetDistance), twoTarIds[i][j]);
                }
                else {
                    this._placeTargets(BisectorLayout.layout(p[i], p[j], twoTarIds[i][j].length, targetSizes[2], rowHeight, targetDistance, span, offset), twoTarIds[i][j]);
                }
            }

            // Place one-degree targets
            for (let i = 0; i < 3; i++) {
                this._placeTargets(ArcLayout.layout(p[i], oneTarIds[i].length, targetSizes[1], drugSize / 2, targetDensity, i * Math.PI * 2 / 3, Math.PI * 8 / 5), oneTarIds[i]);
            }
            return;
        }

        // Four drugs: arrange drugs in a quad and categorize targets by degree
        if (drugIds.length === 4) {
            // Place drugs
            const p: _Point[] = [
                { x: center.x - boxWidth * 0.3, y: center.y - boxHeight * 0.3 },
                { x: center.x + boxWidth * 0.3, y: center.y - boxHeight * 0.3 },
                { x: center.x + boxWidth * 0.3, y: center.y + boxHeight * 0.3 },
                { x: center.x - boxWidth * 0.3, y: center.y + boxHeight * 0.3 }];
            for (let i = 0; i < 4; i++) {
                this._placeDrugs(p, drugIds);
            }

            // Place four-degree targets
            const radius = RingsLayout.measure(fullTarIds.length, targetSizes[4], targetDistance);
            this._placeTargets(RingsLayout.layout({ x: (p[0].x + p[1].x + p[2].x + p[3].x) / 4, y: (p[0].y + p[1].y + p[2].y + p[3].y) / 4 }, fullTarIds.length, targetSizes[4], targetDistance), fullTarIds);

            // Place two-degree targets
            for (let i = 0; i < 4; i++) {
                const j = (i + 1) % 4;
                const span = boxWidth / 2 - radius, offset = radius * 1.2, threshold = targetDensity / 3;
                if (twoTarIds[i][j].length > threshold) {
                    const dx = p[j].x - p[i].x, dy = p[j].y - p[i].y, l = Math.sqrt(dx * dx + dy * dy);
                    const c: _Point = { x: (p[i].x + p[j].x) / 2 + offset * dy / l, y: (p[i].y + p[j].y) / 2 - offset * dx / l };
                    this._placeTargets(RingsLayout.layout(c, twoTarIds[i][j].length, targetSizes[2], targetDistance), twoTarIds[i][j]);
                }
                else {
                    this._placeTargets(BisectorLayout.layout(p[i], p[j], twoTarIds[i][j].length, targetSizes[2], rowHeight, targetDistance, span, offset), twoTarIds[i][j]);
                }
            }
            for (let i = 0; i < 2; i++) {
                const j = (i + 2) % 4;
                const span = boxWidth / 2 - radius, offset = radius * 1.2, threshold = targetDensity / 3;
                if (twoTarIds[i][j].length > threshold) {
                    const dx = p[j].x - p[i].x, dy = p[j].y - p[i].y, l = Math.sqrt(dx * dx + dy * dy);
                    const c: _Point = { x: (p[i].x + p[j].x) / 2 + offset * dy / l, y: (p[i].y + p[j].y) / 2 - offset * dx / l };
                    this._placeTargets(RingsLayout.layout(c, twoTarIds[i][j].length, targetSizes[2], targetDistance), twoTarIds[i][j]);
                }
                else {
                    this._placeTargets(BisectorLayout.layout(p[i], p[j], twoTarIds[i][j].length, targetSizes[2], rowHeight, targetDistance, span, offset), twoTarIds[i][j]);
                }
            }

            // Place three-degree targets
            for (let i = 0; i < 4; i++) {
                const j = (i + 1) % 4, k = (j + 1) % 4;
                const offset = 1.8;
                const c: _Point = { x: (p[i].x + p[j].x * offset + p[k].x) / (2 + offset), y: (p[i].y + p[j].y * offset + p[k].y) / (2 + offset) };
                this._placeTargets(RingsLayout.layout(c, threeTarIds[i][j][k].length, targetSizes[3], targetDistance), threeTarIds[i][j][k]);
            }

            // Place one-degree targets
            for (let i = 0; i < 4; i++) {
                this._placeTargets(ArcLayout.layout(p[i], oneTarIds[i].length, targetSizes[1], drugSize / 2, targetDensity, (i - 0.5) * Math.PI / 2, Math.PI * 4 / 3), oneTarIds[i]);
            }
            return;
        }

        // extend the height to occupy unused space on the bottom of the box
        if (drugIds.length > 1 && drugIds.length % 2 === 1)
            boxHeight *= 2 / (1 + Math.cos(Math.PI / drugIds.length));

        const degree = Math.PI * 2 / drugIds.length;
        const combs = new Map<string, boolean>();

        // Layout drug nodes evenly on a circle centered at the box center
        for (let i = 0; i < drugIds.length; i++) {
            const direction = i * degree;
            const drug = this.drugs[drugIds[i]];

            // radius: the distance from the canvas center to the drug node center
            let radius: number;
            const fieldAngle = 2 * Math.PI - Math.pow(2, drugIds.length - 3) * Math.PI / drugIds.length;
            const arcSize = ArcLayout.measure(
                oneTarIds[i].length, targetSize, drugSize / 2, targetDensity, fieldAngle);
            radius = Math.min(boxWidth, boxHeight) / 2 - 5 / 2; // 5 is for fixing single drug target size
            if (direction > Math.PI / 2 && direction < Math.PI * 3 / 2) {
                radius -= arcSize / Math.cos(direction - Math.PI);
                //console.log(`${drug.name}: ${fieldAngle}, ${arcSize}, ${direction}; ${arcSize / Math.cos(direction - Math.PI)}, ${boxWidth}, ${boxHeight}, ${radius}`);
            }
            else {
                radius -= arcSize;
            }

            drug.x = center.x + Math.sin(direction) * radius;
            drug.y = center.y - Math.cos(direction) * radius;

            if (oneTarIds[i].length !== 0) {
                this._placeTargets(ArcLayout.layout(drug, oneTarIds[i].length, targetSize, drugSize / 2, targetDensity, direction, fieldAngle), oneTarIds[i]);
            }
        }

        // Multiple drugs: arrange targets in honeycomb in the canvas center
        for (const tid of multiTarIds) {
            const target = this.targets[tid];
            const drugs = target.drugs;

            let x = 0, y = 0;
            for (let j = 0; j < drugs.length; j++) {
                x += this.drugs[drugs[j]].x;
                y += this.drugs[drugs[j]].y;
            }

            const pos = this.nearest(combs, x / drugs.length, y / drugs.length, center.x, center.y);
            target.x = pos.x;
            target.y = pos.y;
        }
    }

    layout(screenWidth: number, screenHeight: number): void {
        const ds = new DisjointSet(this.drugs.length);

        for (let i = 0; i < this.targets.length; i++) {
            for (let j = 0; j < this.targets[i].drugs.length; j++)
                for (let k = j + 1; k < this.targets[i].drugs.length; k++)
                    ds.join(this.targets[i].drugs[j], this.targets[i].drugs[k]);
        }

        const singles: number[] = [];
        const multiples: number[] = [];

        for (const g of ds.groups()) {
            if (g.length === 1)
                singles.push(...g);
            else
                multiples.push(...g);
        }

        if (singles.length === 0) {
            this._drugsNetworkLayout(multiples, 0, 0, screenWidth, screenHeight);
        }
        else if (multiples.length === 0) {
            this._drugsNetworkLayout(singles, 0, 0, screenWidth, screenHeight);
        }
        else if (screenWidth > screenHeight) {
            const sideWidth = Math.max(this.settings.drugStyle.size + this.settings.knownTargetStyle.size * 6, Math.min(screenWidth / 4, screenWidth - screenHeight));
            this._drugsStackLayout(singles, 0, 0, sideWidth, screenHeight);
            this._drugsNetworkLayout(multiples, sideWidth, 0, screenWidth - sideWidth, screenHeight);
        }
        else {
            const sideHeight = Math.max(this.settings.drugStyle.size + this.settings.knownTargetStyle.size * 6, Math.min(screenHeight / 4, screenHeight - screenWidth));
            this._drugsStackLayout(singles, 0, 0, screenWidth, sideHeight);
            this._drugsNetworkLayout(multiples, 0, sideHeight, screenWidth, screenHeight - sideHeight);
        }
    }

    encodeDrugId(id: number): number {
        return id;
    }

    encodeTargetId(id: number): number {
        return 32768 + id;
    }

    encodeInteractionId(id: number): number {
        return 100000 + id;
    }

    decodeDrugId(id: number): number {
        return id;
    }

    decodeTargetId(id: number): number {
        return id - 32768;
    }

    decodeInteractionId(id: number): number {
        return id - 100000;
    }

    isDrugId(id: number): boolean {
        return id < 32768;
    }

    isTargetId(id: number): boolean {
        return id >= 32768 && id < 100000;
    }

    isInteractionId(id: number): boolean {
        return id >= 100000;
    }

    hitTest(x: number, y: number): number | null {
        // if click on a drug node
        for (let i = 0; i < this.drugs.length; i++) {
            const drugSize = this.settings.drugStyle.size;

            if (this.settings.showDepiction) {
                const bw = this.settings.drugStyle.borderWidth * 2;
                let imgSize: Size = new Size(drugSize + bw, drugSize + bw);
                const img = this.drugs[i].img;

                if (img !== undefined)
                    imgSize = img.naturalSize().fit(drugSize).add(bw, bw);
                const dx = Math.abs(x - this.drugs[i].x), dy = Math.abs(y - this.drugs[i].y);

                if (dx <= imgSize.width / 2 && dy <= imgSize.height / 2)
                    return this.encodeDrugId(i);
            }
            else {
                const radius = drugSize / 2 + this.settings.drugStyle.borderWidth;
                const dx = x - this.drugs[i].x, dy = y - this.drugs[i].y;

                if (dx * dx + dy * dy <= radius * radius)
                    return this.encodeDrugId(i);
            }
        }

        // if click on a target node
        for (let i = 0; i < this.targets.length; i++) {
            let radius: number;
            if (this.targets[i].known) {
                radius = (this.settings.knownTargetStyle.size + this.targets[i].drugs.length * 5) / 2 + this.settings.knownTargetStyle.borderWidth;
            } else {
                radius = (this.settings.unknownTargetStyle.size + this.targets[i].drugs.length * 5) / 2 + this.settings.unknownTargetStyle.borderWidth;
            }

            const dx = x - this.targets[i].x, dy = y - this.targets[i].y;

            if (dx * dx + dy * dy <= radius * radius) {
                return this.encodeTargetId(i);
            }
        }

        // if click on an interaction
        for (let i = 0; i < this.interactions.length; i++) {
            const ix = this.interactions[i];
            const x0 = this.drugs[ix.drug].x, y0 = this.drugs[ix.drug].y;
            const x1 = this.targets[ix.target].x, y1 = this.targets[ix.target].y;
            const l = Math.sqrt((x1 - x0) * (x1 - x0) + (y1 - y0) * (y1 - y0));
            const l0 = Math.sqrt((x - x0) * (x - x0) + (y - y0) * (y - y0));
            const l1 = Math.sqrt((x - x1) * (x - x1) + (y - y1) * (y - y1));

            if (l0 + l1 < l * 1.005) {
                //alert(`${this.drugs[ix.drug].name},${this.targets[ix.target].name}`);
                return this.encodeInteractionId(i);
            }
        }

        return null;
    }

    getSelectionStyle(): NodeStyle | null {
        if (this.selectedIds.length !== 1) {
            return null;
        }

        const id = this.selectedIds[0];
        let style: NodeStyle;

        if (this.isDrugId(id)) {
            style = this.settings.drugStyle;
        } else if (this.isTargetId(id)) {
            if (this.targets[this.decodeTargetId(id)].known) {
                style = this.settings.knownTargetStyle;
            } else {
                style = this.settings.unknownTargetStyle;
            }
        } else {
            return null;
        }

        return style;
    }

    setSelectionStyle(style: StyleBag): boolean {
        if (this.selectedIds.length !== 1)
            return false;

        const id = this.selectedIds[0];
        let tstyle: NodeStyle;

        if (this.isDrugId(id)) {
            tstyle = this.settings.drugStyle;
        } else if (this.isTargetId(id)) {
            if (this.targets[this.decodeTargetId(id)].known) {
                tstyle = this.settings.knownTargetStyle;
            } else {
                tstyle = this.settings.unknownTargetStyle;
            }
        } else {
            return false;
        }

        if (style.fillColor !== undefined)
            tstyle.fillColor = style.fillColor;

        if (style.size !== undefined)
            tstyle.size = style.size;

        if (style.borderPaint !== undefined)
            tstyle.borderPaint = style.borderPaint;

        if (style.borderWidth !== undefined)
            tstyle.borderWidth = style.borderWidth;

        if (style.labelColor !== undefined)
            tstyle.labelColor = style.labelColor;

        if (style.labelFontSize !== undefined)
            tstyle.labelFontSize = style.labelFontSize;

        return true;
    }

    unselectAll(): boolean {
        if (this.selectedIds.length === 0)
            return false;

        for (let i = 0; i < this.selectedIds.length; i++) {
            const id = this.selectedIds[i];
            if (this.isDrugId(id)) {
                this.drugs[this.decodeDrugId(id)].selected = false;
            } else if (this.isTargetId(id)) {
                this.targets[this.decodeTargetId(id)].selected = false;
            }
        }

        this.selectedIds = [];

        return true;
    }

    select(sel: number): boolean {
        if (this.isDrugId(sel)) {
            const id = this.decodeDrugId(sel);

            // single selection: clicking on the only selected node takes no effect.
            if (this.drugs[id].selected
                && this.selectedIds.length === 1) {
                return false;
            }

            // single selection: clicking on nonselected node unselects the others.
            this.unselectAll();
            this.selectedIds = [sel];
            this.drugs[id].selected = true;
        }
        else if (this.isTargetId(sel)) {
            const id = this.decodeTargetId(sel);

            // single selection: clicking on the only selected node takes no effect.
            if (this.targets[id].selected
                && this.selectedIds.length === 1) {
                return false;
            }

            // single selection: clicking on nonselected node unselects the others.
            this.unselectAll();
            this.selectedIds = [sel];
            this.targets[id].selected = true;
        } else {
            return false;
        }

        return true;
    }

    multiSelect(sel: number): boolean {
        if (this.isDrugId(sel)) {
            const id = this.decodeDrugId(sel);

            // multiple selection: clicking on the selected node unselects itself.
            if (this.drugs[id].selected) {
                this.drugs[id].selected = false;
                for (let i = 0; i < this.selectedIds.length; i++) {
                    if (this.selectedIds[i] === id) {
                        this.selectedIds.splice(i, 1);
                        break;
                    }
                }
            } else {
                // multiple selection： clicking on the nonselected node selects itself.
                this.drugs[id].selected = true;
                this.selectedIds.push(sel);
            }
        } else if (this.isTargetId(sel)) {
            const id = this.decodeTargetId(sel);

            // multiple selection: clicking on the selected node unselects itself.
            if (this.targets[id].selected) {
                this.targets[id].selected = false;
                for (let i = 0; i < this.selectedIds.length; i++) {
                    if (this.selectedIds[i] === id) {
                        this.selectedIds.splice(i, 1);
                        break;
                    }
                }
            } else {
                // multiple selection： clicking on the nonselected node selects itself.
                this.targets[id].selected = true;
                this.selectedIds.push(sel);
            }
        }

        return true;
    }

    draw(canvas: HTMLCanvasElement): void {
        const ctx = canvas.getContext("2d");
        if (ctx === null)
            return;

        // setup context
        ctx.save();

        ctx.clearRect(0, 0, canvas.width, canvas.height);
        ctx.scale(this.navigation.scale * window.devicePixelRatio, this.navigation.scale * window.devicePixelRatio);
        ctx.translate(this.navigation.offsetX, this.navigation.offsetY);

        // get styles
        const knownIntStyle = this.settings.knownInteractionStyle;
        const unknownIntStyle = this.settings.unknownInteractionStyle;

        // draw known interaction lines
        ctx.beginPath();
        ctx.lineWidth = knownIntStyle.lineWidth;
        ctx.strokeStyle = knownIntStyle.strokeStyle.toHtml();

        for (let i = 0; i < this.interactions.length; i++) {
            const ix = this.interactions[i];
            if (ix.known) {
                const x0 = this.drugs[ix.drug].x, y0 = this.drugs[ix.drug].y;
                const x1 = this.targets[ix.target].x, y1 = this.targets[ix.target].y;

                if (knownIntStyle.dashLinePatten === undefined) {
                    ctx.moveTo(x0, y0);
                    ctx.lineTo(x1, y1);
                } else {
                    ctx.dashedLineTo(x0, y0, x1, y1, knownIntStyle.dashLinePatten);
                }
            }
        }

        ctx.stroke();

        // draw unknown interaction dashed lines
        ctx.beginPath();
        ctx.lineWidth = unknownIntStyle.lineWidth;
        ctx.strokeStyle = unknownIntStyle.strokeStyle.toHtml();

        for (let i = 0; i < this.interactions.length; i++) {
            const ix = this.interactions[i];
            if (!ix.known) {
                const x0 = this.drugs[ix.drug].x, y0 = this.drugs[ix.drug].y;
                const x1 = this.targets[ix.target].x, y1 = this.targets[ix.target].y;

                if (unknownIntStyle.dashLinePatten === undefined) {
                    ctx.moveTo(x0, y0);
                    ctx.lineTo(x1, y1);
                } else {
                    ctx.dashedLineTo(x0, y0, x1, y1, unknownIntStyle.dashLinePatten);
                }
            }
        }

        ctx.stroke();

        // draw drug nodes
        for (let i = 0; i < this.drugs.length; i++) {
            const node = this.drugs[i];
            const rb = this.navigation.toPhysical(node.x + this.settings.drugStyle.size / 2, node.y + this.settings.drugStyle.size / 2);
            const lt = this.navigation.toPhysical(node.x - this.settings.drugStyle.size / 2, node.y - this.settings.drugStyle.size / 2);

            if (rb.x <= 0 || rb.y <= 0 || lt.x >= canvas.width || lt.y >= canvas.height) {
                continue;
            }

            const fillColor = (node.selected ? this.settings.drugStyle.selectedFillColor : this.settings.drugStyle.fillColor);
            const borderWidth = this.settings.drugStyle.borderWidth;
            const borderPaint = this.settings.drugStyle.borderPaint;
            const labelColor = (node.selected ? this.settings.drugStyle.selectedLabelColor : this.settings.drugStyle.labelColor);
            const labelFontSize = this.settings.drugStyle.labelFontSize;

            const size = this.settings.drugStyle.size;

            if (this.settings.showDepiction) {
                const img = this.drugs[i].img;

                let imgSize = new Size(size, size);
                if (img !== undefined)
                    imgSize = img.naturalSize().fit(size);
                //console.log(`imgSize:${imgSize.width},${imgSize.height}`);

                const radius = this.settings.drugStyle.roundRectRadius;
                const x = node.x - imgSize.width / 2, y = node.y - imgSize.height / 2;

                ctx.drawRoundRect(x, y, imgSize.width, imgSize.height, radius, fillColor, borderWidth, borderPaint, node.name, labelColor, labelFontSize);

                if (img !== undefined)
                    ctx.drawImage(img, x, y, imgSize.width, imgSize.height);
            }
            else {
                ctx.drawRound(node.x, node.y, size / 2, fillColor, borderWidth, borderPaint, node.name, labelColor, labelFontSize);
            }
        }

        // draw target nodes
        for (let i = 0; i < this.targets.length; i++) {
            const node = this.targets[i];
            const rb = this.navigation.toPhysical(node.x + this.settings.unknownTargetStyle.size / 2, node.y + this.settings.unknownTargetStyle.size / 2);
            const lt = this.navigation.toPhysical(node.x - this.settings.unknownTargetStyle.size / 2, node.y - this.settings.unknownTargetStyle.size / 2);

            if (rb.x <= 0 || rb.y <= 0 || lt.x >= canvas.width || lt.y >= canvas.height) {
                continue;
            }

            let style: NodeStyle;
            if (node.known) {
                style = this.settings.knownTargetStyle;
            } else {
                style = this.settings.unknownTargetStyle;
            }

            if (node.selected) {
                ctx.drawRound(node.x, node.y, (style.size + 5 * node.drugs.length) / 2, style.selectedFillColor,
                    style.borderWidth, style.borderPaint, node.name, style.selectedLabelColor,
                    style.labelFontSize);
            } else {
                ctx.drawRound(node.x, node.y, (style.size + 5 * node.drugs.length) / 2, style.fillColor,
                    style.borderWidth, style.borderPaint, node.name, style.labelColor,
                    style.labelFontSize);
            }
        }

        // draw known interaction labels
        ctx.font = `${(knownIntStyle.labelFontBold ? "bold " : "")}${knownIntStyle.labelFontSize}px Arial`;
        ctx.fillStyle = knownIntStyle.labelColor.toHtml();

        const a = this.settings.drugStyle.size / 2;
        let b = this.settings.knownTargetStyle.size / 2;

        for (let i = 0; i < this.interactions.length; i++) {
            const ix = this.interactions[i];
            if (ix.known && (this.settings.showLabel ? 1 : 0) ^ (ix.reverse ? 1 : 0)) {
                const x0 = this.drugs[ix.drug].x, y0 = this.drugs[ix.drug].y;
                const x1 = this.targets[ix.target].x, y1 = this.targets[ix.target].y;
                const l = Math.sqrt((x1 - x0) * (x1 - x0) + (y1 - y0) * (y1 - y0));
                const f = (l + a - b) / l / 2;

                const text = ix.value;
                const textWidth = ctx.measureText(text).width;
                ctx.fillText(text, x0 + (x1 - x0) * f - textWidth / 2, y0 + (y1 - y0) * f + knownIntStyle.labelFontSize / 2);
            }
        }

        // draw unknown interaction labels
        ctx.font = `${(unknownIntStyle.labelFontBold ? "bold " : "")}${unknownIntStyle.labelFontSize}px Arial`;
        ctx.fillStyle = unknownIntStyle.labelColor.toHtml();

        b = this.settings.unknownTargetStyle.size / 2;
        for (let i = 0; i < this.interactions.length; i++) {
            const ix = this.interactions[i];
            if (!ix.known && (this.settings.showLabel ? 1 : 0) as number ^ (ix.reverse ? 1 : 0)) {
                const x0 = this.drugs[ix.drug].x, y0 = this.drugs[ix.drug].y;
                const x1 = this.targets[ix.target].x, y1 = this.targets[ix.target].y;
                const l = Math.sqrt((x1 - x0) * (x1 - x0) + (y1 - y0) * (y1 - y0));
                const f = (l + a - b) / l / 2;

                const text = ix.value;
                const textWidth = ctx.measureText(text).width;
                ctx.fillText(text, x0 + (x1 - x0) * f - textWidth / 2, y0 + (y1 - y0) * f + unknownIntStyle.labelFontSize / 2);
            }
        }

        // cleanup context
        ctx.restore();
    }

    shift(dx: number, dy: number): boolean {
        if (this.selectedIds.length === 0) {
            return false;
        }

        for (let i = 0; i < this.selectedIds.length; i++) {
            let id = this.selectedIds[i];
            if (this.isDrugId(id)) {
                id = this.decodeDrugId(id);
                this.drugs[id].x += dx;
                this.drugs[id].y += dy;
            } else if (this.isTargetId(id)) {
                id = this.decodeTargetId(id);
                this.targets[id].x += dx;
                this.targets[id].y += dy;
            }
        }

        return true;
    }
};
