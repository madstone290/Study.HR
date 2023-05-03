export interface ContentMapper<TData = number> {
    map(response: Response): Promise<TData>;
}

export class JsonMapper<TData> implements ContentMapper<TData> {
    async map(response: Response): Promise<TData> {
        return await response.json() as TData;
    }
}

export class TextMapper<TData> implements ContentMapper<TData> {
    textMap: (text: string) => TData;

    constructor(textMap: (text: string) => TData) {
        this.textMap = textMap;
    }

    async map(response: Response): Promise<TData> {
        const json = await response.text();
        return this.textMap(json);
    }
}
