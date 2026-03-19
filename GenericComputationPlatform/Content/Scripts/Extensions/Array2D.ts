class Array2D {
    static create<T>(length0: number): T[][] {
        const r: T[][] = [];
        for (let i = 0; i < length0; i++) {
            r[i] = [];
        }
        return r;
    }

    static fill<T>(length0: number, length1: number, value: T): T[][] {
        const r: T[][] = [];
        for (let i = 0; i < length0; i++) {
            r[i] = [];
            for (let j = 0; j < length1; j++) {
                r[i][j] = value;
            }
        }
        return r;
    }
}