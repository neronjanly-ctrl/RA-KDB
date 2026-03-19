class Array3D {
    static create<T>(length0: number, length1: number): T[][][] {
        const r: T[][][] = [];
        for (let i = 0; i < length0; i++) {
            r[i] = [];
            for (let j = 0; j < length1; j++)
                r[i][j] = [];
        }
        return r;
    }

    static createMono<T>(length: number): T[][][] {
        return this.create<T>(length, length);
    }

    static fill<T>(length0: number, length1: number, length2: number, value: T): T[][][] {
        const r: T[][][] = [];
        for (let i = 0; i < length0; i++) {
            r[i] = [];
            for (let j = 0; j < length1; j++) {
                r[i][j] = [];
                for (let k = 0; k < length2; k++)
                    r[i][j][k] = value;
            }
        }
        return r;
    }

    static fillMono<T>(length: number, value: T): T[][][] {
        return this.fill<T>(length, length, length, value);
    }
}