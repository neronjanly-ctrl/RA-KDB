
class DisjointSet {
    private _roots: number[];
    private _size: number;

    constructor(num: number) {
        if (num <= 0)
            throw new DOMException("wrong DisjointSet size in constructor");
        this._roots = [];
        this._size = num;
        for (let i = 0; i < num; i++)
            this._roots.push(i);
    }

    join(i: number, j: number) {
        i = this.find(i);
        j = this.find(j);
        if (i !== j) {
            this._roots[i] = j;
            this._size--;
        }
    }

    find(i: number): number {
        if (this._roots[i] === i)
            return i;
        return this._roots[i] = this.find(this._roots[i]);
    }

    size(): number {
        return this._size;
    }

    groups(): number[][] {
        let grps: number[][] = [];
        let dict = new Map<number, number>();
        for (let i = 0; i < this._roots.length; i++) {
            let j = this.find(i);
            if (dict.has(j))
                j = dict.get(j) as number;
            else {
                dict.set(j, dict.size);
                j = dict.size - 1;
                grps[j] = [];
            }
            grps[j].push(i);
        }
        return grps;
    }
}